using SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.VAChatTab;
using SmartAssistant.Resources;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using static SmartAssistant.UserControls.MainWindow.Tabs.VAChatTab.VAChatTab;

namespace SmartAssistant.UserControls.MainWindow.Tabs.VAChatTab
{
    public class MessageChat : TextBox
    {
        private SendMessageBy sendMessageBy;

        public string Message { get; set; }
        public HorizontalAlignment MessageAlignment { get; set; }
        public SolidColorBrush MessageBackground { get; set; }
        public SolidColorBrush MessageForeground { get; set; }
        public SolidColorBrush MessageBorderBrush { get; set; }
        Storyboard sb;

        public MessageChat(string message, SendMessageBy sendMessageBy)
        {
            Message = message;
            this.sendMessageBy = sendMessageBy;

            if (sendMessageBy == SendMessageBy.ByMe)
            {
                MessageAlignment = HorizontalAlignment.Right;
                MessageBackground = ResApp.GetResources<SolidColorBrush>("CommonMediumBrush");
                MessageForeground = ResApp.GetResources<SolidColorBrush>("CommonLightBrush");
                MessageBorderBrush = ResApp.GetResources<SolidColorBrush>("Transparent");
            }
            else
            {
                MessageAlignment = HorizontalAlignment.Left;
                MessageBackground = ResApp.GetResources<SolidColorBrush>("FadedBrush");
                MessageForeground = ResApp.GetResources<SolidColorBrush>("CommonDarkBrush");
                MessageBorderBrush = ResApp.GetResources<SolidColorBrush>("CommonDarkBrush");
            }

            ScaleTransform scale = new ScaleTransform(1.0, 1.0);
            RenderTransformOrigin = new Point(1.0, 1.0);
            RenderTransform = scale;

            DoubleAnimation anim = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromMilliseconds(100),
            };

            sb = new Storyboard();
            sb.Children.Add(anim);

            Storyboard.SetTargetProperty(anim, new PropertyPath("RenderTransform.ScaleY"));
            Storyboard.SetTarget(anim, this);

            Text = Message;
            Style = new MessageChatStyle(MessageBackground, MessageForeground, MessageBorderBrush, Message);
            Margin = new Thickness(0, 5, 1, 0);
            HorizontalAlignment = MessageAlignment;
            Loaded += animstart;
        }

        private void animstart(Object sender, RoutedEventArgs e)
        {
            sb.Begin();
        }
    }
}
