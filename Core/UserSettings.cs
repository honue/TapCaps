using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace TapCaps.Core
{
    [DataContract]
    public class UserSettings
    {
        [DataMember] public bool EnableMacCapsLock { get; set; } = true;
        [DataMember] public bool EnableKeyMapping { get; set; } = false;
        [DataMember] public bool EnableHud { get; set; } = true;
        [DataMember] public bool TrayIconEnabled { get; set; } = true;
        [DataMember] public bool AutoStartEnabled { get; set; } = true;
        [DataMember] public int LongPressThresholdMs { get; set; } = AppConfig.LongPressThresholdMs;
        [DataMember] public List<KeyMappingRule> KeyMappings { get; set; } = new List<KeyMappingRule>();
    }

    public static class UserSettingsStore
    {
        private const string FileName = "settings.json";

        private static string GetSettingsPath()
        {
            var dir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "TapCaps");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return Path.Combine(dir, FileName);
        }

        public static UserSettings Load()
        {
            var path = GetSettingsPath();
            if (!File.Exists(path))
            {
                return new UserSettings();
            }

            try
            {
                var json = File.ReadAllText(path, Encoding.UTF8);
                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                {
                    var serializer = new DataContractJsonSerializer(typeof(UserSettings));
                    var settings = (UserSettings)serializer.ReadObject(stream);
                    // 旧版本没有 AutoStartEnabled 字段时，默认开启自启
                    if (json.IndexOf("AutoStartEnabled", StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        settings.AutoStartEnabled = true;
                    }
                    return settings;
                }
            }
            catch
            {
                // Fallback to defaults if parsing fails.
                return new UserSettings();
            }
        }

        public static void Save(UserSettings settings)
        {
            if (settings == null) return;

            var path = GetSettingsPath();
            try
            {
                using (var stream = File.Create(path))
                {
                    var serializer = new DataContractJsonSerializer(typeof(UserSettings));
                    serializer.WriteObject(stream, settings);
                }
            }
            catch
            {
                // Ignore persistence errors to avoid crashing UI.
            }
        }
    }
}
