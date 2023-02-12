using SmartAssistant.Data.Localization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SmartAssistant.Windows.MainWindow
{
    public class HeadingMenu
    {
        public Border HeadingMenuBorder { get; set; }

        public HeadingMenu(ICommand mouseMoveCommand)
        {
            TextBlock title = new TextBlock()
            {
                Text = Localize.LocObj.MainWindowLoc.TitleLoc,
                Foreground = BasicColors.ForegroundWhiteColor,
                Background = new SolidColorBrush(Colors.Transparent),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 25, 0, 0),
                FontFamily = new FontFamily("Segoe UI Semibold"),
                FontSize = 14,
                FontWeight = FontWeights.SemiBold,
                LayoutTransform = new RotateTransform() { Angle = 90 }
            };

            Grid headingMenuGrid = new Grid();
            headingMenuGrid.Children.Add(title);

            InputBinding mouseMoveIB = new InputBinding(mouseMoveCommand, new MouseGesture()
            { MouseAction = MouseAction.LeftClick });

            HeadingMenuBorder = new Border()
            {
                Background = BasicColors.BackgroundDarkBrush,
                CornerRadius = new CornerRadius(20)
            };
            HeadingMenuBorder.InputBindings.Add(mouseMoveIB);
            HeadingMenuBorder.Child = headingMenuGrid;
        }
    }
}
