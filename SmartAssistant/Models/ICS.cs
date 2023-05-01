using SmartAssistant.Data.WordsData;

namespace SmartAssistant.Models
{
    public struct ICS
    {
        public string Text { get; set; }
        public WordsObj WordsObj { get; set; }

        public ICS()
        {
            Text = string.Empty;
            WordsObj = new WordsObj();
        }
    }
}
