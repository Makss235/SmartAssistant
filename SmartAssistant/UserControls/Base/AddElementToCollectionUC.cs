using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.UserControls.Base
{
    public class AddElementToCollectionUC : UserControl
    {
        public AddElementToCollectionUC(double width, double height)
        {
            Width = width;
            Height = height;
            TextBox textBox = new TextBox()
            {
                Background = Application.Current.Resources["BackgroundMediumBrush"] as SolidColorBrush,
                BorderThickness = new Thickness(0),
                Width = this.Width - this.Height,
                FontSize = 15,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                TextWrapping = TextWrapping.Wrap,
            };

            Button button = new Button()
            {
                Background = Application.Current.Resources["Transparent"] as SolidColorBrush,
                BorderThickness = new Thickness(0),
                Width = Height,
                Height = Height,
                Content = "+",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Right,
            };

            Grid grid = new Grid()
            {
                Width = Width,
            };
            grid.Children.Add(button);
            grid.Children.Add(textBox);

            Border mainBorder = new Border()
            {
                Height = Height,
                Width = Width,
                BorderBrush = Application.Current.Resources["BackgroundMediumBrush"] as SolidColorBrush,
                Background = Application.Current.Resources["BackgroundLightBrush"] as SolidColorBrush,
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(10)
            };
            mainBorder.Child = grid;
            Content = mainBorder;
        }
    }
}
