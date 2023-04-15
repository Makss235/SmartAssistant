using SmartAssistant.UserControls.Widgets.Base;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SmartAssistant.UserControls.Widgets
{
    public class SExpander : UserControl
    {
        public object HeaderContent { get; set; }
        public object ExpanderContent { get; set; }
        public bool IsExpanded { get; set; }

        public event Action<bool> Expanded;

        private ContentPresenter contentPresenter1;

        public SExpander()
        {
            InitialazeComponent();
        }

        private void InitialazeComponent()
        {
            HeaderContent = "hvjh";
            ExpanderContent = "fdbvjkdfn";

            BackgroundBorder backgroundBorder = new BackgroundBorder()
            {
                Width = 20,
                Height = 20,
            };

            ContentPresenter contentPresenter = new ContentPresenter()
            {
                VerticalAlignment = VerticalAlignment.Center,
                Content = HeaderContent
            };

            StackPanel stackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Height = 30
            };
            stackPanel.Children.Add(backgroundBorder);
            stackPanel.Children.Add(contentPresenter);

            TransparentButton transparentButton = new TransparentButton()
            {
                Content = stackPanel
            };
            transparentButton.Click += TransparentButton_Click;

            contentPresenter1 = new ContentPresenter();
            contentPresenter1.Content = ExpanderContent;

            StackPanel stackPanel1 = new StackPanel();
            stackPanel1.Children.Add(transparentButton);
            stackPanel1.Children.Add(contentPresenter1);

            Content = stackPanel1;
        }

        private void TransparentButton_Click(object sender, RoutedEventArgs e)
        {
            if (contentPresenter1.Visibility == Visibility.Collapsed)
            {
                contentPresenter1.Visibility = Visibility.Visible;
                IsExpanded = true;
                Expanded?.Invoke(IsExpanded);
            }
            else if (contentPresenter1.Visibility == Visibility.Visible)
            {
                contentPresenter1.Visibility = Visibility.Collapsed;
                IsExpanded = false;
                Expanded?.Invoke(IsExpanded);
            }
        }
    }
}
