using System;
using System.IO;
using System.Linq;
using Microsoft.Win32;

namespace CWGArtInstaller
{
    /// <summary>Finds the Warcraft III install folder.</summary>
    internal static class WarcraftPathFinder
    {
        private const string BlizzardKey = @"Software\Blizzard Entertainment\Warcraft III";
        private const string InstallPathValue = "InstallPath";

        public const string ModelsFolderName = "war3mapImported";

        // Files that indicate a folder really is a Warcraft III install (Reforged and classic).
        private static readonly string[] MarkerFiles =
        {
            "Warcraft III.exe",
            "Warcraft III Launcher.exe",
            "war3.exe",
            "Frozen Throne.exe",
            @"x86_64\Warcraft III.exe",
            @"x86\Warcraft III.exe",
            @"_retail_\x86_64\Warcraft III.exe",
            @"..\Warcraft III Launcher.exe" // when the selected folder is _retail_
        };

        /// <summary>
        /// Returns the best guess for the install folder, or null if nothing was found.
        /// Checks HKCU\Software\Blizzard Entertainment\Warcraft III\InstallPath first,
        /// then the usual Program Files locations.
        /// </summary>
        public static string FindInstallPath(out string source)
        {
            string fromRegistry = ReadRegistryInstallPath();
            string resolved = ResolveGameFolder(fromRegistry);
            if (resolved != null)
            {
                source = "Found from the registry (InstallPath).";
                return resolved;
            }

            string pf86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            string pf = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

            string[] candidates =
            {
                @"C:\Program Files (x86)\Warcraft III",
                string.IsNullOrEmpty(pf86) ? null : Path.Combine(pf86, "Warcraft III"),
                string.IsNullOrEmpty(pf) ? null : Path.Combine(pf, "Warcraft III")
            };

            foreach (string candidate in candidates.Where(c => c != null).Distinct(StringComparer.OrdinalIgnoreCase))
            {
                resolved = ResolveGameFolder(candidate);
                if (resolved != null && LooksLikeWarcraftFolder(resolved))
                {
                    source = "Found in the default install location.";
                    return resolved;
                }
            }

            source = null;
            return null;
        }

        /// <summary>
        /// Cleans up a path and, if it points at the Warcraft III root and a _retail_
        /// folder exists (Reforged), returns the _retail_ folder instead.
        /// </summary>
        public static string ResolveGameFolder(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return null;

            try
            {
                path = path.Trim().Trim('"');
                if (path.Length > 3) path = path.TrimEnd('\\', '/');
                if (!Directory.Exists(path)) return null;

                if (!path.EndsWith("_retail_", StringComparison.OrdinalIgnoreCase))
                {
                    string retail = Path.Combine(path, "_retail_");
                    if (Directory.Exists(retail)) return retail;
                }
                return path;
            }
            catch
            {
                return null;
            }
        }

        public static bool LooksLikeWarcraftFolder(string path)
        {
            try
            {
                return Directory.Exists(path) &&
                       MarkerFiles.Any(f => File.Exists(Path.GetFullPath(Path.Combine(path, f))));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>Returns the Warcraft III root folder (the parent of _retail_ if given _retail_).</summary>
        public static string GetRootFolder(string path)
        {
            path = path.Trim().Trim('"');
            if (path.Length > 3) path = path.TrimEnd('\\', '/');
            return Path.GetFileName(path).Equals("_retail_", StringComparison.OrdinalIgnoreCase)
                ? Path.GetDirectoryName(path)
                : path;
        }

        /// <summary>Places war3mapImported can live: the root folder and the _retail_ folder.</summary>
        public static string[] GetModelFolderCandidates(string path)
        {
            string root = GetRootFolder(path);
            return new[]
            {
                Path.Combine(root, ModelsFolderName),
                Path.Combine(root, "_retail_", ModelsFolderName)
            };
        }

        /// <summary>The war3mapImported folders that actually exist for this install.</summary>
        public static string[] FindExistingModelFolders(string path)
        {
            try
            {
                return GetModelFolderCandidates(path).Where(Directory.Exists).ToArray();
            }
            catch
            {
                return new string[0];
            }
        }

        private static string ReadRegistryInstallPath()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(BlizzardKey))
                    return key?.GetValue(InstallPathValue) as string;
            }
            catch
            {
                return null;
            }
        }
    }
}
