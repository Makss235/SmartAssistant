using SmartAssistant.UserControls.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.UserControls.AddPEWindow.Tabs.AddCallingNamesTab
{
    public class AddCallingNamesTab : Tab
    {
        public AddCallingNamesTab(byte id, double width, double height, Visibility visibility)
        {
            ID = id;
            Width = width;
            Height = height;
            Visibility = visibility;

            Grid mainGrid = new Grid();

            ColumnDefinition headingMenuColumnDefinition = new ColumnDefinition()
            { Width = new GridLength(200, GridUnitType.Pixel) };
            mainGrid.ColumnDefinitions.Add(headingMenuColumnDefinition);

            ColumnDefinition headingMenuColumnDefinition1 = new ColumnDefinition()
            { Width = new GridLength(300, GridUnitType.Pixel) };
            mainGrid.ColumnDefinitions.Add(headingMenuColumnDefinition1);

            ListBox listBox = new ListBox()
            {
                Margin = new Thickness(20, 10, 10, 28),
            };
            Grid.SetColumn(listBox, 0);

            Grid grid = new Grid();
            Grid.SetColumn(grid, 1);

            RowDefinition menuButtonsRowDefinition = new RowDefinition()
            { Height = new GridLength(85, GridUnitType.Pixel) };
            grid.RowDefinitions.Add(menuButtonsRowDefinition);

            RowDefinition mainFieldRowDefinition = new RowDefinition()
            { Height = new GridLength(175, GridUnitType.Pixel) };
            grid.RowDefinitions.Add(mainFieldRowDefinition);

            TextBlock textBlock = new TextBlock()
            {
                Text = "Введите, как будете\nзвать программу:",
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 10, 20, 0),
                FontSize = 15,
                FontFamily = new FontFamily("Segoe UI Semibold")
            };
            Grid.SetRow(textBlock, 0);
            grid.Children.Add(textBlock);

            Button button = new Button()
            {
                Content = "+",
                Margin = new Thickness(10, 5, 28, 20),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Right,
                Width = 60,
                Height = 60,
                Background = Application.Current.Resources["Transparent"] as SolidColorBrush,
                BorderThickness = new Thickness(0)
            };

            TextBox textBox2 = new TextBox()
            {
                // TODO: Makss привязка ширины к глобальной
                Margin = new Thickness(10, 5, 20, 20),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Width = 260,
                VerticalContentAlignment = VerticalAlignment.Center,
                Height = 60,
                Padding = new Thickness(0, 0, 60, 0),
                TextWrapping = TextWrapping.Wrap,
                FontSize = 15, 
                FontFamily = new FontFamily("Segoe UI Semibold")
            };
            Grid.SetRow(textBox2, 1);
            Grid.SetRow(button, 1);
            grid.Children.Add(textBox2);
            grid.Children.Add(button);

            Button button2 = new Button()
            {
                Width = 80,
                Height = 50,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(10, 5, 28, 28),
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
                Content = "Далее",
            };
            Grid.SetRow(button2 , 1);
            Grid.SetRow(button3 , 1);
            grid.Children.Add(button2);
            grid.Children.Add(button3);

            mainGrid.Children.Add(listBox);
            mainGrid.Children.Add(grid);
            Content = mainGrid;
        }
    }
}
