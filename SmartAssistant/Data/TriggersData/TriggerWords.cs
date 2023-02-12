using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System;

namespace SmartAssistant.Data.TriggersData
{
    public static class TriggerWords
    {
        private static string language;
        private static string jsonsDirectory;
        private static string fileName;
        private static string fullPathFileName;

        public static List<string> TriggersObj { get; set; }

        public static void Init(string Language)
        {
            language = Language;
            jsonsDirectory = Path.Combine(string.Format($"c:\\users\\{Environment.UserName}\\"),
                "SmartAssistant\\Resources\\Triggers");
            fileName = $"Triggers_{language.ToUpper()}.json";
            fullPathFileName = Path.Combine(jsonsDirectory, fileName);

            Deserialize();
        }

        public static void Deserialize()
        {
            string allTextFronJson = File.ReadAllText(fullPathFileName);
            TriggersObj = JsonSerializer.Deserialize<List<string>>(allTextFronJson);
        }

        public static async void Serialize(List<string> triggersObj = null)
        {
            File.WriteAllText(fullPathFileName, string.Empty);
            using (FileStream fs = new FileStream(fullPathFileName, FileMode.OpenOrCreate))
            {
                var options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                };

                if (triggersObj == null)
                {
                    if (TriggersObj != null)
                        triggersObj = TriggersObj;
                    else
                        throw new Exception();
                }
                await JsonSerializer.SerializeAsync(fs, triggersObj, options);
            }
        }
    }
}
