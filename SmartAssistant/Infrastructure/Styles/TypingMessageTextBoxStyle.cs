using SmartAssistant.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant
{
    public class TypingMessageTextBoxStyle : Style
    {
        public TypingMessageTextBoxStyle(double Width)
        {
            const double TextBoxFontSize = 16;
            const double TextBoxHeight = 50;
            double TextBoxWidth = Width - 150;

            Setters.Add(new Setter(TextBox.BackgroundProperty, BasicColors.TransparentBrush));
            Setters.Add(new Setter(TextBox.BorderBrushProperty, BasicColors.TransparentBrush));
            Setters.Add(new Setter(TextBox.BorderThicknessProperty, new Thickness(0)));
            Setters.Add(new Setter(TextBox.VerticalContentAlignmentProperty, VerticalAlignment.Center));
            Setters.Add(new Setter(TextBox.TextWrappingProperty, TextWrapping.Wrap));
            Setters.Add(new Setter(TextBox.PaddingProperty, new Thickness(15, 0, 15, 4)));
            Setters.Add(new Setter(TextBox.FontSizeProperty, TextBoxFontSize));
            Setters.Add(new Setter(TextBox.HeightProperty, TextBoxHeight));
            Setters.Add(new Setter(TextBox.WidthProperty, TextBoxWidth));
            Setters.Add(new Setter(TextBox.FontFamilyProperty, new FontFamily("Segoe UI Semibold")));
        }
    }
}
