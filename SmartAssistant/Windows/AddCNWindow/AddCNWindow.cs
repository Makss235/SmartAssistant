using SmartAssistant.Infrastructure.Commands;
using SmartAssistant.Infrastructure.Styles.Base;
using SmartAssistant.Resources;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace SmartAssistant.Windows.AddCNWindow
{
    public class AddCNWindow : Window
    {
        private InputBinding dragMoveIB;
        private DropShadowEffect dropShadowEffect;

        private TextBox enterCNTextBox;
        private Button addCNButton;
        private Grid mainGrid;
        private Border mainBorder;

        public event Action<string> AddCallingNameEvent;

        public AddCNWindow(Point point)
        {
            Width = 450;
            Height = 110;

            KeyBinding keyBinding = new KeyBinding()
            {
                Command = new LambdaCommand((s) => AddCallingName(), (s) => true),
                Key = Key.Enter
            };
            InputBindings.Add(keyBinding);

            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.Manual;
            Left = point.X + 330;
            Top = point.Y + 80;

            WindowStyle = WindowStyle.None;
            Background = new SolidColorBrush(Colors.Transparent);
            AllowsTransparency = true;

            dropShadowEffect = new DropShadowEffect()
            {
                ShadowDepth = 0,
                BlurRadius = 15,
                Opacity = 0.5
            };
            Effect = dropShadowEffect;

            enterCNTextBox = new TextBox()
            {
                Background = ResApp.GetResources<SolidColorBrush>("Transparent"),
                BorderThickness = new Thickness(0),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(20, 0, 20, 0),
                Width = 360,
                FontFamily = new FontFamily("Segoe UI Semibold"),
                FontSize = 15,
                Padding = new Thickness(0, 0, 30, 0)
            };

            addCNButton = new Button()
            {
                Background = ResApp.GetResources<SolidColorBrush>("Transparent"),
                BorderThickness= new Thickness(0),
                Content = "\"галк\nочка\"",
                Padding = new Thickness(0, 0, 4, 8),
                FontSize = 12,
                Width = 50,
                Height = 50,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Right,
                Style = new RoundedButton(
                    new CornerRadius(0, 20, 20, 0),
                    new Thickness(0),
                    ResApp.GetResources<SolidColorBrush>("Transparent"),
                    ResApp.GetResources<SolidColorBrush>("CommonMediumBrush"),
                    ResApp.GetResources<SolidColorBrush>("Transparent"),
                    ResApp.GetResources<SolidColorBrush>("Transparent"),
                    ResApp.GetResources<SolidColorBrush>("CommonDarkBrush"),
                    ResApp.GetResources<SolidColorBrush>("Transparent")
                    )
            };
            addCNButton.Click += (s, e) => AddCallingName();

            mainGrid = new Grid();
            mainGrid.Children.Add(enterCNTextBox);
            mainGrid.Children.Add(addCNButton);

            dragMoveIB = new InputBinding(new DragMoveCommand(this), new MouseGesture()
            { MouseAction = MouseAction.LeftClick });

            mainBorder = new Border()
            {
                Background = ResApp.GetResources<SolidColorBrush>("CommonLightBrush"),
                CornerRadius = new CornerRadius(20),
                Width = 400,
                Height = 50,
                //BorderThickness = new Thickness(3),
                //BorderBrush = ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")
            };
            mainBorder.InputBindings.Add(dragMoveIB);
            mainBorder.Child = mainGrid;
            enterCNTextBox.Focus();

            Content = mainBorder;
        }

        private void AddCallingName()
        {
            if (enterCNTextBox.Text.Length != 0)
            {
                AddCallingNameEvent?.Invoke(enterCNTextBox.Text);
                Hide();
            }
        }
    }
}
