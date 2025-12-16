using System;
using System.Windows.Forms;
using Microsoft.Win32;
using DevExpress.UserSkins;
using DevExpress.Skins;
using TapCaps.UI;

namespace TapCaps
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("The Bezier Light");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EnsureAutoStart();
            Application.Run(new MainForm());
        }

        /// <summary>
        /// 在当前用户登录时自启动
        /// </summary>
        private static void EnsureAutoStart()
        {
            try
            {
                const string runKey = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
                using (var key = Registry.CurrentUser.OpenSubKey(runKey, true) ?? Registry.CurrentUser.CreateSubKey(runKey))
                {
                    if (key == null) return;
                    string exePath = Application.ExecutablePath;
                    var current = key.GetValue("TapCaps") as string;
                    if (!string.Equals(current, exePath, StringComparison.OrdinalIgnoreCase))
                    {
                        key.SetValue("TapCaps", exePath);
                    }
                }
            }
            catch
            {
                // 忽略注册失败，不阻止主程序运行
            }
        }
    }
}
