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
        private ObservableCollection<Message> messagesChat { get; set; }
        
        private InputBinding sendMessageEnterIB;
        private ItemsControl chatItemsControl;
        private ScrollViewer chatScrollViewer;
        private TextBox typingMessageTextBox;
        private Button sendMessageButton;
        private Grid mainGrid;
        //private Trigger beginAnimT;

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
            messagesChat = new ObservableCollection<Message>();

            SendMessageByMeCommand = new LambdaCommand(
                OnSendMessageByMeCommandExecuted,
                CanSendMessageByMeCommandExecute);

            StateManager.SpeechStateVerifiedEvent += SendMessageByMeVoice;
            SkillManager.AnswerPresenterChanged += SkillManager_AnswerPresenterChanged;

            this.Style = ResApp.GetResources<Style>("TabStyle");

            //EventTrigger tr = new EventTrigger
            //{
            //    //Property = VisibilityProperty,
            //    //Value = Visibility.Visible,
            //    RoutedEvent = Tab.MouseEnterEvent,
            //};
            //var BeginSB = new BeginStoryboard();
            //BeginSB.Storyboard = new TabsAppearAnimation(this).tabsAppearAnimSB;
            //tr.EnterActions.Add(BeginSB);
            //Triggers.Add(tr);
            InitializeComponent();
        }

        private async void SkillManager_AnswerPresenterChanged(FrameworkElement obj)
        {
            //StackPanel stackPanel = new StackPanel();
            //string Text = "";
            //string url = "https://yandex.ru/search/?text=%D0%BA%D0%B0%D0%BA+%D0%BF%D0%BE%D0%BC%D0%B5%D0%BD%D1%8F%D1%82%D1%8C+%D0%BF%D1%80%D0%B8%D0%B2%D0%B0%D1%82%D0%BD%D0%BE%D1%81%D1%82%D1%8C+%D1%80%D0%B5%D0%BF%D0%BE%D0%B7%D0%B8%D1%82%D0%BE%D1%80%D0%B8%D1%8F+%D0%BD%D0%B0+github&lr=120612&src=suggest_Pers";

            //HttpClient client = new HttpClient();
            //string page = await client.GetStringAsync(url);

            //using var context = BrowsingContext.New(Configuration.Default);
            //using var doc = await context.OpenAsync(req => req.Content(page));

            //var quickAnswer = doc.GetElementsByClassName(
            //    "serp-item serp-item_card serp-item_card-extra-shadow " +
            //    "serp-item_card-no-padding-bottom has-branding " +
            //    "has-branding__fact has-branding__show-hint");
            //if (quickAnswer.Length != 0)
            //{
            //    quickAnswer = quickAnswer[0].GetElementsByClassName(
            //        "Fact Fact_flexSize_no Fact_answerGap_l");
            //    var elems = quickAnswer[0].Children;

            //    for (int i = 0; i < elems.Length; i++)
            //    {
            //        if (elems[i].ClassName != "Fact-Source" &&
            //            elems[i].ClassName != "ExtraActions Typo Typo_text_s Typo_line_m Fact-Footer")
            //        {
            //            var lll = elems[i].QuerySelectorAll("div");
            //            //if (lll.Length != 0)
            //            {
            //                stackPanel.Children.Add(new TextBlock()
            //                {
            //                    Text = elems[i].TextContent,
            //                    MaxWidth = 400,
            //                    TextWrapping = TextWrapping.Wrap,
            //                    HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
            //                    FontSize = 15
            //                });

            //                Text += elems[i].TextContent;
            //            }
            //        }
            //        else if (elems[i].ClassName == "Fact-Source")
            //        {
            //            var href = elems[i].GetElementsByClassName("Link Fact-SiteSource")[0].GetAttribute("href");
            //            var sitename = elems[i].GetElementsByClassName("Path-Item")[0].QuerySelector("b").TextContent;
            //            var pagename = elems[i].GetElementsByClassName("OneLine Fact-Title Typo Typo_text_xm Typo_line_m")[0].TextContent;

            //            var downloadHyperlink = new Hyperlink()
            //            {
            //                NavigateUri = new Uri(href)
            //            };
            //            downloadHyperlink.RequestNavigate += (s, e) =>
            //            Process.Start(new ProcessStartInfo(href)
            //            { UseShellExecute = true });

            //            downloadHyperlink.Inlines.Add(pagename);

            //            var downloadHyperlinkTextBlock = new TextBlock()
            //            {
            //                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
            //                FontSize = 15
            //            };
            //            downloadHyperlinkTextBlock.Inlines.Add(downloadHyperlink);

            //            stackPanel.Children.Add(new TextBlock()
            //            {
            //                Text = sitename,
            //                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
            //                FontSize = 15
            //            });
            //            stackPanel.Children.Add(downloadHyperlinkTextBlock);
            //        }
            //    }
            //}
            //MessageBox.Show(Text);
            //Application.Current.Dispatcher.Invoke(() =>
            //{
            //    messagesChat.Add(new Message(stackPanel, SendMessageBy.ByBot) { });
            //    chatScrollViewer.ScrollToEnd();
            //});

            Application.Current.Dispatcher.Invoke(() =>
            {
                messagesChat.Add(new Message() { MessageObject = obj, SendMessageBy = SendMessageBy.ByBot });
                chatScrollViewer.ScrollToEnd();
            });
        }

        private void InitializeComponent()
        {
            sendMessageEnterIB = new InputBinding(SendMessageByMeCommand,
                new KeyGesture(Key.Enter));
            InputBindings.Add(sendMessageEnterIB);

            chatItemsControl = new ItemsControl()
            {
                Margin = new Thickness(10, 0, 10, 0),
                FontFamily = new FontFamily("Segoe UI Semibold"),
                Background = Brushes.Transparent,
                Style = new ItemsControlStyle()
            };
            chatItemsControl.ItemsSource = messagesChat;

            chatScrollViewer = new ScrollViewer()
            { 
                Margin = new Thickness(0, 40, 8, 100),
                Style = ResApp.GetResources<Style>("ScrollViewerStyle"),
                Background = Brushes.Transparent,
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
                Style = new SendButtonStyle(),
                //Padding = new Thickness(5, 0, 0, 0),
                //Content = ResApp.GetResources<Image>("MicrophoneButton")
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
                messagesChat.Add(new Message() { MessageObject = text, SendMessageBy = sendMessageBy });
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
                sendMessageButton.Content = ResApp.GetResources<Image>("SendButton");
                sendMessageButton.Padding = new Thickness(5, 0, 0, 0);
            }
            else
            {
                sendMessageButton.Content = ResApp.GetResources<Image>("MicrophoneButton");
                sendMessageButton.Padding = new Thickness(0);
            }
        }
    }
}
