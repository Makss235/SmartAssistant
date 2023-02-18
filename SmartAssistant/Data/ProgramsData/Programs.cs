using SmartAssistant.Data.Base;
using SmartAssistant.Data.SettingsData;
using System.Collections.Generic;

namespace SmartAssistant.Data.ProgramsData
{
    public class Programs : BaseData<List<ProgramObj>>
    {
        public Programs() : base(Settings.JsonObject.Language, "Programs") { }
    }
}
