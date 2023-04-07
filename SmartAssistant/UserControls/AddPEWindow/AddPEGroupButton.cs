using SmartAssistant.Infrastructure.Styles.AddPEWindow;
using SmartAssistant.Resources;
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
        Trigger MOTrueT;
        Trigger MOFalseT;

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
                FontSize = 15,
                Height = 50,
                Content = Title,
                Style = new AddPEMenuButtonStyle(),
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
            if (IsCorrect) 
            {
                //groupButton.Background = ResApp.GetResources<SolidColorBrush>("CommonMediumBrush");
                MOTrueT = new Trigger
                {
                    Property = Button.IsMouseOverProperty,
                    Value = true
                };
                MOTrueT.Setters.Add(new Setter(Button.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("CommonLightBrush")));
                MOTrueT.Setters.Add(new Setter(Button.BorderBrushProperty, ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")));
                MOTrueT.Setters.Add(new Setter(Button.ForegroundProperty, ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")));
                MOFalseT = new Trigger
                {
                    Property = Button.IsMouseOverProperty,
                    Value = false
                };
                MOFalseT.Setters.Add(new Setter(Button.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")));
                MOFalseT.Setters.Add(new Setter(Button.BorderBrushProperty, ResApp.GetResources<SolidColorBrush>("CommonLightBrush")));

                groupButton.Style = new AddPEMenuButtonStyle(MOTrueT, MOFalseT);
            }
            else
            {
                //groupButton.Background = ResApp.GetResources<SolidColorBrush>("Red");
                MOTrueT = new Trigger
                {
                    Property = Button.IsMouseOverProperty,
                    Value = true
                };
                MOTrueT.Setters.Add(new Setter(Button.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("CommonLightBrush")));
                MOTrueT.Setters.Add(new Setter(Button.BorderBrushProperty, ResApp.GetResources<SolidColorBrush>("Red")));
                MOTrueT.Setters.Add(new Setter(Button.ForegroundProperty, ResApp.GetResources<SolidColorBrush>("Red")));
                MOFalseT = new Trigger
                {
                    Property = Button.IsMouseOverProperty,
                    Value = false
                };
                MOFalseT.Setters.Add(new Setter(Button.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("Red")));
                MOFalseT.Setters.Add(new Setter(Button.BorderBrushProperty, ResApp.GetResources<SolidColorBrush>("CommonLightBrush")));
                groupButton.Style = new AddPEMenuButtonStyle(MOTrueT, MOFalseT);
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
