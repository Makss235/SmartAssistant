using SmartAssistant.Infrastructure.Commands;
using SmartAssistant.UserControls.MainWindow.Tabs.Base;
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
        private TextBox typingMessageTextBox;

        private ICommand SendMessageByMeCommand { get; }
        private bool CanSendMessageByMeCommandExecute(object sender) => true;
        private void OnSendMessageByMeCommandExecuted(object sender)
        {
            if (typingMessageTextBox.Text != string.Empty)
            {
                messagesChat.Add(new MessageChat(HorizontalAlignment.Right, typingMessageTextBox.Text));
                typingMessageTextBox.Text = string.Empty;
                typingMessageTextBox.Focus();
            }
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

            InputBinding sendMessageEnter = new InputBinding(SendMessageByMeCommand,
                new KeyGesture(Key.Enter));
            InputBindings.Add(sendMessageEnter);

            messagesChat = new ObservableCollection<MessageChat>();

            ItemsControl itemsControl = new ItemsControl();
            itemsControl.ItemsSource = messagesChat;

            ScrollViewer scrollViewer = new ScrollViewer()
            {
                Margin = new Thickness(0, 40, 0, 100),
            };
            scrollViewer.Content = itemsControl;

            typingMessageTextBox = new TextBox()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(20),
                TextWrapping = TextWrapping.Wrap,
                VerticalContentAlignment = VerticalAlignment.Center,
                Padding = new Thickness(15, 0, 15, 0),
                FontSize = 16,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                Width = Width - 150,
                Height = 50
            };
            typingMessageTextBox.Focus();

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

            Grid mainGrid = new Grid()
            {
                Margin = new Thickness(20, 0, 0, 0)
            };
            mainGrid.Children.Add(scrollViewer);
            mainGrid.Children.Add(typingMessageTextBox);
            mainGrid.Children.Add(sendMessageButton);

            Border mainBorder = new Border()
            {
                Background = new SolidColorBrush(Colors.Transparent)
            };
            mainBorder.Child = mainGrid;
            Content = mainBorder;
        }
    }
}
