using SmartAssistant.UserControls.Widgets.Base;
using System;
using System.Windows.Controls;
using static SmartAssistant.UserControls.MainWindow.Tabs.VAChatTab.VAChatTab;

namespace SmartAssistant.UserControls.MainWindow.Tabs.VAChatTab
{
    public class Message : UserControl
    {
        public object MessageObject { get; set; }
        public SendMessageBy SendMessageBy { get; set; }

        public Message()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            ContentPresenter contentPresenter = new ContentPresenter()
            {
                Content = MessageObject
            };

            BackgroundBorder backgroundBorder = new BackgroundBorder();
            backgroundBorder.Child = contentPresenter;
            Content = backgroundBorder;
        }
    }
}
