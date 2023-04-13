using SmartAssistant.Infrastructure.Commands;
using SmartAssistant.Infrastructure.Styles.Base;
using SmartAssistant.Infrastructure.Styles.MainWindow;
using SmartAssistant.Resources;
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
        private Border headerBorder;
        private Button headerButton;
        private Grid roundedGrid;
        private UIElement contentGrid;

        public ExpanderStyled()
        {
            InitialazeComponent();
        }

        private void InitialazeComponent()
        {
            headerBorder = new Border
            {
                Background = ResApp.GetResources<SolidColorBrush>("Transparent"),
                BorderBrush = ResApp.GetResources<SolidColorBrush>("CommonMediumBrush"),
                BorderThickness = new Thickness(2),
                CornerRadius = new CornerRadius(4),
                Width = 200,
                Height = 30,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
            };

            headerButton = new Button
            {
                Content = "BBB",
                Background = ResApp.GetResources<SolidColorBrush>("CommonLightBrush"),
                Foreground = ResApp.GetResources<SolidColorBrush>("CommonMediumBrush"),
                Width = 192,
                Height = 22,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                //Style = new TransparentButton()
            };
            headerButton.MouseLeave += HeaderLabel_ML;
            headerButton.MouseEnter += HeaderLabel_ME;
            headerButton.PreviewMouseLeftButtonDown += HeaderLabel_PLMBD;

            contentGrid = new UIElement
            {
                //Background = Brushes.Green,
                //Width = 180,
                //Height = 100,
                //HorizontalAlignment = HorizontalAlignment.Left,
                //VerticalAlignment = VerticalAlignment.Top,
                //Margin = new Thickness(20, 2, 0, 0),
            };

            roundedGrid = new Grid
            {
                Width = 200,
                Height = 30,
                HorizontalAlignment = HorizontalAlignment.Left,
                Children = { headerBorder, headerButton }
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
            headerButton.Foreground = ResApp.GetResources<SolidColorBrush>("CommonMediumBrush");
        }

        private void HeaderLabel_ME(object sender, MouseEventArgs e)
        {
            headerButton.Foreground = ResApp.GetResources<SolidColorBrush>("CommonDarkBrush");
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
    }
}
