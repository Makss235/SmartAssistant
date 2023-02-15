using SmartAssistant.Data.Base;
using System.Collections.Generic;

namespace SmartAssistant.Data.TriggersData
{
    public class TriggerWords : BaseData<List<string>>
    {
        public TriggerWords() : base("ru", "Triggers") { }
    }
}
