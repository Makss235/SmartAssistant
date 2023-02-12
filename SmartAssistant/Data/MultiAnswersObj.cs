using System.Collections.Generic;

namespace SmartAssistant.Data
{
    public class MultiAnswersObj
    {
        public List<string> Positive { get; set; }
        public List<string> Negative { get; set; }
        public List<string> NoDefined { get; set; }
    }
}
