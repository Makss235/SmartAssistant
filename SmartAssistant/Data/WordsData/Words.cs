using SmartAssistant.Data.Base;
using SmartAssistant.Data.SettingsData;
using System.Collections.Generic;

namespace SmartAssistant.Data.WordsData
{
    public class Words : BaseData<List<WordsObj>>
    {
        public Words() : base(Settings.JsonObject.Language, "Words") { }
    }
}
