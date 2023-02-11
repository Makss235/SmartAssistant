using SmartAssistant.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.UserControls.MainWindow.Tabs.VAChatTab
{
    public class MessageChat : Border
    {
        public HorizontalAlignment MessageAlignment { get; set; }
        public string Message { get; set; }

        public MessageChat(HorizontalAlignment messageAlignment, string message)
        {
            MessageAlignment = messageAlignment;
            Message = message;

            TextBox messageTextBlock = new TextBox()
            {
                Text = Message,
                Foreground = new SolidColorBrush(Colors.White),
                TextWrapping = TextWrapping.Wrap,
                IsEnabled = false,
                FontSize = 18,
                Margin = new Thickness(3),
                VerticalContentAlignment = VerticalAlignment.Center,
                Background = new SolidColorBrush(Colors.Transparent),
                MinHeight = 35,
                HorizontalAlignment = HorizontalAlignment.Center,
                BorderThickness = new Thickness(0)
            };
            Background = BasicColors.BackgroundMediumBrush;
            CornerRadius = new CornerRadius(10);
            MinWidth = 15;
            MaxWidth = 300;
            Margin = new Thickness(0, 5, 1, 0);
            HorizontalAlignment = MessageAlignment;
            RenderTransformOrigin = new Point(1, 1);
            Child = messageTextBlock;
        }
    }
}
