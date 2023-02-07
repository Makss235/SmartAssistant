using System.Windows.Controls;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;

namespace SmartAssistant.Views.MainWindow.Tabs
{
    public class SettingsTab : UserControl
    {
        public SettingsTab()
        {
            TextBlock textBlock = new TextBlock()
            {
                Text = "asdfghjkl",
                FontSize = 20,
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };

            Grid grid = new Grid();
            grid.Margin = new Thickness(20, 0, 0, 0);
            grid.Children.Add(textBlock);

            Border mainBorder = new Border()
            {
                CornerRadius = new CornerRadius(0, 20, 20, 0),
                Background = MainWindow.BackgroundDarkBrush,
                Margin = new Thickness(0, 0, 0, 0),
                Width = 555,
                Height = 500
            };
            mainBorder.Child = grid;
            Content = mainBorder;
        }
    }
}
