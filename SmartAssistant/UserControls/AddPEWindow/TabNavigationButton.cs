using SmartAssistant.Infrastructure.Styles;
using SmartAssistant.Infrastructure.Styles.Base;
using SmartAssistant.Resources;
using SmartAssistant.UserControls.Base;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.UserControls.AddPEWindow
{
    public class TabNavigationButton : NavigateButton, INotifyButtonPressed<byte>
    {
        public override event Action<byte> ButtonPressed;

        public TabNavigationButton(string title, TypeButton type, byte id)
            : base(title, type, id)
        {
            Button tabNavigateButton = new Button()
            {
                Width = 80,
                Height = 50,
                Content = Title,
                Command = ClickCommand,
                Style = new RoundedButton(
                    new CornerRadius(10),
                    new Thickness(1),
                    ResApp.GetResources<SolidColorBrush>("CommonMediumBrush"),
                    ResApp.GetResources<SolidColorBrush>("CommonLightBrush"),
                    ResApp.GetResources<SolidColorBrush>("CommonLightBrush"),
                    ResApp.GetResources<SolidColorBrush>("CommonLightBrush"),
                    ResApp.GetResources<SolidColorBrush>("CommonMediumBrush"),
                    ResApp.GetResources<SolidColorBrush>("CommonMediumBrush"))
            };

            Content = tabNavigateButton;
        }

        protected override void OnClickCommandExecuted(object sender)
        {
            if (Type == TypeButton.Next) ButtonPressed?.Invoke((byte)(ID + 1));
            else if (Type == TypeButton.Previous)
            {
                if (ID == 0) throw new Exception();
                else ButtonPressed?.Invoke((byte)(ID - 1));
            }
        }
    }
}
