using SmartAssistant.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.VAChatTab
{
    public class TypingChatMessageBorderStyle : Style
    {
        public TypingChatMessageBorderStyle(double Width)
        {
            const double BorderHeight = 50;
            double BorderWidth = Width - 120;

            Trigger MouseOverTrigger = new Trigger
            {
                Property = UIElement.IsMouseOverProperty,
                Value = true
            };
            MouseOverTrigger.Setters.Add(new Setter(Border.BorderBrushProperty, Application.Current.Resources["BackgroundDarkBrush"] as SolidColorBrush));

            Triggers.Add(MouseOverTrigger);
            Setters.Add(new Setter(Border.BackgroundProperty, Brushes.Transparent));
            Setters.Add(new Setter(Border.BorderBrushProperty, Application.Current.Resources["BackgroundMediumBrush"] as SolidColorBrush));
            Setters.Add(new Setter(Border.BorderThicknessProperty, new Thickness(2)));
            Setters.Add(new Setter(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Left));
            Setters.Add(new Setter(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Bottom));
            Setters.Add(new Setter(FrameworkElement.MarginProperty, new Thickness(20)));
            Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(20)));
            Setters.Add(new Setter(FrameworkElement.HeightProperty, BorderHeight));
            Setters.Add(new Setter(FrameworkElement.WidthProperty, BorderWidth));
        }
    }
}
