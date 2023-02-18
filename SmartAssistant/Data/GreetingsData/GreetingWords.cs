using SmartAssistant.Data.Base;
using SmartAssistant.Data.SettingsData;
using System.Collections.Generic;

namespace SmartAssistant.Data.GreetingsData
{
    public class GreetingWords : BaseData<List<string>>
    {
        public GreetingWords() : base(Settings.JsonObject.Language, "Greetings") { }
    }
}
