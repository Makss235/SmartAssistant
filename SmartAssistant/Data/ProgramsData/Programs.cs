using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace SmartAssistant.Data.ProgramsData
{
    public static class Programs
    {
        private static string language;
        private static string jsonsDirectory;
        private static string fileName;
        private static string fullPathFileName;

        public static List<ProgramObj> ProgramObjs { get; set; }

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
            ProgramObjs = JsonSerializer.Deserialize<List<ProgramObj>>(allTextFronJson);
        }

        public static async void Serialize(List<ProgramObj> programObjs = null)
        {
            File.WriteAllText(fullPathFileName, string.Empty);
            using (FileStream fs = new FileStream(fullPathFileName, FileMode.OpenOrCreate))
            {
                var options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                };

                if (programObjs == null)
                {
                    if (ProgramObjs != null)
                        programObjs = ProgramObjs;
                    else
                        throw new Exception();
                }
                await JsonSerializer.SerializeAsync(fs, programObjs, options);
            }
        }
    }
}
