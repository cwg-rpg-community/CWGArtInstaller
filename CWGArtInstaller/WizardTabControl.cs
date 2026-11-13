using System;
using System.Windows.Forms;

namespace CWGArtInstaller
{
    /// <summary>
    /// A TabControl whose tab headers are visible in the Visual Studio designer
    /// (so you can still click between pages while editing) but hidden at runtime.
    /// Pages can only be changed from code through <see cref="ShowPage"/>,
    /// so the user can't skip steps with the mouse or Ctrl+Tab.
    /// </summary>
    public class WizardTabControl : TabControl
    {
        private const int TCM_ADJUSTRECT = 0x1328;
        private bool _allowPageChange;

        protected override void WndProc(ref Message m)
        {
            // Telling Windows the display area is the whole control hides the tab strip and border.
            if (m.Msg == TCM_ADJUSTRECT && !DesignMode)
            {
                m.Result = (IntPtr)1;
                return;
            }
            base.WndProc(ref m);
        }

        /// <summary>Switch to the given page (the only way to change pages at runtime).</summary>
        public void ShowPage(TabPage page)
        {
            _allowPageChange = true;
            try { SelectedTab = page; }
            finally { _allowPageChange = false; }
        }

        protected override void OnSelecting(TabControlCancelEventArgs e)
        {
            // Block keyboard shortcuts (Ctrl+Tab, Ctrl+PageUp/PageDown, arrows) from changing pages.
            if (!_allowPageChange && !DesignMode)
                e.Cancel = true;

            base.OnSelecting(e);
        }
    }
}
