using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System;

namespace SmartAssistant.Data
{
    public static class GreetingWords
    {
        private static string language;
        private static string jsonsDirectory;
        private static string fileName;
        private static string fullPathFileName;

        public static List<string> GreetingsObj { get; set; }

        public static void Init(string Language)
        {
            language = Language;
            jsonsDirectory = Path.Combine(string.Format($"c:\\users\\{Environment.UserName}\\"),
                "SmartAssistant\\Resources\\Greetings");
            fileName = $"Greetings_{language.ToUpper()}.json";
            fullPathFileName = Path.Combine(jsonsDirectory, fileName);

            Deserialize();
        }

        public static void Deserialize()
        {
            string allTextFronJson = File.ReadAllText(fullPathFileName);
            GreetingsObj = JsonSerializer.Deserialize<List<string>>(allTextFronJson);
        }

        public static async void Serialize(List<string> greetingsObj = null)
        {
            File.WriteAllText(fullPathFileName, string.Empty);
            using (FileStream fs = new FileStream(fullPathFileName, FileMode.OpenOrCreate))
            {
                var options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                };

                if (greetingsObj == null)
                {
                    if (GreetingsObj != null)
                        greetingsObj = GreetingsObj;
                    else
                        throw new Exception();
                }
                await JsonSerializer.SerializeAsync(fs, greetingsObj, options);
            }
        }
    }
}
