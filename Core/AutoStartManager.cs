using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TapCaps.Core
{
    public static class AutoStartManager
    {
        private const string RunKeyPath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private const string AppName = "TapCaps";
        internal const string AutoStartArgument = "--auto-start";

        public static bool IsEnabled()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(RunKeyPath, false))
                {
                    if (key == null) return false;
                    var current = key.GetValue(AppName) as string;
                    if (string.IsNullOrEmpty(current)) return false;
                    // Accept both legacy (path only) and argument-based entries.
                    var exePath = Application.ExecutablePath;
                    return current.StartsWith(exePath, StringComparison.OrdinalIgnoreCase) ||
                           current.StartsWith($"\"{exePath}\"", StringComparison.OrdinalIgnoreCase);
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
                        var exePath = Application.ExecutablePath;
                        var command = $"\"{exePath}\" {AutoStartArgument}";
                        key.SetValue(AppName, command);
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
