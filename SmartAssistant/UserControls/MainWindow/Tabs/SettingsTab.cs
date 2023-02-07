using System.Windows.Controls;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;

namespace SmartAssistant.UserControls.MainWindow.Tabs
{
    public class SettingsTab : UserControl
    {
        public SettingsTab()
        {
            Grid mainGrid = new Grid();
            mainGrid.Margin = new Thickness(20, 0, 0, 0);

            Border mainBorder = new Border()
            {
                Background = new SolidColorBrush(Colors.Transparent),
                Width = 555,
                Height = 500
            };
            mainBorder.Child = mainGrid;
            Content = mainBorder;
        }
    }
}
