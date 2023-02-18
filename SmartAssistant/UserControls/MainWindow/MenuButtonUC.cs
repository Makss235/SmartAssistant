using SmartAssistant.Infrastructure.Commands;
using SmartAssistant.Infrastructure.Styles.MainWindow;
using SmartAssistant.Windows;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SmartAssistant.UserControls.MainWindow
{
    public class MenuButtonUC : UserControl, INotifyPropertyChanged
    {
        #region NPC

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

        #endregion

        private Path path;
        private TextBlock textBlock;
        private Button button;

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

            textBlock = new TextBlock()
            {
                Text = Title
            };

            StackPanel stackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            stackPanel.Children.Add(textBlock);

            MenuButtonStyle menuButtonStyle = new MenuButtonStyle();
            button = new Button()
            {
                Height = 45,
                Command = HandlerClickCommand,
                Width = 220,
                Style = menuButtonStyle
            };
            button.MouseEnter += Button_MouseEnter;
            button.MouseLeave += Button_MouseLeave;
            IAddChild addChild = button;
            addChild.AddChild(stackPanel);
            Panel.SetZIndex(button, 1);

            StreamGeometry geometry = new StreamGeometry();

            using (StreamGeometryContext ctx = geometry.Open())
            {
                ctx.BeginFigure(new Point(0, 20.7), true, true);
                ctx.BezierTo(new Point(15, 20), new Point(26.5, 12), new Point(27, 0), true, true);
                ctx.LineTo(new Point(27, 87.6), true, true);
                ctx.BezierTo(new Point(26, 75), new Point(15.1, 67.5), new Point(0, 67), true, true);
                ctx.LineTo(new Point(0, 24), true, true);
            }
            geometry.Freeze();

            path = new Path()
            {
                Fill = BasicColors.BackgroundLightBrush,
                Stretch = Stretch.Fill,
                Data = geometry,
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(0, 0, -1, 0)
            };
            Panel.SetZIndex(path, 10);
            

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
                Width = 220
            };
            mainGrid.Children.Add(button);
            mainGrid.Children.Add(grid);
            Content = mainGrid;

            PropertyChanged += MenuButtonUC_PropertyChanged;
            StateChange();
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!IsActive) InactiveState();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!IsActive) ActiveState();
        }

        private void MenuButtonUC_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(IsActive):
                    StateChange();
                    break;
            }
        }

        private void StateChange()
        {
            if (IsActive)
            {
                ActiveState();
            }
            else
            {
                InactiveState();
            }
        }

        private void ActiveState()
        {
            path.Visibility = Visibility.Visible;
            button.Background = Application.Current.Resources["BackgroundLightBrush"] as SolidColorBrush;
            textBlock.Foreground = Application.Current.Resources["BackgroundMediumBrush"] as SolidColorBrush;
        }

        private void InactiveState()
        {
            path.Visibility = Visibility.Hidden;
            button.Background = Application.Current.Resources["BackgroundMediumBrush"] as SolidColorBrush;
            textBlock.Foreground = Application.Current.Resources["BackgroundLightBrush"] as SolidColorBrush;
        }
    }
}
