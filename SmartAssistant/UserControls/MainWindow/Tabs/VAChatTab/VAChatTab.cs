using SmartAssistant.Infrastructure.Commands;
using SmartAssistant.Models;
using SmartAssistant.UserControls.MainWindow.Tabs.Base;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SmartAssistant.UserControls.MainWindow.Tabs.VAChatTab
{
    public class VAChatTab : Tab
    {
        private ObservableCollection<MessageChat> messagesChat { get; set; }
        private TextBox typingMessageTextBox;
        private ScrollViewer scrollViewer;
        private Border typingMessageBorder;

        private ICommand SendMessageByMeCommand { get; }
        private bool CanSendMessageByMeCommandExecute(object sender) => true;
        private void OnSendMessageByMeCommandExecuted(object sender)
        {
            if (typingMessageTextBox.Text != string.Empty)
            {
                messagesChat.Add(new MessageChat(HorizontalAlignment.Right, typingMessageTextBox.Text));
                typingMessageTextBox.Text = string.Empty;
                typingMessageTextBox.Focus();
                scrollViewer.ScrollToEnd();
            }
        }

        private void SendMessageByMe(string text)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                messagesChat.Add(new MessageChat(HorizontalAlignment.Right, text));
                scrollViewer.ScrollToEnd();
            });
        }

        private void SendMessageByBot(string text)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                messagesChat.Add(new MessageChat(HorizontalAlignment.Left, text));
                scrollViewer.ScrollToEnd();
            });
        }

        public VAChatTab(byte id, double width, double height, Visibility visibility)
        {
            ID = id;
            Width = width;
            Height = height;
            Visibility = visibility;

            SendMessageByMeCommand = new LambdaCommand(
                OnSendMessageByMeCommandExecuted,
                CanSendMessageByMeCommandExecute);

            StateManager.SpeechStateVerifiedEvent += SendMessageByMe;
            SkillManager.AnswerChangedEvent += SendMessageByBot;

            InputBinding sendMessageEnter = new InputBinding(SendMessageByMeCommand,
                new KeyGesture(Key.Enter));
            InputBindings.Add(sendMessageEnter);

            messagesChat = new ObservableCollection<MessageChat>();

            ItemsControl itemsControl = new ItemsControl()
            {
                Margin = new Thickness(10, 0, 10, 0),
                FontFamily = new FontFamily("Segoe UI Semibold")
            };
            itemsControl.ItemsSource = messagesChat;

            scrollViewer = new ScrollViewer()
            {
                Margin = new Thickness(0, 40, 0, 100),
            };
            scrollViewer.Content = itemsControl;

            

            typingMessageTextBox = new TextBox()
            {
                Style = new TypingMessageTextBoxStyle(Width),
            };
            typingMessageTextBox.Focus();

            typingMessageBorder = new Border()
            {
                Child = typingMessageTextBox,
                Style = new TypingChatMessageBorderStyle(Width),
            };
            

            Button sendMessageButton = new Button()
            {
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 50,
                Width = 50,
                Margin = new Thickness(20, 20, 30, 20),
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(1),
                Command = SendMessageByMeCommand
            };

            Grid mainGrid = new Grid();
            mainGrid.Children.Add(scrollViewer);
            mainGrid.Children.Add(typingMessageBorder);
            mainGrid.Children.Add(sendMessageButton);

            Content = mainGrid;
        }
    }
}
