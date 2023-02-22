using SmartAssistant.UserControls.AddPEWindow;
using System.Windows;
using System.Windows.Controls;
using SmartAssistant.Infrastructure.Styles;
using System.Windows.Media;

namespace SmartAssistant.Windows.AddPEWindow
{
    public class AddPEButtonsRow : StackPanel
    {
        public AddPEButtonsRow()
        {
            Orientation = Orientation.Horizontal;
            Margin = new Thickness(20);

            // TODO: Makss localize
            AddPEGroupButton addNameButton = new AddPEGroupButton("Название", true, 0)
            { Margin = new Thickness(0, 0, 20, 0) };
            AddPEGroupButton addCallingNamesButton = new AddPEGroupButton("Как будете звать?", false, 1)
            { Margin = new Thickness(0, 0, 20, 0) };
            AddPEGroupButton addPathButton = new AddPEGroupButton("Путь", false, 2)
            { Margin = new Thickness(0, 0, 20, 0) };

            Children.Add(addNameButton);
            Children.Add(addCallingNamesButton);
            Children.Add(addPathButton);
        }
    }
}
