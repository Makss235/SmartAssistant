using SmartAssistant.UserControls.Widgets;
using System.Windows;

namespace SmartAssistant.Windows
{
    public class TestWindow : Window
    {
        public TestWindow()
        {
            SExpander sExpander = new SExpander()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                HeaderContent = "jjjjjjjjjjjjj",
                BodyContent = "djfbkjdf"
            };
            Content = sExpander;
        }
    }
}
