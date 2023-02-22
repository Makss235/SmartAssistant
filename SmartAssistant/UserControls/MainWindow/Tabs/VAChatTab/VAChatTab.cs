using SmartAssistant.Infrastructure.Commands;
using SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.VAChatTab;
using SmartAssistant.Models;
using SmartAssistant.UserControls.Base;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace SmartAssistant.UserControls.MainWindow.Tabs.VAChatTab
{
    public class VAChatTab : Tab
    {
        private ObservableCollection<MessageChat> messagesChat { get; set; }
        private TextBox typingMessageTextBox;
        private ScrollViewer scrollViewer;
        private Border typingMessageBorder;
        private Button sendMessageButton;

        public enum SendMessageBy
        {
            ByMe,
            ByBot
        }

        private ICommand SendMessageByMeCommand { get; }
        private bool CanSendMessageByMeCommandExecute(object sender) => true;
        private void OnSendMessageByMeCommandExecuted(object sender)
        {
            if (typingMessageTextBox.Text != string.Empty)
            {
                SendMessage(typingMessageTextBox.Text, SendMessageBy.ByMe);
                SkillManager.DefineSkills(typingMessageTextBox.Text);
                typingMessageTextBox.Text = string.Empty;
                typingMessageTextBox.Focus();
            }
        }

        private void SendMessageByMeVoice(string text)
        {
            SendMessage(text, SendMessageBy.ByMe);
        }

        private void SendMessageByBot(string text)
        {
            SendMessage(text, SendMessageBy.ByBot);
        }

        private void SendMessage(string text, SendMessageBy sendMessageBy) 
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                messagesChat.Add(new MessageChat(text, sendMessageBy));
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

            StateManager.SpeechStateVerifiedEvent += SendMessageByMeVoice;
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
                Margin = new Thickness(0, 40, 8, 100),
            };
            scrollViewer.Content = itemsControl;

            typingMessageTextBox = new TextBox()
            {
                //MinHeight = 50,
                MaxHeight = 250,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(20),
                Style = new TypingMessageTextBoxStyle(Width)
            };
            typingMessageTextBox.Focus();
            typingMessageTextBox.TextChanged += TypingMessageTextBox_TextChanged;

            //typingMessageBorder = new Border()
            //{
            //    Child = typingMessageTextBox,
            //    MinHeight = 0,
            //    MaxHeight = 250,
            //    Style = new TypingChatMessageBorderStyle(Width),
            //};

            sendMessageButton = new Button()
            {
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Right,
                Height = 50,
                Width = 50,
                Margin = new Thickness(20, 20, 30, 20),
                Command = SendMessageByMeCommand,
                Style = new SendButtonStyle()
            };

            Grid mainGrid = new Grid();
            mainGrid.Children.Add(scrollViewer);
            mainGrid.Children.Add(typingMessageTextBox);
            mainGrid.Children.Add(sendMessageButton);

            Content = mainGrid;
        }

        private void TypingMessageTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SendButtonImageChange(sender, e);
        }

        // TODO: Veser анимация
        // TODO: Veser иконки
        private void SendButtonImageChange(object sender, TextChangedEventArgs e)
        {
            if (typingMessageTextBox.Text == string.Empty)
            {
                sendMessageButton.Background = new SolidColorBrush(Colors.Black);
            }
            else
            {
                sendMessageButton.Background = new SolidColorBrush(Colors.Yellow);
            }
        }
    }
}
