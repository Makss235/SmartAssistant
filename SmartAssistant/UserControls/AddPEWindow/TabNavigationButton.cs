using SmartAssistant.UserControls.Base;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SmartAssistant.UserControls.AddPEWindow
{
    public class TabNavigationButton : NavigateButton, INotifyButtonPressed<byte>
    {
        public static event Action<byte> OnButtonPressed;

        public TabNavigationButton(string title, TypeButton type, byte id) : 
            base(title, type, id)
        {
            Button tabNavigateButton = new Button()
            {
                Width = 80,
                Height = 50,
                Content = Title,
                Command = ClickCommand
            };

            Content = tabNavigateButton;
        }

        protected override void OnClickCommandExecuted(object sender)
        {
            if (Type == TypeButton.Next) OnButtonPressed?.Invoke((byte)(ID + 1));
            else if (Type == TypeButton.Previous)
            {
                if (ID == 0) throw new Exception();
                else OnButtonPressed?.Invoke((byte)(ID - 1));
            }
        }
    }
}
