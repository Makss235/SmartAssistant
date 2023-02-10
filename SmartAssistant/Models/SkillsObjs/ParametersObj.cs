using System.Collections.Generic;

namespace SmartAssistant.Models.SkillsObjs
{
    public class ParametersObj
    {
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public List<string> Args { get; set; }
    }
}
