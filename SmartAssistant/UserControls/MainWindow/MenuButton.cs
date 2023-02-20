using SmartAssistant.Infrastructure.Styles.MainWindow;
using SmartAssistant.UserControls.Base;
using SmartAssistant.Windows;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SmartAssistant.UserControls.MainWindow
{
    public class MenuButton : GroupButton
    {
        private Path path;
        private TextBlock textBlock;
        private Button button;

        public static event Action<byte> MenuButtonPressedEvent;

        public MenuButton(string title, bool isActive, byte id) : 
            base(title, isActive, id)
        {
            textBlock = new TextBlock()
            {
                Text = Title
            };

            StackPanel stackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            stackPanel.Children.Add(textBlock);

            button = new Button()
            {
                Height = 45,
                Command = ClickCommand,
                Width = 220,
                Style = new MenuButtonStyle()
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
            Panel.SetZIndex(path, 2);
            

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

        protected override void OnClickCommandExecuted(object sender)
        {
            MenuButtonPressedEvent?.Invoke(ID);
        }
    }
}
