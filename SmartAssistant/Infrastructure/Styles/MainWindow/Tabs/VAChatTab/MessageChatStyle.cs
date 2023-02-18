using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SmartAssistant.Windows;

namespace SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.VAChatTab
{
    public class MessageChatStyle : Style
    {
        public MessageChatStyle(SolidColorBrush messageBackground,
                                SolidColorBrush messageForeground,
                                string message)
        {
            FrameworkElementFactory textBoxFactory = new FrameworkElementFactory(typeof(TextBox));
            textBoxFactory.SetValue(TextBox.BorderThicknessProperty, new Thickness(0));
            textBoxFactory.SetValue(TextBox.BackgroundProperty, BasicColors.TransparentBrush);
            textBoxFactory.SetValue(TextBox.TextProperty, message);
            textBoxFactory.SetValue(TextBox.MarginProperty, new Thickness(5, 5, 5, 7));

            FrameworkElementFactory messageTextBoxFactory = new FrameworkElementFactory(typeof(Border));
            messageTextBoxFactory.SetValue(Border.BackgroundProperty, messageBackground);
            messageTextBoxFactory.SetValue(Border.CornerRadiusProperty, new CornerRadius(10));
            messageTextBoxFactory.SetValue(Border.BorderBrushProperty, Application.Current.Resources["ButtonMouseOverBrush"]);
            messageTextBoxFactory.SetValue(Border.BorderThicknessProperty, new Thickness(2));
            messageTextBoxFactory.SetValue(Border.MinWidthProperty, (double)15);
            messageTextBoxFactory.SetValue(Border.MaxWidthProperty, (double)450);
            messageTextBoxFactory.SetValue(Border.RenderTransformOriginProperty, new Point(1, 1));
            messageTextBoxFactory.AppendChild(textBoxFactory);

            Trigger isEnabledTrigger = new Trigger
            {
                Property = TextBox.IsEnabledProperty,
                Value = false
            };
            isEnabledTrigger.Setters.Add(new Setter(TextBox.OpacityProperty, (double)1));

            TargetType = typeof(TextBox);
            Triggers.Add(isEnabledTrigger);
            Setters.Add(new Setter(TextBox.BackgroundProperty, Application.Current.Resources["Transparent"]));
            Setters.Add(new Setter(TextBox.ForegroundProperty, messageForeground));
            Setters.Add(new Setter(TextBox.BorderThicknessProperty, new Thickness(0)));
            Setters.Add(new Setter(TextBox.MarginProperty, new Thickness(8, 5, 8, 5)));
            Setters.Add(new Setter(TextBox.IsEnabledProperty, false));
            Setters.Add(new Setter(TextBox.TextWrappingProperty, TextWrapping.Wrap));
            Setters.Add(new Setter(TextBox.FontSizeProperty, (double)18));
            Setters.Add(new Setter(TextBox.FontFamilyProperty, new FontFamily("Segoe UI Semibold")));
            Setters.Add(new Setter(TextBox.MinHeightProperty, (double)35));
            Setters.Add(new Setter(TextBox.TemplateProperty, new ControlTemplate()
            {
                VisualTree = messageTextBoxFactory
            }));
        }
    }
}
