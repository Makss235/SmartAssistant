using SmartAssistant.UserControls.Base;
using System.Windows;
using System.Windows.Controls;

namespace SmartAssistant.UserControls.AddPEWindow.Tabs.AddCallingNamesTab
{
    public class AddCallingNamesTab : Tab
    {
        public AddCallingNamesTab(byte id, double width, double height, Visibility visibility)
        {
            ID = id;
            Width = width;
            Height = height;
            Visibility = visibility;

            TextBlock textBlock = new TextBlock()
            {
                Text = "sobaka yadryonaya22222222222"
            };

            Grid mainGrid = new Grid();
            mainGrid.Children.Add(textBlock);
            Content = mainGrid;
        }
    }
}
