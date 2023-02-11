using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartAssistant.Data
{
    public static class Words
    {
        private static string language;
        private static string jsonsDirectory;
        private static string fileName;
        private static string fullPathFileName;

        public static List<WordsObj> WordsObjs { get; set; }

        public static void Init(string Language)
        {
            language = Language;
            jsonsDirectory = Path.Combine(string.Format($"c:\\users\\{Environment.UserName}\\"),
                "SmartAssistant\\Resources\\Words");
            fileName = $"Words_{language.ToUpper()}.json";
            fullPathFileName = Path.Combine(jsonsDirectory, fileName);

            Deserialize();
        }

        public static void Deserialize()
        {
            string allTextFronJson = File.ReadAllText(fullPathFileName);
            WordsObjs = JsonSerializer.Deserialize<List<WordsObj>>(allTextFronJson);
        }

        public static async void Serialize(List<WordsObj> wordsObjs = null)
        {
            File.WriteAllText(fullPathFileName, string.Empty);
            using (FileStream fs = new FileStream(fullPathFileName, FileMode.OpenOrCreate))
            {
                var options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                };

                if (wordsObjs == null)
                {
                    if (WordsObjs != null)
                        wordsObjs = WordsObjs;
                    else
                        throw new Exception();
                }
                await JsonSerializer.SerializeAsync(fs, wordsObjs, options);
            }
        }
    }
}
