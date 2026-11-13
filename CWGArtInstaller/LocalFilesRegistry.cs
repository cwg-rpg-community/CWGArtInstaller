using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace CWGArtInstaller
{
    /// <summary>Reads and sets HKCU\Software\Blizzard Entertainment\Warcraft III\Allow Local Files.</summary>
    internal static class LocalFilesRegistry
    {
        private const string WarcraftKey = @"Software\Blizzard Entertainment\Warcraft III";
        private const string AllowLocalFilesValue = "Allow Local Files";

        public static bool IsEnabled() => ReadValue() == 1;

        public static int? ReadValue()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(WarcraftKey))
                    return key?.GetValue(AllowLocalFilesValue) is int value ? value : (int?)null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Silently imports an embedded .reg file and verifies "Allow Local Files" ended up as
        /// <paramref name="expectedValue"/>. Falls back to writing the value directly if reg.exe fails.
        /// </summary>
        public static void ApplyRegFile(string resourceName, int expectedValue)
        {
            string tempReg = EmbeddedAssets.ExtractToTempFile(resourceName, ".reg");
            int exitCode;
            try
            {
                var psi = new ProcessStartInfo("reg.exe", $"import \"{tempReg}\"")
                {
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                using (Process process = Process.Start(psi))
                {
                    process.WaitForExit();
                    exitCode = process.ExitCode;
                }
            }
            finally
            {
                try { File.Delete(tempReg); } catch { /* temp file, not critical */ }
            }

            if (exitCode != 0 || ReadValue() != expectedValue)
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(WarcraftKey))
                    key.SetValue(AllowLocalFilesValue, expectedValue, RegistryValueKind.DWord);
            }

            if (ReadValue() != expectedValue)
                throw new InvalidOperationException(
                    $"The \"{AllowLocalFilesValue}\" registry value could not be set to {expectedValue}.");
        }
    }
}
