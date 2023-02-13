using SmartAssistant.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant
{
    public class TypingChatMessageBorderStyle : Style
    {
        public TypingChatMessageBorderStyle(double Width) 
        {
            const double BorderHeight = 50;
            double BorderWidth = Width - 120;

            Trigger MouseOverTrigger = new Trigger
            {
                Property = Border.IsMouseOverProperty,
                Value = true
            };
            MouseOverTrigger.Setters.Add(new Setter(Border.BorderBrushProperty, BasicColors.BackgroundDarkBrush));

            Triggers.Add(MouseOverTrigger);
            Setters.Add(new Setter(Border.BackgroundProperty, Brushes.Transparent));
            Setters.Add(new Setter(Border.BorderBrushProperty, BasicColors.BackgroundMediumBrush));
            Setters.Add(new Setter(Border.BorderThicknessProperty, new Thickness(2)));
            Setters.Add(new Setter(Border.HorizontalAlignmentProperty, HorizontalAlignment.Left));
            Setters.Add(new Setter(Border.VerticalAlignmentProperty, VerticalAlignment.Bottom));
            Setters.Add(new Setter(Border.MarginProperty, new Thickness(20)));
            Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(20)));
            Setters.Add(new Setter(Border.HeightProperty, BorderHeight));
            Setters.Add(new Setter(Border.WidthProperty, BorderWidth));
        }
    }
}
