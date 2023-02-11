using SmartAssistant.Infrastructure.Commands;
using SmartAssistant.UserControls.MainWindow.Tabs.Base;
using SmartAssistant.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Shapes;

namespace SmartAssistant.UserControls.MainWindow
{
    public class MenuButtonUC : UserControl, INotifyPropertyChanged
    {
        #region Title : string - Заголовок кнопки

        /// <summary>Заголовок кнопки</summary>
        private string _Title;

        /// <summary>Заголовок кнопки</summary>
        public string Title
        {
            get => _Title;
            set => SetProperty(ref _Title, value);
        }

        #endregion

        #region IsActive : bool - Состояние кнопки

        /// <summary>Состояние кнопки</summary>
        private bool _IsActive;

        /// <summary>Состояние кнопки</summary>
        public bool IsActive
        {
            get => _IsActive;
            set => SetProperty(ref _IsActive, value);
        }

        #endregion

        #region ID : byte - Идентификатор кнопки

        /// <summary>Идентификатор кнопки</summary>
        private byte _ID;

        /// <summary>Идентификатор кнопки</summary>
        public byte ID
        {
            get => _ID;
            set => SetProperty(ref _ID, value);
        }

        #endregion

        public static event Action<byte> MenuButtonPressedEvent;

        public ICommand HandlerClickCommand;
        private bool CanHandlerClickCommandExecute(object sender) => true;
        private void OnHandlerClickCommandExecuted(object sender)
        {
            MenuButtonPressedEvent.Invoke(ID);
        }

        public MenuButtonUC(string title, bool isActive, byte id)
        {
            Title = title;
            IsActive = isActive;
            ID = id;
            HandlerClickCommand = new LambdaCommand(
                OnHandlerClickCommandExecuted, 
                CanHandlerClickCommandExecute);

            TextBlock textBlock = new TextBlock()
            {
                Text = Title,
                //Width = 175,
                //Height = 100
            };

            //StackPanel stackPanel = new StackPanel()
            //{
            //    Orientation = Orientation.Horizontal
            //};
            //stackPanel.Children.Add(textBlock);

            MenuButtonStyle menuButtonStyle = new MenuButtonStyle();
            Button button = new Button()
            {
                Height = 45,
                Command = HandlerClickCommand,
                Style = menuButtonStyle
            };
            IAddChild addChild = button;
            addChild.AddChild(textBlock);

            
            Path path = new Path()
            {
                Fill = BasicColors.BackgroundLightBrush,
                Stretch = System.Windows.Media.Stretch.Fill,
            };

            Grid grid = new Grid()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Width = 20, 
                Height = 85,
                Visibility = Visibility.Visible
            };
            grid.Children.Add(path);

            Grid mainGrid = new Grid()
            {
                Margin = new Thickness(0, -17, 0, -17),
                Width = 200
            };
            mainGrid.Children.Add(button);
            mainGrid.Children.Add(grid);
            Content = mainGrid;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
    }
}
