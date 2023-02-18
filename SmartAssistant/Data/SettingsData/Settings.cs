using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace SmartAssistant.Data.SettingsData
{
    public class Settings
    {
        private static string resourcesDirectory;
        private static string fullPathFileName;
        private static string fileName;

        public static SetObj JsonObject { get; set; }

        static Settings()
        {
            resourcesDirectory = Path.Combine(string.Format($"c:\\users\\{Environment.UserName}\\"),
                "SmartAssistant\\Resources\\Settings");
            fileName = $"Settings.json";
            fullPathFileName = Path.Combine(resourcesDirectory, fileName);

            Deserialize();
        }

        public static void Initialization() { }

        public static void Deserialize()
        {
            string allTextFronJson = File.ReadAllText(fullPathFileName);
            JsonObject = JsonSerializer.Deserialize<SetObj>(allTextFronJson);
        }

        public static async void Serialize()
        {
            File.WriteAllText(fullPathFileName, string.Empty);
            using (FileStream fs = new FileStream(fullPathFileName, FileMode.OpenOrCreate))
            {
                var options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                };
                await JsonSerializer.SerializeAsync(fs, JsonObject, options);
            }
        }
    }
}
