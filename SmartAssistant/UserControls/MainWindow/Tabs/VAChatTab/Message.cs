using SmartAssistant.UserControls.Widgets.Base;
using System;
using System.Windows.Controls;
using System.Windows;
using static SmartAssistant.UserControls.MainWindow.Tabs.VAChatTab.VAChatTab;
using System.Windows.Media;
using SmartAssistant.Resources;

namespace SmartAssistant.UserControls.MainWindow.Tabs.VAChatTab
{
    public class Message : UserControl
    {
        //    public object MessageObject { get; set; }
        //    public string MessageString { get; set; }
        //    public SendMessageBy SendMessageBy { get; set; }

        public Message(object messageObject, SendMessageBy sendMessageBy)
        {
            ContentPresenter content = new ContentPresenter
            {
                 Content = messageObject,
                 VerticalAlignment = VerticalAlignment.Center,
                 HorizontalAlignment = HorizontalAlignment.Center,
                 Margin = new Thickness(5),
            };
            InitializeComponent(content, sendMessageBy);
        }
        public Message(string messageString, SendMessageBy sendMessageBy)
        {
            TextBlock content = new TextBlock
            {
                Text = messageString,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Background = Brushes.Transparent,
                Margin = new Thickness(5),
            };
            InitializeComponent(content, sendMessageBy);
        }
        private void InitializeComponent(UIElement childControl, SendMessageBy sendMessageBy)
        {
            BackgroundBorder backgroundBorder = new BackgroundBorder
            {
                Child = childControl,
                Width = Width,
                Height = Height,
            };

            if (sendMessageBy == SendMessageBy.ByMe)
            {
                HorizontalAlignment = HorizontalAlignment.Right;
                backgroundBorder.Background = ResApp.GetResources<SolidColorBrush>("CommonMediumBrush");
                backgroundBorder.BorderBrush = ResApp.GetResources<SolidColorBrush>("Transparent");
                Foreground = ResApp.GetResources<SolidColorBrush>("CommonLightBrush");
            }
            else if (sendMessageBy == SendMessageBy.ByBot)
            {
                HorizontalAlignment = HorizontalAlignment.Left;
                backgroundBorder.Background = ResApp.GetResources<SolidColorBrush>("FadedBrush");
                backgroundBorder.BorderBrush = ResApp.GetResources<SolidColorBrush>("CommonDarkBrush");
                Foreground = ResApp.GetResources<SolidColorBrush>("CommonDarkBrush");
            }

            Margin = new Thickness(0, 3, 0, 3);
            FontSize = 17;

            Content = backgroundBorder;
        }
    }
}
