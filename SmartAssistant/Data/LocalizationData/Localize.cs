using SmartAssistant.Data.Base;

namespace SmartAssistant.Data.LocalizationData
{
    public class Localize : BaseData<LocObj>
    {
        public Localize() : base("ru", "Localization", "Loc") { }
        public override void Serialize() { }
    }
}
