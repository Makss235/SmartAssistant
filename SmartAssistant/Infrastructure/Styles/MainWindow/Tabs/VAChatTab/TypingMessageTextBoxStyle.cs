using SmartAssistant.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.VAChatTab
{
    public class TypingMessageTextBoxStyle : Style
    {
        public TypingMessageTextBoxStyle(double Width)
        {
            const double TextBoxFontSize = 16;
            const double TextBoxHeight = 50;
            double TextBoxWidth = Width - 120;

            Setters.Add(new Setter(Control.BackgroundProperty, BasicColors.TransparentBrush));
            Setters.Add(new Setter(Control.BorderBrushProperty, BasicColors.TransparentBrush));
            Setters.Add(new Setter(Control.BorderThicknessProperty, new Thickness(0)));
            Setters.Add(new Setter(Control.VerticalContentAlignmentProperty, VerticalAlignment.Center));
            Setters.Add(new Setter(TextBox.TextWrappingProperty, TextWrapping.Wrap));
            Setters.Add(new Setter(Control.PaddingProperty, new Thickness(15, 0, 15, 4)));
            Setters.Add(new Setter(Control.FontSizeProperty, TextBoxFontSize));
            Setters.Add(new Setter(FrameworkElement.HeightProperty, TextBoxHeight));
            Setters.Add(new Setter(FrameworkElement.WidthProperty, TextBoxWidth));
            Setters.Add(new Setter(Control.FontFamilyProperty, new FontFamily("Segoe UI Semibold")));
        }
    }
}
