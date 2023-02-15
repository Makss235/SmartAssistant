using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace SmartAssistant.Data.Base
{
    public class BaseData<T> where T : class
    {
        protected string resourcesDirectory;
        protected string fullPathFileName;
        protected string fullFileName;
        protected string folderName;
        protected string partFileName;
        protected string language;

        public static T JsonObject { get; set; }

        public BaseData(string language, string folderName, string partFileName = null)
        {
            this.language = language;
            this.folderName = folderName;
            if (partFileName != null) this.partFileName = partFileName;
            else this.partFileName = folderName;

            resourcesDirectory = Path.Combine(string.Format($"c:\\users\\{Environment.UserName}\\"),
                "SmartAssistant\\Resources");
            fullFileName = $"{this.partFileName}_{this.language.ToUpper()}.json";
            fullPathFileName = Path.Combine(resourcesDirectory, this.folderName, fullFileName);
        }

        public virtual void Deserialize()
        {
            string allTextFronJson = File.ReadAllText(fullPathFileName);
            JsonObject = JsonSerializer.Deserialize<T>(allTextFronJson);
        }

        public virtual async void Serialize()
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
