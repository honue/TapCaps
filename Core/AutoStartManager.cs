using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TapCaps.Core
{
    public static class AutoStartManager
    {
        private const string RunKeyPath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private const string AppName = "TapCaps";

        public static bool IsEnabled()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(RunKeyPath, false))
                {
                    if (key == null) return false;
                    var current = key.GetValue(AppName) as string;
                    if (string.IsNullOrEmpty(current)) return false;
                    return string.Equals(current, Application.ExecutablePath, StringComparison.OrdinalIgnoreCase);
                }
            }
            catch
            {
                return false;
            }
        }

        public static void SetAutoStart(bool enabled)
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(RunKeyPath, true) ??
                                Registry.CurrentUser.CreateSubKey(RunKeyPath))
                {
                    if (key == null) return;
                    if (enabled)
                    {
                        key.SetValue(AppName, Application.ExecutablePath);
                    }
                    else
                    {
                        key.DeleteValue(AppName, false);
                    }
                }
            }
            catch
            {
                // Ignore failures to avoid blocking UI flow.
            }
        }
    }
}
