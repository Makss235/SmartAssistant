using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using SmartAssistant.Resources;
using SmartAssistant.Windows;

namespace SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.VAChatTab
{
    public class MessageChatStyle : Style
    {
        public MessageChatStyle(SolidColorBrush messageBackground,
                                SolidColorBrush messageForeground,
                                SolidColorBrush messageBorderBrush,
                                string message)
        {
            FrameworkElementFactory textBoxFactory = new FrameworkElementFactory(typeof(TextBlock));
            textBoxFactory.SetValue(TextBlock.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("Transparent"));
            textBoxFactory.SetValue(TextBlock.TextProperty, message);
            textBoxFactory.SetValue(TextBlock.MarginProperty, new Thickness(10, 5, 10, 7));
            textBoxFactory.SetValue(TextBlock.TextWrappingProperty, TextWrapping.Wrap);
            

            FrameworkElementFactory messageTextBoxFactory = new FrameworkElementFactory(typeof(Border));
            messageTextBoxFactory.SetValue(Border.BackgroundProperty, messageBackground);
            messageTextBoxFactory.SetValue(Border.CornerRadiusProperty, new CornerRadius(10));
            messageTextBoxFactory.SetValue(Border.BorderBrushProperty, messageBorderBrush);
            messageTextBoxFactory.SetValue(Border.BorderThicknessProperty, new Thickness(2));
            messageTextBoxFactory.SetValue(Border.MinWidthProperty, (double)15);
            messageTextBoxFactory.SetValue(Border.MaxWidthProperty, (double)320);
            messageTextBoxFactory.SetValue(Border.RenderTransformOriginProperty, new Point(1, 1));
            messageTextBoxFactory.AppendChild(textBoxFactory);

            TargetType = typeof(UserControl);
            Setters.Add(new Setter(UserControl.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("Transparent")));
            Setters.Add(new Setter(UserControl.ForegroundProperty, messageForeground));
            Setters.Add(new Setter(UserControl.BorderThicknessProperty, new Thickness(0)));
            Setters.Add(new Setter(UserControl.MarginProperty, new Thickness(8, 5, 8, 5)));
            //Setters.Add(new Setter(UserControl.TextWrappingProperty, TextWrapping.Wrap));
            Setters.Add(new Setter(UserControl.FontSizeProperty, (double)18));
            Setters.Add(new Setter(UserControl.FontFamilyProperty, new FontFamily("Segoe UI Semibold")));
            Setters.Add(new Setter(UserControl.MinHeightProperty, (double)35));
            Setters.Add(new Setter(UserControl.TemplateProperty, new ControlTemplate()
            {
                VisualTree = messageTextBoxFactory
            }));
        }
    }
}
