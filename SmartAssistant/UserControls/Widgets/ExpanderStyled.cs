using SmartAssistant.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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


        public ExpanderStyled()
        {
            MouseBinding mouseBinding = new MouseBinding();
            mouseBinding.MouseAction = MouseAction.LeftClick;
            mouseBinding.Command = new LambdaCommand((s) => HeaderContent = new TextBlock() { Text = "hhhhhh"}, (s) => true);
            
            var s = new Button() { Content = "kkk" };
            s.Click += S_Click;
            HeaderContent = s;
            ExpanderContent = new UserControl();

            StackPanel stackPanel = new StackPanel();
            stackPanel.Children.Add(HeaderContent);
            stackPanel.Children.Add(ExpanderContent);

            Content = stackPanel;
        }

        private void S_Click(object sender, RoutedEventArgs e)
        {
            HeaderContent.Visibility = Visibility.Hidden;
        }
    }
}
