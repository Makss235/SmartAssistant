using SmartAssistant.Infrastructure.Commands;
using SmartAssistant.Infrastructure.Styles;
using SmartAssistant.UserControls.Base;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SmartAssistant.UserControls.AddPEWindow
{
    public class AddPEGroupButton : GroupButton
    {
        internal static event Action<byte> AddPEButtonPressed;

        public AddPEGroupButton(string title, bool isActive, byte id) :
            base(title, isActive, id)
        {

            Button button = new Button()
            {
                MinWidth = 105,
                Padding = new Thickness(20, 0, 20, 0),
                FontSize = 13,
                Height = 50,
                Content = title,
                Style = new RoundedButton
                (
                    new CornerRadius(25),
                    new Thickness(1),
                    (SolidColorBrush)Application.Current.Resources["BackgroundMediumBrush"],
                    (SolidColorBrush)Application.Current.Resources["BackgroundLightBrush"],
                    (SolidColorBrush)Application.Current.Resources["BackgroundMediumBrush"],
                    (SolidColorBrush)Application.Current.Resources["BackgroundLightBrush"],
                    (SolidColorBrush)Application.Current.Resources["BackgroundMediumBrush"],
                    (SolidColorBrush)Application.Current.Resources["BackgroundMediumBrush"]
                ),
                Command = ClickCommand
            };
            Content = button;
        }

        protected override void OnClickCommandExecuted(object sender)
        {
            AddPEButtonPressed?.Invoke(ID);
        }
    }
}
