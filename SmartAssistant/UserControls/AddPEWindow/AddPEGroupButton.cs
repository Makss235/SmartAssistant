using SmartAssistant.Infrastructure.Styles;
using SmartAssistant.Infrastructure.Styles.AddPEWindow;
using SmartAssistant.Infrastructure.Styles.Base;
using SmartAssistant.UserControls.Base;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.UserControls.AddPEWindow
{
    public class AddPEGroupButton : GroupButton
    {
        private Button groupButton;

        public override event Action<byte> ButtonPressed;

        #region IsCorrect : bool - Состояние кнопки

        /// <summary>Состояние кнопки</summary>
        private bool _IsCorrect;

        /// <summary>Состояние кнопки</summary>
        public bool IsCorrect
        {
            get => _IsCorrect;
            set => SetProperty(ref _IsCorrect, value);
        }

        #endregion

        public AddPEGroupButton(string title, bool isActive, byte id) :
            base(title, isActive, id)
        {
            PropertyChanged += AddPEGroupButton_PropertyChanged;
            InitializeComponent();
            StateChange();
        }

        private void InitializeComponent()
        {
            groupButton = new Button()
            {
                MinWidth = 50,
                Padding = new Thickness(20, 0, 20, 0),
                FontSize = 13,
                Height = 50,
                Content = Title,
                Style = new AddPEMenuButton(),//new RoundedButton
                //(
                //    new CornerRadius(25),
                //    new Thickness(1),
                //    (SolidColorBrush)Application.Current.Resources["BackgroundMediumBrush"],
                //    (SolidColorBrush)Application.Current.Resources["BackgroundLightBrush"],
                //    (SolidColorBrush)Application.Current.Resources["BackgroundMediumBrush"],
                //    (SolidColorBrush)Application.Current.Resources["BackgroundLightBrush"],
                //    (SolidColorBrush)Application.Current.Resources["BackgroundMediumBrush"],
                //    (SolidColorBrush)Application.Current.Resources["BackgroundMediumBrush"]
                //),
                Command = ClickCommand
            };
            Content = groupButton;
        }

        private void AddPEGroupButton_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(IsActive):
                    StateChange();
                    break;
                case nameof(IsCorrect):
                    CorrectChange();
                    break;
            }
        }

        private void CorrectChange()
        {
            // TODO: Veser сделать изменение цвета
            if (IsCorrect) groupButton.Background = (SolidColorBrush)Application.Current.Resources["BackgroundMediumBrush"];
            else 
            {
                groupButton.Background = (SolidColorBrush)Application.Current.Resources["Red"];
                groupButton.BorderBrush = (SolidColorBrush)Application.Current.Resources["Red"];
            }
        }

        private void StateChange()
        {
            if (IsActive) groupButton.Content = Title;
            else groupButton.Content = ID + 1;
        }

        protected override void OnClickCommandExecuted(object sender)
        {
            ButtonPressed?.Invoke(ID);
        }
    }
}
