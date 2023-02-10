using System.Text.Json;
using System;
using System.IO;
using System.Collections.Generic;

namespace SmartAssistant.Data.Localization
{
    public static class Localize
    {
        private static string language;
        private static string localizationDirectory;
        private static string fileName;
        private static string fullPathFileName;

        public static LocObj LocObj { get; private set; }

        public static void Init(string Language)
        {
            language = Language;
            localizationDirectory = Path.Combine(string.Format($"c:\\users\\{Environment.UserName}\\"),
                "SmartAssistant\\Resources\\Localization");
            fileName = $"Loc_{language.ToUpper()}.json";
            fullPathFileName = Path.Combine(localizationDirectory, fileName);
        }

        public static void Deserialize()
        {
            string allTextFronJson = File.ReadAllText(fullPathFileName);
            LocObj = JsonSerializer.Deserialize<LocObj>(allTextFronJson);
        }
    }
}
