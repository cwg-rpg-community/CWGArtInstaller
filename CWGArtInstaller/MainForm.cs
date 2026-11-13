using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CWGArtInstaller
{
    public partial class MainForm : Form
    {
        private const string ZipFileName = "war3mapImported.zip";

        private const string CheckMark = "\u2714";  // ✔
        private const string CrossMark = "\u2716";  // ✖

        private static readonly HttpClient Http = new HttpClient { Timeout = Timeout.InfiniteTimeSpan };

        private CancellationTokenSource _cts;
        private bool _busy;
        private bool _closeWhenCancelled;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Only offer Validate / Reinstall / Uninstall when war3mapImported is actually installed.
            // Registry set to 1 but no war3mapImported (or neither) -> normal Install flow.
            if (ModelsAreInstalled())
                tabWizard.ShowPage(tabPageManage);
        }

        /// <summary>True if a war3mapImported folder exists in the detected Warcraft III folder.</summary>
        private static bool ModelsAreInstalled()
        {
            string path = WarcraftPathFinder.FindInstallPath(out _);
            return path != null && WarcraftPathFinder.FindExistingModelFolders(path).Length > 0;
        }

        // ───────────────────────── Page 1: Install / Reinstall ─────────────────────────

        private async void btnInstall_Click(object sender, EventArgs e) =>
            await EnableLocalFilesAndContinueAsync(btnInstall);

        private async void btnReinstall_Click(object sender, EventArgs e) =>
            await EnableLocalFilesAndContinueAsync(btnReinstall);

        /// <summary>Imports EnableWC3LocalFiles.reg, then moves to the install path page.</summary>
        private async Task EnableLocalFilesAndContinueAsync(Button trigger)
        {
            trigger.Enabled = false;
            UseWaitCursor = true;
            try
            {
                await Task.Run(() => LocalFilesRegistry.ApplyRegFile(EmbeddedAssets.EnableReg, 1));
                GoToPathPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Could not enable local files for Warcraft III:\n\n" + ex.Message,
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UseWaitCursor = false;
                trigger.Enabled = true;
            }
        }

        // ───────────────────────── Page 2: choose install path ─────────────────────────

        private void GoToPathPage()
        {
            tabWizard.ShowPage(tabPagePath);

            string path = WarcraftPathFinder.FindInstallPath(out string source);
            if (path != null)
            {
                txtInstallPath.Text = path;
                SetPathStatus(source, false);
            }
            else
            {
                SetPathStatus("Warcraft III was not found automatically. Click Browse... to select it.", true);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string selected = BrowseForWarcraftFolder(txtInstallPath.Text);
            if (selected == null) return;

            txtInstallPath.Text = selected;
            if (WarcraftPathFinder.LooksLikeWarcraftFolder(selected))
                SetPathStatus("Warcraft III found in this folder.", false);
            else
                SetPathStatus("Warning: Warcraft III files were not found in this folder.", true);
        }

        private string BrowseForWarcraftFolder(string startPath)
        {
            using (var dialog = new FolderBrowserDialog
            {
                Description = "Select your Warcraft III install folder",
                ShowNewFolderButton = false
            })
            {
                if (Directory.Exists(startPath))
                    dialog.SelectedPath = startPath;

                return dialog.ShowDialog(this) == DialogResult.OK ? dialog.SelectedPath : null;
            }
        }

        private void SetPathStatus(string message, bool warning)
        {
            lblPathStatus.Text = message;
            lblPathStatus.ForeColor = warning ? Color.DarkOrange : Color.SeaGreen;
        }

        private async void btnInstallModels_Click(object sender, EventArgs e)
        {
            string destination = txtInstallPath.Text.Trim().Trim('"');

            if (destination.Length == 0 || !Directory.Exists(destination))
            {
                MessageBox.Show(this, "Please select a folder that exists.", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!WarcraftPathFinder.LooksLikeWarcraftFolder(destination) &&
                MessageBox.Show(this,
                    "This folder doesn't look like a Warcraft III install.\n\nInstall the models here anyway?",
                    Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            string url;
            try
            {
                url = ReadDownloadUrl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tabWizard.ShowPage(tabPageInstall);
            await RunInstallAsync(url, destination);
        }

        private static string ReadDownloadUrl()
        {
            string[] lines = EmbeddedAssets.ReadText(EmbeddedAssets.DownloadUrl)
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                string text = line.Trim();
                if (text.Length == 0 || text.StartsWith("#")) continue;

                if (Uri.TryCreate(text, UriKind.Absolute, out Uri uri) &&
                    (uri.Scheme == Uri.UriSchemeHttps || uri.Scheme == Uri.UriSchemeHttp))
                    return text;
            }

            throw new InvalidDataException("No valid download link is configured in this installer.");
        }

        // ───────────────────────── Page 3: download & install ─────────────────────────

        private async Task RunInstallAsync(string url, string destination)
        {
            string zipPath = Path.Combine(destination, ZipFileName);

            _busy = true;
            _cts = new CancellationTokenSource();
            lblComplete.Visible = false;
            btnClose.Visible = false;
            progressBar.Style = ProgressBarStyle.Blocks;
            progressBar.Value = 0;

            try
            {
                // 1) Download war3mapImported.zip into the Warcraft III folder.
                lblStatus.Text = "Connecting...";
                var downloadProgress = new Progress<(long Read, long? Total)>(p => UpdateDownloadProgress(p.Read, p.Total));
                await DownloadFileAsync(url, zipPath, downloadProgress, _cts.Token);

                // 2) Unzip it into the same folder (overwriting older versions of the models).
                progressBar.Style = ProgressBarStyle.Blocks;
                progressBar.Value = 0;
                lblStatus.Text = "Extracting...";
                var extractProgress = new Progress<int>(pct =>
                {
                    progressBar.Value = pct;
                    lblStatus.Text = $"Extracting... {pct}%";
                });
                await Task.Run(() => ExtractZip(zipPath, destination, extractProgress, _cts.Token));

                progressBar.Value = 100;
                lblStatus.Text = "Models installed to " + destination;
                ShowResult(lblComplete, "Complete", Color.SeaGreen);
            }
            catch (OperationCanceledException)
            {
                lblStatus.Text = "Installation cancelled.";
                ShowResult(lblComplete, "Cancelled", Color.DarkOrange);
            }
            catch (InvalidDataException)
            {
                lblStatus.Text = "The downloaded file is not a valid zip. The download link may have expired.";
                ShowResult(lblComplete, "Failed", Color.Firebrick);
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
                ShowResult(lblComplete, "Failed", Color.Firebrick);
            }
            finally
            {
                // 3) Always remove the zip once we're done with it.
                TryDeleteFile(zipPath);

                _busy = false;
                _cts.Dispose();
                _cts = null;
                btnClose.Visible = true;

                if (_closeWhenCancelled)
                    BeginInvoke(new Action(Close));
            }
        }

        private void ShowResult(Label label, string text, Color color)
        {
            if (progressBar.Style == ProgressBarStyle.Marquee)
                progressBar.Style = ProgressBarStyle.Blocks;

            label.Text = text;
            label.ForeColor = color;
            label.Visible = true;
        }

        private void UpdateDownloadProgress(long read, long? total)
        {
            if (total.HasValue && total.Value > 0)
            {
                int pct = (int)Math.Min(100, read * 100 / total.Value);
                progressBar.Style = ProgressBarStyle.Blocks;
                progressBar.Value = pct;
                lblStatus.Text = $"Downloading... {FormatBytes(read)} of {FormatBytes(total.Value)} ({pct}%)";
            }
            else
            {
                // Server didn't send a file size, so show an animated bar instead.
                progressBar.Style = ProgressBarStyle.Marquee;
                lblStatus.Text = $"Downloading... {FormatBytes(read)}";
            }
        }

        private static async Task DownloadFileAsync(string url, string destinationFile,
            IProgress<(long Read, long? Total)> progress, CancellationToken token)
        {
            using (HttpResponseMessage response = await Http.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, token))
            {
                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException(
                        $"Download failed: server returned {(int)response.StatusCode} {response.ReasonPhrase}. " +
                        "The download link may have expired.");

                long? total = response.Content.Headers.ContentLength;

                using (Stream input = await response.Content.ReadAsStreamAsync())
                using (var output = new FileStream(destinationFile, FileMode.Create, FileAccess.Write, FileShare.None, 81920, true))
                {
                    var buffer = new byte[81920];
                    long read = 0;
                    long lastReported = -1;
                    int count;

                    while ((count = await input.ReadAsync(buffer, 0, buffer.Length, token)) > 0)
                    {
                        await output.WriteAsync(buffer, 0, count, token);
                        read += count;

                        // Only update the UI when the percentage (or each 256 KB if size is unknown) changes.
                        long step = total > 0 ? read * 100 / total.Value : read / (256 * 1024);
                        if (step != lastReported)
                        {
                            lastReported = step;
                            progress.Report((read, total));
                        }
                    }

                    progress.Report((read, total));
                }
            }
        }

        private static void ExtractZip(string zipPath, string destination, IProgress<int> progress, CancellationToken token)
        {
            string root = Path.GetFullPath(destination);
            if (!root.EndsWith(Path.DirectorySeparatorChar.ToString()))
                root += Path.DirectorySeparatorChar;

            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                int total = archive.Entries.Count;
                int done = 0;
                int lastPct = -1;

                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    token.ThrowIfCancellationRequested();

                    string target = Path.GetFullPath(Path.Combine(root, entry.FullName));

                    // Safety: never write outside the Warcraft III folder.
                    if (!target.StartsWith(root, StringComparison.OrdinalIgnoreCase))
                        throw new IOException("The zip contains an invalid path: " + entry.FullName);

                    if (string.IsNullOrEmpty(entry.Name))
                    {
                        Directory.CreateDirectory(target); // folder entry
                    }
                    else
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(target));
                        entry.ExtractToFile(target, overwrite: true);
                    }

                    done++;
                    int pct = total == 0 ? 100 : done * 100 / total;
                    if (pct != lastPct)
                    {
                        lastPct = pct;
                        progress.Report(pct);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        // ───────────────────────── Manage page: Validate ─────────────────────────

        private void btnValidate_Click(object sender, EventArgs e)
        {
            tabWizard.ShowPage(tabPageValidate);
            txtValidatePath.Text = WarcraftPathFinder.FindInstallPath(out _) ?? string.Empty;
            RunValidation();
        }

        private void btnValidateBrowse_Click(object sender, EventArgs e)
        {
            string selected = BrowseForWarcraftFolder(txtValidatePath.Text);
            if (selected == null) return;

            txtValidatePath.Text = selected;
            RunValidation();
        }

        private void btnRecheck_Click(object sender, EventArgs e) => RunValidation();

        private void btnValidateBack_Click(object sender, EventArgs e) => tabWizard.ShowPage(tabPageManage);

        /// <summary>Checks the registry value and that war3mapImported exists in the Warcraft III folder.</summary>
        private void RunValidation()
        {
            // Check 1: registry
            int? value = LocalFilesRegistry.ReadValue();
            bool registryOk = value == 1;
            SetCheck(lblCheckRegistry, registryOk, registryOk
                ? "Registry: Allow Local Files is set to 1"
                : $"Registry: Allow Local Files is {(value.HasValue ? "set to " + value : "missing")} (should be 1)");

            // Check 2: war3mapImported folder
            string path = txtValidatePath.Text.Trim().Trim('"');
            bool modelsOk = false;
            string modelsMessage;

            if (path.Length == 0 || !Directory.Exists(path))
            {
                modelsMessage = "war3mapImported: Warcraft III folder not found. Click Browse... to select it.";
            }
            else
            {
                string[] found = WarcraftPathFinder.FindExistingModelFolders(path);
                if (found.Length > 0)
                {
                    int files = CountFiles(found);
                    modelsOk = files > 0;
                    modelsMessage = modelsOk
                        ? $"war3mapImported found ({files} files): {found[0]}"
                        : "war3mapImported exists but is empty: " + found[0];
                }
                else
                {
                    modelsMessage = "war3mapImported was not found in " + WarcraftPathFinder.GetRootFolder(path);
                }
            }
            SetCheck(lblCheckModels, modelsOk, modelsMessage);

            bool allOk = registryOk && modelsOk;
            lblValidateSummary.Text = allOk
                ? "Everything looks good."
                : "Problems were found. Go Back and choose Reinstall to fix them.";
            lblValidateSummary.ForeColor = allOk ? Color.SeaGreen : Color.Firebrick;
        }

        private static void SetCheck(Label label, bool ok, string message)
        {
            label.Text = (ok ? CheckMark : CrossMark) + "  " + message;
            label.ForeColor = ok ? Color.SeaGreen : Color.Firebrick;
        }

        private static int CountFiles(string[] folders)
        {
            try
            {
                return folders.Sum(f => Directory.EnumerateFiles(f, "*", SearchOption.AllDirectories).Count());
            }
            catch
            {
                return 0;
            }
        }

        // ───────────────────────── Manage page: Uninstall ─────────────────────────

        private async void btnUninstall_Click(object sender, EventArgs e)
        {
            string path = WarcraftPathFinder.FindInstallPath(out _) ?? BrowseForWarcraftFolder(null);
            if (path == null) return;

            string[] modelFolders = WarcraftPathFinder.FindExistingModelFolders(path);
            string deleteText = modelFolders.Length > 0
                ? "and delete:\n" + string.Join("\n", modelFolders)
                : "(no war3mapImported folder was found to delete)";

            if (MessageBox.Show(this, $"This will disable local files for Warcraft III {deleteText}\n\nContinue?",
                    Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            tabWizard.ShowPage(tabPageUninstall);
            lblUninstallComplete.Visible = false;
            btnUninstallClose.Visible = false;
            _busy = true;

            try
            {
                // 1) Import DisableWC3LocalFiles.reg ("Allow Local Files" = 0).
                lblUninstallDetails.Text = "Disabling local files...";
                await Task.Run(() => LocalFilesRegistry.ApplyRegFile(EmbeddedAssets.DisableReg, 0));

                // 2) Delete war3mapImported.
                lblUninstallDetails.Text = "Deleting war3mapImported...";
                await Task.Run(() =>
                {
                    foreach (string folder in modelFolders)
                        DeleteDirectory(folder);
                });

                lblUninstallDetails.Text = "Local files disabled." + Environment.NewLine +
                    (modelFolders.Length > 0
                        ? "Deleted: " + string.Join(Environment.NewLine, modelFolders)
                        : "No war3mapImported folder was found.");
                ShowResult(lblUninstallComplete, "Complete", Color.SeaGreen);
            }
            catch (Exception ex)
            {
                lblUninstallDetails.Text = ex.Message;
                ShowResult(lblUninstallComplete, "Failed", Color.Firebrick);
            }
            finally
            {
                _busy = false;
                btnUninstallClose.Visible = true;
            }
        }

        /// <summary>Deletes a folder and everything in it, including read-only files.</summary>
        private static void DeleteDirectory(string folder)
        {
            if (!Directory.Exists(folder)) return;

            foreach (string file in Directory.EnumerateFiles(folder, "*", SearchOption.AllDirectories))
                File.SetAttributes(file, FileAttributes.Normal);

            Directory.Delete(folder, recursive: true);
        }

        // ───────────────────────── Shared helpers ─────────────────────────

        private static void TryDeleteFile(string path)
        {
            try
            {
                if (File.Exists(path)) File.Delete(path);
            }
            catch
            {
                // Not critical if the zip can't be removed.
            }
        }

        private static string FormatBytes(long bytes)
        {
            string[] units = { "B", "KB", "MB", "GB" };
            double size = bytes;
            int unit = 0;
            while (size >= 1024 && unit < units.Length - 1)
            {
                size /= 1024;
                unit++;
            }
            return $"{size:0.#} {units[unit]}";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_busy && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // let the current operation stop cleanly first

                if (_cts == null)
                {
                    // Uninstall in progress: it's quick and shouldn't be interrupted.
                    MessageBox.Show(this, "Please wait for the current operation to finish.", Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!_closeWhenCancelled &&
                         MessageBox.Show(this, "Installation is in progress. Cancel it and exit?", Text,
                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _closeWhenCancelled = true;
                    lblStatus.Text = "Cancelling...";
                    _cts.Cancel();
                }
            }

            base.OnFormClosing(e);
        }
    }
}
