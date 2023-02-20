using SmartAssistant.UserControls.AddPEWindow;
using System.Windows;
using System.Windows.Controls;

namespace SmartAssistant.Windows.AddPEWindow
{
    public class MenuButtonsRow : StackPanel
    {
        public MenuButtonsRow()
        {
            Orientation = Orientation.Horizontal;
            Margin = new Thickness(20);

            AddPEButton addNameMB = new AddPEButton("1", true, 0)
            {
                Margin = new Thickness(0, 0, 20, 0)
            };
            AddPEButton addCallingNamesMB = new AddPEButton("1", true, 1)
            {
                Margin = new Thickness(0, 0, 20, 0)
            };
            AddPEButton addPathMB = new AddPEButton("1", true, 2)
            {
                Margin = new Thickness(0, 0, 20, 0)
            };

            Children.Add(addNameMB);
            Children.Add(addCallingNamesMB);
            Children.Add(addPathMB);
        }
    }
}
