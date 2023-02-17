using SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.VAChatTab;
using SmartAssistant.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static SmartAssistant.UserControls.MainWindow.Tabs.VAChatTab.VAChatTab;

namespace SmartAssistant.UserControls.MainWindow.Tabs.VAChatTab
{
    public class MessageChat : TextBox
    {
        public HorizontalAlignment MessageAlignment { get; set; }
        public SolidColorBrush MessageBackground { get; set; }
        public SolidColorBrush MessageForeground { get; set; }
        public string Message { get; set; }

        public MessageChat(string message, SendMessageBy sendMessageBy)
        {
            if (sendMessageBy == SendMessageBy.ByMe)
            {
                MessageAlignment = HorizontalAlignment.Right;
                MessageBackground = Application.Current.Resources["BackgroundMediumBrush"] as SolidColorBrush;
                MessageForeground = Application.Current.Resources["BackgroundLightBrush"] as SolidColorBrush;
            }
            else
            {
                MessageAlignment = HorizontalAlignment.Left;
                MessageBackground = Application.Current.Resources["SelectionLightBrush"] as SolidColorBrush;
                MessageForeground = Application.Current.Resources["ButtonMouseOverBrush"] as SolidColorBrush;
            }
            Message = message;
            
            Text = Message;
            Style = new MessageChatStyle(MessageBackground, MessageForeground, Message);
            Margin = new Thickness(0, 5, 1, 0);
            HorizontalAlignment = MessageAlignment;
        }
    }
}
