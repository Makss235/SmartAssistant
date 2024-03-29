﻿using SmartAssistant.Data.LocalizationData;
using SmartAssistant.Infrastructure.Commands;
using SmartAssistant.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SmartAssistant.Windows.MainWindow
{
    public partial class MainWindow : Window
    {
        private TextBlock titleApp;
        private Grid headingMenuGrid;
        private Border headingMenuColBorder;

        private Border ICHeadingMenuCol()
        {
            titleApp = new TextBlock()
            {
                // TODO: RE возможен стиль
                Text = Localize.JsonObject.MainWindowLoc.TitleLoc,
                Foreground = ResApp.GetResources<SolidColorBrush>("CommonLightBrush"),
                Background = ResApp.GetResources<SolidColorBrush>("Transparent"),
                FontFamily = new FontFamily("Segoe UI Semibold"),
                FontSize = 14,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 25, 0, 0),
                LayoutTransform = new RotateTransform() { Angle = 90 }
            };

            headingMenuGrid = new Grid();
            headingMenuGrid.Children.Add(titleApp);

            dragMoveIB = new InputBinding(
                new DragMoveCommand(this), new MouseGesture()
                { MouseAction = MouseAction.LeftClick });

            headingMenuColBorder = new Border()
            {
                Background = ResApp.GetResources<SolidColorBrush>("CommonDarkBrush"),
                CornerRadius = new CornerRadius(20)
            };
            headingMenuColBorder.InputBindings.Add(dragMoveIB);
            headingMenuColBorder.Child = headingMenuGrid;
            return headingMenuColBorder;
        }  
    }
}
