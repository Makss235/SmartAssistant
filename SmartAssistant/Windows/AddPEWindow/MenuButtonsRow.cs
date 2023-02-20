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

            MenuButtonUC addNameMB = new MenuButtonUC("1", true, 0)
            {
                Margin = new Thickness(0, 0, 20, 0)
            };
            MenuButtonUC addCallingNamesMB = new MenuButtonUC("1", true, 1)
            {
                Margin = new Thickness(0, 0, 20, 0)
            };
            MenuButtonUC addPathMB = new MenuButtonUC("1", true, 2)
            {
                Margin = new Thickness(0, 0, 20, 0)
            };

            Children.Add(addNameMB);
            Children.Add(addCallingNamesMB);
            Children.Add(addPathMB);
        }
    }
}
