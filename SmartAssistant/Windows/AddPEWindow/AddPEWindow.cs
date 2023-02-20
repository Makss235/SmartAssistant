using SmartAssistant.Data.LocalizationData;
using SmartAssistant.Infrastructure.Commands;
using SmartAssistant.UserControls.AddPEWindow;
using SmartAssistant.UserControls.Base;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SmartAssistant.Windows.AddPEWindow
{
    public class AddPEWindow : Window
    {
        private List<Tab> tabs;

        public AddPEWindow()
        {
            tabs = new List<Tab>();

            Width = 500;
            Height = 350;
            Title = Localize.JsonObject.MainWindowLoc.TitleLoc;

            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            WindowStyle = WindowStyle.None;
            Background = new SolidColorBrush(Colors.Transparent);
            AllowsTransparency = true;

            Grid mainGrid = new Grid();

            RowDefinition menuButtonsRowDefinition = new RowDefinition()
            { Height = new GridLength(90, GridUnitType.Pixel) };
            mainGrid.RowDefinitions.Add(menuButtonsRowDefinition);

            RowDefinition mainFieldRowDefinition = new RowDefinition()
            { Height = new GridLength(260, GridUnitType.Pixel) };
            mainGrid.RowDefinitions.Add(mainFieldRowDefinition);

            AddPEButtonsRow menuButtonsRow = new AddPEButtonsRow();
            Grid.SetRow(menuButtonsRow, 0);
            mainGrid.Children.Add(menuButtonsRow);

            MainFieldRow mainFieldRow = new MainFieldRow();
            Grid.SetRow(mainFieldRow, 1);
            mainGrid.Children.Add(mainFieldRow);

            InputBinding mouseMoveIB = new InputBinding(new DragMoveCommand(this), new MouseGesture()
            { MouseAction = MouseAction.LeftClick });

            Border mainBorder = new Border()
            {
                Background = new SolidColorBrush(Colors.AliceBlue),
                CornerRadius = new CornerRadius(20, 20, 20, 20),
                BorderThickness = new Thickness(4),
                BorderBrush = Application.Current.Resources["BackgroundMediumBrush"] as SolidColorBrush
            };
            mainBorder.InputBindings.Add(mouseMoveIB);
            mainBorder.Child = mainGrid;

            Content = mainBorder;
        }
    }
}
