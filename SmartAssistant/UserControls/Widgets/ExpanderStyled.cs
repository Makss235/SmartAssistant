using SmartAssistant.Infrastructure.Commands;
using SmartAssistant.Infrastructure.Styles.Base;
using SmartAssistant.Infrastructure.Styles.MainWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace SmartAssistant.UserControls.Widgets
{
    public class ExpanderStyled : UserControl
    {
        /// <summary>
        /// Кароч сюда надо сделать отдельный контейнер СВОЙ вместо FrameworkElement, 
        /// в котором можно вызвать событие по 
        /// нажатию на заголовок для сворачивания или разворачивания содержимого. Этим контейнером
        /// может послучить кнопка, но только стилизированная (отдельный виджет), в уоторой
        /// легко можно убрать границы и задний фон. При желании ты можешь это начать делать,
        /// я позже присоединюсь
        /// </summary>
        public FrameworkElement HeaderContent { get; set; }
        public FrameworkElement ExpanderContent { get; set; }
        public bool IsExpanded { get; set; }

        public event Action<bool> Expanded;

        private StackPanel mainStackPanel;
        private Label headerLabel;
        private Button headerButton;
        private Grid roundedGrid;
        public Grid contentGrid;
        //public static readonly DependencyProperty ContentWidthProperty;

        public ExpanderStyled()
        {
            //ContentWidthProperty = DependencyProperty.Register("MyAss", typeof(double), typeof(ExpanderStyled));
            InitialazeComponent();

            //MouseBinding mouseBinding = new MouseBinding();
            //mouseBinding.MouseAction = MouseAction.LeftClick;
            //mouseBinding.Command = new LambdaCommand((s) => HeaderContent = new TextBlock() { Text = "hhhhhh"}, (s) => true);
            
            //var s = new Button() 
            //{ 
            //    Content = "kkk" 
            //};

            //s.Click += S_Click;
            //HeaderContent = s;
            //ExpanderContent = new UserControl();

            //StackPanel stackPanel = new StackPanel();
            //stackPanel.Children.Add(HeaderContent);
            //stackPanel.Children.Add(ExpanderContent);

            //Content = stackPanel;
        }

        //static ExpanderStyled()
        //{
        //    ContentWidthProperty = DependencyProperty.Register("MyAss", typeof(double), typeof(ExpanderStyled));
        //}
        //public double MyAss
        //{
        //    get { return (double)GetValue(ContentWidthProperty); }
        //    set { SetValue(ContentWidthProperty, value); }
        //}

        private void InitialazeComponent()
        {
            headerLabel = new Label
            {
                Content = "AAA",
                Background = Brushes.Yellow,
                Width = 200,
                Height = 30,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
            };

            headerButton = new Button
            {
                Background = Brushes.Transparent,
                BorderBrush = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                Width = 200,
                Height = 30,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Style = new MenuButtonStyle()
            };
            headerButton.PreviewMouseLeftButtonDown += HeaderLabel_PLMBD;
            headerButton.MouseEnter += HeaderLabel_ME;
            headerButton.MouseLeave += HeaderLabel_ML;

            contentGrid = new Grid
            {
                Background = Brushes.Green,
                Width = 180,
                Height = 100,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(20, 2, 0, 0),
            };

            roundedGrid = new Grid
            {
                Width = 200,
                Height = 30,
                HorizontalAlignment = HorizontalAlignment.Left,
                Children = { headerLabel, headerButton }
            };

            mainStackPanel = new StackPanel
            {
                Orientation = Orientation.Vertical,
                Children = { roundedGrid, contentGrid },
            };

            Margin = new Thickness(10);
            Content = mainStackPanel;
        }

        private void HeaderLabel_ML(object sender, MouseEventArgs e)
        {
            headerLabel.Background = Brushes.Yellow;
        }

        private void HeaderLabel_ME(object sender, MouseEventArgs e)
        {
            headerLabel.Background = Brushes.Blue;
        }

        private void HeaderLabel_PLMBD(object sender, MouseButtonEventArgs e)
        {
            if (contentGrid.Visibility == Visibility.Visible)
            {
                contentGrid.Visibility = Visibility.Collapsed;
            }
            else if (contentGrid.Visibility == Visibility.Collapsed)
            {
                contentGrid.Visibility = Visibility.Visible;
            }
        }

        //private void S_Click(object sender, RoutedEventArgs e)
        //{
        //    HeaderContent.Visibility = Visibility.Hidden;
        //}
    }
}
