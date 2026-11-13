using System;
using System.IO;

namespace CWGArtInstaller
{
    /// <summary>Reads the files in the project's assets folder, which are embedded inside the .exe.</summary>
    internal static class EmbeddedAssets
    {
        public const string EnableReg = "CWGArtInstaller.Assets.EnableWC3LocalFiles.reg";
        public const string DisableReg = "CWGArtInstaller.Assets.DisableWC3LocalFiles.reg";
        public const string DownloadUrl = "CWGArtInstaller.Assets.download_url.txt";

        public static Stream Open(string resourceName)
        {
            Stream stream = typeof(EmbeddedAssets).Assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
                throw new FileNotFoundException("Embedded asset is missing: " + resourceName);
            return stream;
        }

        public static string ReadText(string resourceName)
        {
            using (var reader = new StreamReader(Open(resourceName)))
                return reader.ReadToEnd();
        }

        /// <summary>
        /// Writes an embedded asset to a uniquely named temp file (byte-for-byte, so the
        /// UTF-16 .reg encoding is preserved). The caller deletes it when finished.
        /// </summary>
        public static string ExtractToTempFile(string resourceName, string extension)
        {
            string path = Path.Combine(Path.GetTempPath(), "CWG_" + Guid.NewGuid().ToString("N") + extension);
            using (Stream input = Open(resourceName))
            using (FileStream output = File.Create(path))
                input.CopyTo(output);
            return path;
        }
    }
}
