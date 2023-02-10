using SmartAssistant.UserControls.MainWindow.Tabs.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.UserControls.MainWindow.Tabs.VAChatTab
{
    public class VAChatTab : Tab
    {
        public VAChatTab(byte id, double width, double height, Visibility visibility)
        {
            ID = id;
            Width = width;
            Height = height;
            Visibility = visibility;

            TextBlock textBlock = new TextBlock();
            textBlock.Text = "jjjjjjjjjjj";
            textBlock.FontSize = 20;

            Grid mainGrid = new Grid()
            {
                Margin = new Thickness(20, 0, 0, 0)
            };
            mainGrid.Children.Add(textBlock);

            Border mainBorder = new Border()
            {
                Background = new SolidColorBrush(Colors.Transparent)
            };
            mainBorder.Child = mainGrid;
            Content = mainBorder;
        }
    }
}
