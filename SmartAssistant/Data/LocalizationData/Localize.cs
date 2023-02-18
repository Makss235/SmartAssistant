using SmartAssistant.Data.Base;
using SmartAssistant.Data.SettingsData;

namespace SmartAssistant.Data.LocalizationData
{
    public class Localize : BaseData<LocObj>
    {
        public Localize() : base(Settings.JsonObject.Language, "Localization", "Loc") { }
        public override void Serialize() { }
    }
}
