using SmartAssistant.Infrastructure.Styles.MainWindow;
using SmartAssistant.Resources;
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
        private TextBlock titleMenuButton;
        private StackPanel titleAndIconStackPanel;
        private Button button;
        private StreamGeometry roundingGeometry;
        private Path roundingPath;
        private Grid roundingGrid;
        private Grid mainGrid;

        public override event Action<byte> ButtonPressed;

        public MenuButton(string title, bool isActive, byte id) 
            : base(title, isActive, id)
        {
            InitializeComponent();

            PropertyChanged += MenuButton_PropertyChanged;
            StateChange();
        }

        private void InitializeComponent()
        {
            titleMenuButton = new TextBlock()
            { Text = Title };

            titleAndIconStackPanel = new StackPanel()
            { Orientation = Orientation.Horizontal };
            titleAndIconStackPanel.Children.Add(titleMenuButton);

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
            addChild.AddChild(titleAndIconStackPanel);
            Panel.SetZIndex(button, 1);

            roundingGeometry = new StreamGeometry();
            using (StreamGeometryContext ctx = roundingGeometry.Open())
            {
                ctx.BeginFigure(new Point(0, 20.7), true, true);
                ctx.BezierTo(new Point(15, 20), new Point(26.5, 12), new Point(27, 0), true, true);
                ctx.LineTo(new Point(27, 87.6), true, true);
                ctx.BezierTo(new Point(26, 75), new Point(15.1, 67.5), new Point(0, 67), true, true);
                ctx.LineTo(new Point(0, 24), true, true);
            }
            roundingGeometry.Freeze();

            roundingPath = new Path()
            {
                Fill = ResApp.GetResources<SolidColorBrush>("CommonLightBrush"),
                Stretch = Stretch.Fill,
                Data = roundingGeometry,
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(0, 0, -1, 0)
            };
            Panel.SetZIndex(roundingPath, 2);

            roundingGrid = new Grid()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Width = 20,
                Height = 85,
                Visibility = Visibility.Visible
            };
            roundingGrid.Children.Add(roundingPath);

            mainGrid = new Grid()
            {
                Margin = new Thickness(0, -17, 0, -17),
                Width = 220
            };
            mainGrid.Children.Add(button);
            mainGrid.Children.Add(roundingGrid);

            Content = mainGrid;
        }

        protected override void OnClickCommandExecuted(object sender)
        {
            ButtonPressed?.Invoke(ID);
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!IsActive) InactiveState();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!IsActive) ActiveState();
        }

        private void MenuButton_PropertyChanged(object? sender, PropertyChangedEventArgs e)
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
            if (IsActive) ActiveState();
            else InactiveState();
        }

        private void ActiveState()
        {
            roundingPath.Visibility = Visibility.Visible;
            button.Background = ResApp.GetResources<SolidColorBrush>("CommonLightBrush");
            titleMenuButton.Foreground = ResApp.GetResources<SolidColorBrush>("CommonMediumBrush");
        }

        private void InactiveState()
        {
            roundingPath.Visibility = Visibility.Hidden;
            button.Background = ResApp.GetResources<SolidColorBrush>("CommonMediumBrush");
            titleMenuButton.Foreground = ResApp.GetResources<SolidColorBrush>("CommonLightBrush");
        }
    }
}
