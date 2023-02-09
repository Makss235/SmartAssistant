using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System;

namespace SmartAssistant.Data
{
    public static class Greetings
    {
        private static string language;
        private static string jsonsDirectory;
        private static string fileName;
        private static string fullPathFileName;

        public static List<string> GreetingsObjs { get; set; }

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
            GreetingsObjs = JsonSerializer.Deserialize<List<string>>(allTextFronJson);
        }

        public static async void Serialize(List<string> greetingsObjs = null)
        {
            File.WriteAllText(fullPathFileName, string.Empty);
            using (FileStream fs = new FileStream(fullPathFileName, FileMode.OpenOrCreate))
            {
                var options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                };

                if (greetingsObjs == null)
                {
                    if (GreetingsObjs != null)
                        greetingsObjs = GreetingsObjs;
                    else
                        throw new Exception();
                }
                await JsonSerializer.SerializeAsync(fs, greetingsObjs, options);
            }
        }
    }
}
