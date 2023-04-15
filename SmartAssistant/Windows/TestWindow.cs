using SmartAssistant.Data.ProgramsData;
using SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab;
using System.Windows;

namespace SmartAssistant.Windows
{
    public class TestWindow : Window
    {
        public TestWindow()
        {
            PE pE = new PE(Programs.JsonObject[2]);
            Content = pE;
        }
    }
}
