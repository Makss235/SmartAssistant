using SmartAssistant.Data.Base;
using System.Collections.Generic;

namespace SmartAssistant.Data.ProgramsData
{
    public class Programs : BaseData<List<ProgramObj>>
    {
        public Programs() : base("ru", "Programs") { }
    }
}
