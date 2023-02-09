using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace SmartAssistant.Data
{
    public static class ProgramNames
    {
        private static string language;
        private static string jsonsDirectory;
        private static string fileName;
        private static string fullPathFileName;

        public static List<ProgramNamesObj> ProgramNamesObjs { get; set; }

        public static void Init(string Language)
        {
            language = Language;
            jsonsDirectory = Path.Combine(string.Format($"c:\\users\\{Environment.UserName}\\"),
                "SmartAssistant\\Resources\\Json\\ProgramNames");
            fileName = $"programNames_{language.ToLower()}.json";
            fullPathFileName = Path.Combine(jsonsDirectory, fileName);

            Deserialize();
        }

        public static void Deserialize()
        {
            string allTextFronJson = File.ReadAllText(fullPathFileName);
            ProgramNamesObjs = JsonSerializer.Deserialize<List<ProgramNamesObj>>(allTextFronJson);
        }

        public async static void Serialize(List<ProgramNamesObj> programNamesObjs = null)
        {
            File.WriteAllText(fullPathFileName, string.Empty);
            using (FileStream fs = new FileStream(fullPathFileName, FileMode.OpenOrCreate))
            {
                var options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                };

                if (programNamesObjs == null || ProgramNamesObjs.Count == 0)
                {
                    if (ProgramNamesObjs != null || ProgramNamesObjs.Count != 0)
                        programNamesObjs = ProgramNamesObjs;
                    else
                        throw new Exception();
                }
                await JsonSerializer.SerializeAsync(fs, programNamesObjs, options);
            }
        }
    }
}
