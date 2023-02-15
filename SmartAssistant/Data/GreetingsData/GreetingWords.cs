using SmartAssistant.Data.Base;
using System.Collections.Generic;

namespace SmartAssistant.Data.GreetingsData
{
    public class GreetingWords : BaseData<List<string>>
    {
        public GreetingWords() : base("ru", "Greetings") { }
    }
}
