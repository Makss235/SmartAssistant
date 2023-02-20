using SmartAssistant.UserControls.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.UserControls.AddPEWindow.Tabs.AddNameTab
{
    public class AddNameTab : Tab
    {
        public AddNameTab(byte id, double width, double height, Visibility visibility)
        {
            ID = id;
            Width = width;
            Height = height;
            Visibility = visibility;

            // TODO: Makss localize
            TextBlock textBlock = new TextBlock()
            {
                Text = "Название программы:",
                FontSize = 15,
                Margin = new Thickness(30, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center,
                FontFamily = new FontFamily("Segoe UI Semibold")
            };

            TextBox textBox = new TextBox()
            {
                Margin = new Thickness(100, 10, 0, 0),
                BorderThickness = new Thickness(0, 0, 0, 3),
                BorderBrush = Application.Current.Resources["BackgroundMediumBrush"] as SolidColorBrush,
                FontSize = 15,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                Width = 300,
                MaxHeight = 100,
                VerticalContentAlignment = VerticalAlignment.Bottom,
                TextWrapping = TextWrapping.Wrap,
                Background = Application.Current.Resources["BackgroundLightBrush"] as SolidColorBrush
            };

            StackPanel stackPanel = new StackPanel()
            { 
                Orientation = Orientation.Vertical,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(textBox);

            Grid mainGrid = new Grid();
            mainGrid.Children.Add(stackPanel);
            Content = mainGrid;
        }
    }
}
