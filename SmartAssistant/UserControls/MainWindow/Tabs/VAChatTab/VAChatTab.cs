using SmartAssistant.UserControls.MainWindow.Tabs.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.UserControls.MainWindow.Tabs.VAChatTab
{
    public class VAChatTab : Tab
    {
        public VAChatTab(byte id, double width, double height, Visibility visibility)
        {
            ID = id;
            Width = width;
            Height = height;
            Visibility = visibility;

            ScrollViewer scrollViewer = new ScrollViewer()
            {
                Margin = new Thickness(0, 40, 0, 100),
            };

            TextBox typingMessageTextBox = new TextBox()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(20),
                TextWrapping = TextWrapping.Wrap,
                VerticalContentAlignment = VerticalAlignment.Center,
                Padding = new Thickness(15, 0, 15, 0),
                FontSize = 16,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                Width = Width - 150,
                Height = 50
            };

            Button sendMessageButton = new Button()
            {
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 50,
                Width = 50,
                Margin = new Thickness(20, 20, 30, 20),
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(1)
            };

            Grid mainGrid = new Grid()
            {
                Margin = new Thickness(20, 0, 0, 0)
            };
            mainGrid.Children.Add(scrollViewer);
            mainGrid.Children.Add(typingMessageTextBox);
            mainGrid.Children.Add(sendMessageButton);

            Border mainBorder = new Border()
            {
                Background = new SolidColorBrush(Colors.Transparent)
            };
            mainBorder.Child = mainGrid;
            Content = mainBorder;
        }
    }
}
