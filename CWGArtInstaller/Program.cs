using System;
using System.Net;
using System.Windows.Forms;

namespace CWGArtInstaller
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            // Make sure HTTPS downloads use TLS 1.2 on .NET Framework.
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
