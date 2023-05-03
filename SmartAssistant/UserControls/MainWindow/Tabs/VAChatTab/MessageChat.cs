using SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.VAChatTab;
using SmartAssistant.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static SmartAssistant.UserControls.MainWindow.Tabs.VAChatTab.VAChatTab;

namespace SmartAssistant.UserControls.MainWindow.Tabs.VAChatTab
{
    public class MessageChat : UserControl
    {
        private SendMessageBy sendMessageBy;

        public string Message { get; set; }
        public HorizontalAlignment MessageAlignment { get; set; }
        public SolidColorBrush MessageBackground { get; set; }
        public SolidColorBrush MessageForeground { get; set; }
        public SolidColorBrush MessageBorderBrush { get; set; }

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

            ContentPresenter contentPresenter = new ContentPresenter();
            contentPresenter.Content = Message;

            Content = contentPresenter;
            Style = new MessageChatStyle(MessageBackground, MessageForeground, MessageBorderBrush, Message);
            Margin = new Thickness(0, 5, 1, 0);
            HorizontalAlignment = MessageAlignment;
            //Loaded += new GrowMessageAnimation(this).growAnimationStart;
        }

        public MessageChat(object message, SendMessageBy sendMessageBy)
        {
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

            //ContentPresenter contentPresenter = new ContentPresenter();
            //contentPresenter.Content = message;

            Content = message;
            //Style = new MessageChatStyle(MessageBackground, MessageForeground, MessageBorderBrush, Message);
            Margin = new Thickness(0, 5, 1, 0);
            HorizontalAlignment = MessageAlignment;
            
            //Loaded += new GrowMessageAnimation(this).growAnimationStart;
        }
    }
}
