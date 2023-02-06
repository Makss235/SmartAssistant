using System.Windows.Controls;
using System.Windows;
using System.Windows.Markup;

namespace SmartAssistant.Views.MainWindow.Tabs
{
    public class Settings_Tab : UserControl
    {
        public Settings_Tab()
        {
            TextBlock textBlock = new TextBlock()
            {
                Text = "gggggggggggggggggggggggggg",
                FontSize = 20,
                Foreground = MainWindow.BackgroundLightBrush
            };

            Grid grid = new Grid();
            grid.Children.Add(textBlock);
            grid.Margin = new Thickness(20, 0, 0, 0);

            Border mainBorder = new Border()
            {
                CornerRadius = new CornerRadius(0, 20, 20, 0),
                Background = MainWindow.BackgroundDarkBrush,
                Margin = new Thickness(-25, 0, 0, 0),
                Height = 500,
                Width = 535
            };
            mainBorder.Child = grid;
        }
    }
}
