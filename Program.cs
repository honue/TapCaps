using System;
using System.Windows.Forms;
using System.Threading;
using DevExpress.UserSkins;
using DevExpress.Skins;
using TapCaps.Core;
using TapCaps.UI;

namespace TapCaps
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("The Bezier Light");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool startHidden = args != null && Array.Exists(args, a =>
                string.Equals(a, AutoStartManager.AutoStartArgument, StringComparison.OrdinalIgnoreCase));

            const string mutexName = "Global\\TapCaps_E5CE010D_4F6B_4C1B_9E9E_9D05A4A91234";
            bool createdNew;
            using (var mutex = new Mutex(true, mutexName, out createdNew))
            {
                if (!createdNew)
                {
                    MessageBox.Show("TapCaps 已在运行，无需重复启动。", "TapCaps", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var settings = UserSettingsStore.Load() ?? new UserSettings();
                AutoStartManager.SetAutoStart(settings.AutoStartEnabled);
                Application.Run(new MainForm(settings, startHidden));
            }
        }
    }
}
