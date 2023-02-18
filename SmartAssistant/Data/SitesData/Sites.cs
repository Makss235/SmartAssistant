using SmartAssistant.Data.Base;
using SmartAssistant.Data.SettingsData;
using System.Collections.Generic;

namespace SmartAssistant.Data.SitesData
{
    public class Sites : BaseData<List<SiteObj>>
    {
        public Sites() : base(Settings.JsonObject.Language, "Sites") { }
    }
}
