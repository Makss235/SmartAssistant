using System.Windows;
using System.Windows.Controls;

namespace SmartAssistant.UserControls.MainWindow.Tabs.VAChatTab
{
    public class MessageChat : TextBlock
    {
        public HorizontalAlignment MessageAlignment { get; set; }
        public string Message { get; set; }

        public MessageChat(HorizontalAlignment messageAlignment, string message)
        {
            MessageAlignment = messageAlignment;
            Message = message;
            Text = Message;
            HorizontalAlignment = MessageAlignment;
        }
    }
}
