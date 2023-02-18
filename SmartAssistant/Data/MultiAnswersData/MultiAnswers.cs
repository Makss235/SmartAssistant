using SmartAssistant.Data.Base;
using SmartAssistant.Data.SettingsData;

namespace SmartAssistant.Data.MultiAnswersData
{
    public class MultiAnswers : BaseData<MultiAnswersObj>
    {
        public MultiAnswers() : base(Settings.JsonObject.Language, "MultiAnswers") { }
    }
}
