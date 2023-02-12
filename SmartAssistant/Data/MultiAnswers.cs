using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace SmartAssistant.Data
{
    public static class MultiAnswers
    {
        private static string language;
        private static string jsonsDirectory;
        private static string fileName;
        private static string fullPathFileName;

        public static MultiAnswersObj MultiAnswersObj { get; set; }

        public static void Init(string Language)
        {
            language = Language;
            jsonsDirectory = Path.Combine(string.Format($"c:\\users\\{Environment.UserName}\\"),
                "SmartAssistant\\Resources\\MultiAnswers");
            fileName = $"MultiAnswers_{language.ToUpper()}.json";
            fullPathFileName = Path.Combine(jsonsDirectory, fileName);

            Deserialize();
        }

        public static void Deserialize()
        {
            string allTextFronJson = File.ReadAllText(fullPathFileName);
            MultiAnswersObj = JsonSerializer.Deserialize<MultiAnswersObj>(allTextFronJson);
        }

        public static async void Serialize(MultiAnswersObj multiAnswersObj = null)
        {
            File.WriteAllText(fullPathFileName, string.Empty);
            using (FileStream fs = new FileStream(fullPathFileName, FileMode.OpenOrCreate))
            {
                var options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                };

                if (multiAnswersObj == null)
                {
                    if (MultiAnswersObj != null)
                        multiAnswersObj = MultiAnswersObj;
                    else
                        throw new Exception();
                }
                await JsonSerializer.SerializeAsync(fs, multiAnswersObj, options);
            }
        }
    }
}
