using System.Windows.Controls;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Shapes;

namespace SmartAssistant.UserControls.MainWindow
{
    public class MenuButtonUC : UserControl
    {
        public MenuButtonUC()
        {
            TextBlock textBlock = new TextBlock()
            {
                Text = "Главная",
                Width = 175,
                Height = 100
            };

            StackPanel stackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            stackPanel.Children.Add(textBlock);

            Button button = new Button() { Height = 45 };
            IAddChild addChild = button;
            addChild.AddChild(stackPanel);

            Path path = new Path()
            {
                Fill = Windows.MainWindow.MainWindow.BackgroundLightBrush,
                Stretch = System.Windows.Media.Stretch.Fill
            };

            Grid grid = new Grid()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Width = 20, 
                Height = 85,
                Visibility = Visibility.Visible
            };
            grid.Children.Add(path);

            Grid mainGrid = new Grid()
            {
                Margin = new Thickness(0, -17, 0, -17),
                Width = 200
            };
            mainGrid.Children.Add(button);
            mainGrid.Children.Add(grid);
            Content = mainGrid;
        }
    }
}
