using SmartAssistant.Data.Base;
using SmartAssistant.Data.SettingsData;
using System.Collections.Generic;

namespace SmartAssistant.Data.TriggersData
{
    public class TriggerWords : BaseData<List<string>>
    {
        public TriggerWords() : base(Settings.JsonObject.Language, "Triggers") { }
    }
}
