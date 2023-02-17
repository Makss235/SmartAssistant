using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.VAChatTab
{
    public class MessageChatStyle : Style
    {
        public MessageChatStyle(SolidColorBrush messageBackground,
                                SolidColorBrush messageForeground,
                                string message)
        {
            FrameworkElementFactory messageTextBoxFactory = new FrameworkElementFactory(typeof(TextBox));
            messageTextBoxFactory.SetValue(TextBox.BackgroundProperty, Application.Current.Resources["Transparent"]);
            messageTextBoxFactory.SetValue(TextBox.ForegroundProperty, messageForeground);
            messageTextBoxFactory.SetValue(TextBox.BorderThicknessProperty, new Thickness(0));
            messageTextBoxFactory.SetValue(TextBox.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            messageTextBoxFactory.SetValue(TextBox.VerticalContentAlignmentProperty, VerticalAlignment.Center);
            messageTextBoxFactory.SetValue(TextBox.MarginProperty, new Thickness(8, 5, 8, 5));
            messageTextBoxFactory.SetValue(TextBox.IsEnabledProperty, false);
            messageTextBoxFactory.SetValue(TextBox.TextWrappingProperty, TextWrapping.Wrap);
            messageTextBoxFactory.SetValue(TextBox.FontSizeProperty, 18);
            messageTextBoxFactory.SetValue(TextBox.FontFamilyProperty, new FontFamily("Segoe UI Semibold"));
            messageTextBoxFactory.SetValue(TextBox.TextProperty, message);
            messageTextBoxFactory.SetValue(TextBox.MinHeightProperty, 35);

            TargetType = typeof(Border);
            Setters.Add(new Setter(Border.BackgroundProperty, messageBackground));
            Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(10)));
            Setters.Add(new Setter(Border.BorderBrushProperty, Application.Current.Resources["ButtonMouseOverBrush"]));
            Setters.Add(new Setter(Border.BorderThicknessProperty, new Thickness(2)));
            Setters.Add(new Setter(Border.MinHeightProperty, 13));
            Setters.Add(new Setter(Border.MaxWidthProperty, 450));
            Setters.Add(new Setter(Border.RenderTransformOriginProperty, new Point(1, 1)));
        }
    }
}
