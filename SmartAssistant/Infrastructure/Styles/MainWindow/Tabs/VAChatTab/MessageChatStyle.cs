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
            FrameworkElementFactory contentPresenterFactory = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterFactory.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
            contentPresenterFactory.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);

            FrameworkElementFactory messageTextBoxFactory = new FrameworkElementFactory(typeof(Border));
            messageTextBoxFactory.SetValue(Border.BackgroundProperty, messageBackground);
            messageTextBoxFactory.SetValue(Border.CornerRadiusProperty, new CornerRadius(10));
            messageTextBoxFactory.SetValue(Border.BorderBrushProperty, Application.Current.Resources["ButtonMouseOverBrush"]);
            messageTextBoxFactory.SetValue(Border.BorderThicknessProperty, new Thickness(2));
            messageTextBoxFactory.SetValue(Border.MinWidthProperty, (double)15);
            messageTextBoxFactory.SetValue(Border.MaxWidthProperty, (double)450);
            messageTextBoxFactory.SetValue(Border.RenderTransformOriginProperty, new Point(1, 1));
            messageTextBoxFactory.AppendChild(contentPresenterFactory);

            TargetType = typeof(TextBox);
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
