using SmartAssistant.Data.Base;
using System.Collections.Generic;

namespace SmartAssistant.Data.SitesData
{
    public class Sites : BaseData<List<SiteObj>>
    {
        public Sites() : base("ru", "Sites") { }
    }
}
