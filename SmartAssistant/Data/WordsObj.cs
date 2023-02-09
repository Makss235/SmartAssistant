using System.Collections.Generic;

namespace SmartAssistant.Data
{
    public class WordsObj
    {
        public Dictionary<string, Dictionary<string, string>> DataDictionaries { get; set; }
        public Dictionary<string, object> Data { get; set; }
    }
}
