using SmartAssistant.UserControls.Widgets;
using System.Windows;
using System.Windows.Controls;

namespace SmartAssistant.Windows
{
    public class TestWindow : Window
    {
        public TestWindow()
        {
            SExpander sExpander = new SExpander();
            sExpander.HorizontalAlignment = HorizontalAlignment.Left;
            sExpander.VerticalAlignment = VerticalAlignment.Top;
            Content = sExpander;
        }
    }
}
