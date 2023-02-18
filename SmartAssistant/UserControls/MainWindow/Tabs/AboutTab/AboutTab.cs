using SmartAssistant.UserControls.MainWindow.Tabs.Base;
using System.Windows;

namespace SmartAssistant.UserControls.MainWindow.Tabs.AboutTab
{
    public class AboutTab : Tab
    {
        public AboutTab(byte id, double width, double height, Visibility visibility)
        {
            ID = id;
            Width = width;
            Height = height;
            Visibility = visibility;
        }
    }
}
