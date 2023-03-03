using SmartAssistant.Infrastructure.Commands;
using SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.VAChatTab;
using SmartAssistant.Models;
using SmartAssistant.Resources;
using SmartAssistant.UserControls.Base;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SmartAssistant.UserControls.MainWindow.Tabs.VAChatTab
{
    public class VAChatTab : Tab
    {
        private ObservableCollection<MessageChat> messagesChat { get; set; }
        
        private InputBinding sendMessageEnterIB;
        private ItemsControl chatItemsControl;
        private ScrollViewer chatScrollViewer;
        private TextBox typingMessageTextBox;
        private Button sendMessageButton;
        private Grid mainGrid;

        public enum SendMessageBy
        {
            ByMe,
            ByBot
        }

        private ICommand SendMessageByMeCommand { get; }
        private bool CanSendMessageByMeCommandExecute(object sender) => true;
        private void OnSendMessageByMeCommandExecuted(object sender)
        {
            // TODO: RE можно сделать binding к typingMessageTextBox.Text
            if (typingMessageTextBox.Text != string.Empty)
            {
                SendMessage(typingMessageTextBox.Text, SendMessageBy.ByMe);
                SkillManager.DefineSkills(typingMessageTextBox.Text);
                typingMessageTextBox.Text = string.Empty;
                typingMessageTextBox.Focus();
            }
        }

        public VAChatTab(byte id, double width, double height, Visibility visibility)
            : base(id, width, height, visibility)
        {
            messagesChat = new ObservableCollection<MessageChat>();

            SendMessageByMeCommand = new LambdaCommand(
                OnSendMessageByMeCommandExecuted,
                CanSendMessageByMeCommandExecute);

            StateManager.SpeechStateVerifiedEvent += SendMessageByMeVoice;
            SkillManager.AnswerChangedEvent += SendMessageByBot;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            sendMessageEnterIB = new InputBinding(SendMessageByMeCommand,
                new KeyGesture(Key.Enter));
            InputBindings.Add(sendMessageEnterIB);

            chatItemsControl = new ItemsControl()
            {
                Margin = new Thickness(10, 0, 10, 0),
                FontFamily = new FontFamily("Segoe UI Semibold")
            };
            chatItemsControl.ItemsSource = messagesChat;

            chatScrollViewer = new ScrollViewer()
            { 
                Margin = new Thickness(0, 40, 8, 100),
                Style = ResApp.GetResources<Style>("ScrollViewerStyle")
            };
            chatScrollViewer.Content = chatItemsControl;

            typingMessageTextBox = new TextBox()
            {
                MaxHeight = 70,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(20),
                Style = new TypingMessageTextBoxStyle(Width)
            };
            typingMessageTextBox.Focus();
            typingMessageTextBox.TextChanged += TypingMessageTextBox_TextChanged;

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

            mainGrid = new Grid();
            mainGrid.Children.Add(chatScrollViewer);
            mainGrid.Children.Add(typingMessageTextBox);
            mainGrid.Children.Add(sendMessageButton);

            Content = mainGrid;
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
                chatScrollViewer.ScrollToEnd();
            });
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
