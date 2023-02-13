using System.Collections.Generic;

namespace SmartAssistant.Data.ProgramsData
{
    public class ProgramObj
    {
        public string Name { get; set; }
        public List<string> CallingNames { get; set; }
        public string Path { get; set; }
    }
}
