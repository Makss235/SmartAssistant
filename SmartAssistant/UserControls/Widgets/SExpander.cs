using SmartAssistant.UserControls.Widgets.Base;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.UserControls.Widgets
{
    public class SExpander : UserControl, INotifyPropertyChanged
    {
        private object _HeaderContent;

        public object HeaderContent
        {
            get => _HeaderContent;
            set => SetProperty(ref _HeaderContent, value);
        }

        private object _BodyContent;

        public object BodyContent
        {
            get => _BodyContent;
            set => SetProperty(ref _BodyContent, value);
        }

        private bool _IsExpanded = true;

        public bool IsExpanded
        {
            get => _IsExpanded;
            set => SetProperty(ref _IsExpanded, value);
        }

        public event Action<bool> Expanded;

        private ContentPresenter headerContentPresenter;
        private StackPanel headerStackPanel;
        private TransparentButton headerTButton;
        private ContentPresenter bodyContentPresenter;
        private StackPanel expanderStackPanel;

        public SExpander()
        {
            InitialazeComponent();
            PropertyChanged += SExpander_PropertyChanged;
        }

        #region NPC

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            //if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

        #endregion

        private void SExpander_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(IsExpanded):
                    bodyContentPresenter.Visibility = 
                        IsExpanded ? Visibility.Visible : Visibility.Collapsed;
                    break;
                default:
                    break;
            }
        }

        private void InitialazeComponent()
        {
            FontSize = 15;
            FontFamily = new FontFamily("Times new roman");

            BackgroundBorder backgroundBorder = new BackgroundBorder()
            {
                Width = 20,
                Height = 20
            };

            headerContentPresenter = new ContentPresenter()
            {
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(6, 0, 0, 0),
                Content = _HeaderContent
            };
            headerContentPresenter.SetBinding(
                ContentPresenter.ContentProperty,
                new Binding("HeaderContent") { Source = this });

            headerStackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Height = 30
            };
            headerStackPanel.Children.Add(backgroundBorder);
            headerStackPanel.Children.Add(headerContentPresenter);

            headerTButton = new TransparentButton()
            {
                Content = headerStackPanel
            };
            headerTButton.Click += HeaderTButton_Click;

            bodyContentPresenter = new ContentPresenter()
            {
                Margin = new Thickness(30, 0, 5, 0),
                Content = _BodyContent
            };
            bodyContentPresenter.Visibility = IsExpanded ? Visibility.Visible : Visibility.Collapsed;
            bodyContentPresenter.SetBinding(
                ContentPresenter.ContentProperty,
                new Binding("BodyContent") { Source = this });

            expanderStackPanel = new StackPanel();
            expanderStackPanel.Children.Add(headerTButton);
            expanderStackPanel.Children.Add(bodyContentPresenter);

            Content = expanderStackPanel;
        }

        private void HeaderTButton_Click(object sender, RoutedEventArgs e)
        {
            if (bodyContentPresenter.Visibility == Visibility.Collapsed)
            {
                bodyContentPresenter.Visibility = Visibility.Visible;
                IsExpanded = true;
                Expanded?.Invoke(IsExpanded);
            }
            else if (bodyContentPresenter.Visibility == Visibility.Visible)
            {
                bodyContentPresenter.Visibility = Visibility.Collapsed;
                IsExpanded = false;
                Expanded?.Invoke(IsExpanded);
            }
        }
    }
}
