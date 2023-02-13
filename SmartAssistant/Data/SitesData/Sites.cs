﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace SmartAssistant.Data.SitesData
{
    public static class Sites
    {
        private static string language;
        private static string jsonsDirectory;
        private static string fileName;
        private static string fullPathFileName;

        public static List<SiteObj> SiteObjs { get; set; }

        public static void Init(string Language)
        {
            language = Language;
            jsonsDirectory = Path.Combine(string.Format($"c:\\users\\{Environment.UserName}\\"),
                "SmartAssistant\\Resources\\Sites");
            fileName = $"Sites_{language.ToUpper()}.json";
            fullPathFileName = Path.Combine(jsonsDirectory, fileName);

            Deserialize();
        }

        public static void Deserialize()
        {
            string allTextFronJson = File.ReadAllText(fullPathFileName);
            SiteObjs = JsonSerializer.Deserialize<List<SiteObj>>(allTextFronJson);
        }

        public static async void Serialize(List<SiteObj> siteObjs = null)
        {
            File.WriteAllText(fullPathFileName, string.Empty);
            using (FileStream fs = new FileStream(fullPathFileName, FileMode.OpenOrCreate))
            {
                var options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                };

                if (siteObjs == null)
                {
                    if (SiteObjs != null)
                        siteObjs = SiteObjs;
                    else
                        throw new Exception();
                }
                await JsonSerializer.SerializeAsync(fs, siteObjs, options);
            }
        }
    }
}