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

            Grid mainGrid = new Grid();

            RowDefinition menuButtonsRowDefinition = new RowDefinition()
            { Height = new GridLength(85, GridUnitType.Pixel) };
            mainGrid.RowDefinitions.Add(menuButtonsRowDefinition);

            RowDefinition mainFieldRowDefinition = new RowDefinition()
            { Height = new GridLength(175, GridUnitType.Pixel) };
            mainGrid.RowDefinitions.Add(mainFieldRowDefinition);

            // TODO: Makss localize
            TextBlock textBlock = new TextBlock()
            {
                Text = "Название программы:",
                FontSize = 15,
                Margin = new Thickness(30, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                ToolTip = new ToolTip() { Content = "Введите название программы\nлатиницей и без спец. символов" }
            };
            Grid.SetRow(textBlock, 0);

            TextBox textBox = new TextBox()
            {
                Margin = new Thickness(30, 10, 0, 0),
                BorderThickness = new Thickness(0, 0, 0, 3),
                BorderBrush = Application.Current.Resources["BackgroundDarkBrush"] as SolidColorBrush,
                FontSize = 15,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                Width = 300,
                MaxHeight = 60,
                Padding = new Thickness(0, 0, 0, 2),
                VerticalContentAlignment = VerticalAlignment.Bottom,
                TextWrapping = TextWrapping.Wrap,
                Background = Application.Current.Resources["BackgroundLightBrush"] as SolidColorBrush,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            Grid.SetRow(textBox, 1);

            mainGrid.Children.Add(textBlock);
            mainGrid.Children.Add(textBox);
            Content = mainGrid;
        }
    }
}
