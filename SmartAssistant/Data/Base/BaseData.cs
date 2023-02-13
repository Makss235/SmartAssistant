using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace SmartAssistant.Data.Base
{
    public abstract class BaseData<T> where T : class
    {
        protected static string language;
        protected static string jsonsDirectory;
        protected static string fileName;
        protected static string fullPathFileName;

        public static T JsonObject { get; set; }

        public static void Init(string Language)
        {
            language = Language;
            jsonsDirectory = Path.Combine(string.Format($"c:\\users\\{Environment.UserName}\\"),
                "SmartAssistant\\Resources\\Programs");
            fileName = $"Programs_{language.ToUpper()}.json";
            fullPathFileName = Path.Combine(jsonsDirectory, fileName);

            Deserialize();
        }

        public static void Deserialize()
        {
            string allTextFronJson = File.ReadAllText(fullPathFileName);
            JsonObject = JsonSerializer.Deserialize<T>(allTextFronJson);
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
