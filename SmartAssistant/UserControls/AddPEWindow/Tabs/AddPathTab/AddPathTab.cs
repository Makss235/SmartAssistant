using SmartAssistant.UserControls.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.UserControls.AddPEWindow.Tabs.AddPathTab
{
    public class AddPathTab : Tab
    {
        public AddPathTab(byte id, double width, double height, Visibility visibility)
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
                Text = "Путь программы:",
                FontSize = 15,
                Margin = new Thickness(50, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                ToolTip = new ToolTip() { Content = "Введите абсолютный путь\nдо exe-файла программы" }
            };
            Grid.SetRow(textBlock, 0);

            TextBox textBox = new TextBox()
            {
                Margin = new Thickness(50, 10, 0, 0),
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

            Button button2 = new Button()
            {
                Width = 80,
                Height = 50,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(20, 5, 28, 28),
                HorizontalAlignment = HorizontalAlignment.Left,
                Content = "Назад",
            };
            Button button3 = new Button()
            {
                Width = 80,
                Height = 50,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(10, 5, 28, 28),
                HorizontalAlignment = HorizontalAlignment.Right,
                Content = "Готово",
            };
            Grid.SetRow(button2, 1);
            Grid.SetRow(button3, 1);
            mainGrid.Children.Add(button2);
            mainGrid.Children.Add(button3);

            mainGrid.Children.Add(textBlock);
            mainGrid.Children.Add(textBox);

            Content = mainGrid;
        }
    }
}
