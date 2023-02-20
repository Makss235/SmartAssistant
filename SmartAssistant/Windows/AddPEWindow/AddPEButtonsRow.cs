using SmartAssistant.UserControls.AddPEWindow;
using System.Windows;
using System.Windows.Controls;

namespace SmartAssistant.Windows.AddPEWindow
{
    public class AddPEButtonsRow : StackPanel
    {
        public AddPEButtonsRow()
        {
            Orientation = Orientation.Horizontal;
            Margin = new Thickness(20);

            // TODO: Makss localize
            AddPEButton addNameButton = new AddPEButton("Название", true, 0)
            { Margin = new Thickness(0, 0, 20, 0) };
            AddPEButton addCallingNamesButton = new AddPEButton("Как будете звать?", false, 1)
            { Margin = new Thickness(0, 0, 20, 0) };
            AddPEButton addPathButton = new AddPEButton("Путь", false, 2)
            { Margin = new Thickness(0, 0, 20, 0) };

            Children.Add(addNameButton);
            Children.Add(addCallingNamesButton);
            Children.Add(addPathButton);
        }
    }
}
