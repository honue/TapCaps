using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TapCaps.Core;

namespace TapCaps.Pages
{
    public partial class HomePage : UserControl
    {
        private readonly LogicHandler _handler;
        private TapCaps.UI.MainForm _mainForm;

        public LogicHandler Handler => _handler;

        public HomePage(LogicHandler handler = null)
        {
            _handler = handler;
            InitializeComponent();
            this.Load += HomePage_Load;
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            _mainForm = this.FindForm() as TapCaps.UI.MainForm;
            InitializeBindings();
        }

        private void InitializeBindings()
        {
            // Disable switches if no handler is passed in (design-time scenario).
            bool hasHandler = _handler != null;
            chkMacStyle.Enabled = hasHandler;
            chkKeyMapping.Enabled = hasHandler;
            chkHud.Enabled = hasHandler;
            numLongPress.Enabled = hasHandler;

            if (hasHandler)
            {
                chkMacStyle.Checked = _handler.EnableMacCapsLock;
                chkKeyMapping.Checked = _handler.EnableKeyMapping;
                chkHud.Checked = _handler.EnableHud;
                numLongPress.Value = ClampToRange(_handler.LongPressThresholdMs, numLongPress.Minimum, numLongPress.Maximum);
            }

            bool hasMain = _mainForm != null;
            chkTrayIcon.Enabled = hasMain;
            if (hasMain)
            {
                chkTrayIcon.Checked = _mainForm.TrayIconEnabled;
            }
        }

        private static decimal ClampToRange(int value, decimal min, decimal max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        private void chkMacStyle_CheckedChanged(object sender, EventArgs e)
        {
            if (_handler == null) return;
            _handler.EnableMacCapsLock = chkMacStyle.Checked;
            _mainForm?.PersistSettings();
        }

        private void chkKeyMapping_CheckedChanged(object sender, EventArgs e)
        {
            if (_handler == null) return;
            _handler.EnableKeyMapping = chkKeyMapping.Checked;
            _mainForm?.PersistSettings();
        }

        private void chkHud_CheckedChanged(object sender, EventArgs e)
        {
            if (_handler == null) return;
            _handler.EnableHud = chkHud.Checked;
            _mainForm?.PersistSettings();
        }

        private void chkTrayIcon_CheckedChanged(object sender, EventArgs e)
        {
            if (_mainForm == null) return;
            _mainForm.SetTrayIconEnabled(chkTrayIcon.Checked);
            _mainForm.PersistSettings();
        }

        private void numLongPress_ValueChanged(object sender, EventArgs e)
        {
            if (_handler == null) return;
            _handler.LongPressThresholdMs = (int)numLongPress.Value;
            _mainForm?.PersistSettings();
        }
    }
}
