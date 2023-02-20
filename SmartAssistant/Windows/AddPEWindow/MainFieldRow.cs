using SmartAssistant.UserControls.AddPEWindow.Tabs.AddNameTab;
using System.Windows.Controls;
using System.Windows;
using SmartAssistant.UserControls.AddPEWindow.Tabs.AddCallingNamesTab;
using SmartAssistant.UserControls.AddPEWindow.Tabs.AddPathTab;
using SmartAssistant.UserControls.AddPEWindow;
using SmartAssistant.UserControls.Base;
using System.Collections.Generic;

namespace SmartAssistant.Windows.AddPEWindow
{
    public class MainFieldRow : Grid
    {
        private List<Tab> tabs;

        public MainFieldRow()
        {
            MenuButtonUC.MenuButtonPressedEvent += ChangeVisibilityTabs;
            tabs = new List<Tab>();

            // TODO: Makss width and height dependent from Settings
            AddNameTab addNameTab = new AddNameTab(id: 0, width: 500,
                height: 260, visibility: Visibility.Visible);
            tabs.Add(addNameTab);
            AddCallingNamesTab addCallingNamesTab = new AddCallingNamesTab(id: 1, width: 500,
                height: 260, visibility: Visibility.Hidden);
            tabs.Add(addCallingNamesTab);
            AddPathTab addPathTab = new AddPathTab(id: 2, width: 500,
                height: 260, visibility: Visibility.Hidden);
            tabs.Add(addPathTab);

            Children.Add(addNameTab);
            Children.Add(addCallingNamesTab);
            Children.Add(addPathTab);
        }

        private void ChangeVisibilityTabs(byte id)
        {
            for (int i = 0; i < tabs.Count; i++)
            {
                if (id == tabs[i].ID)
                {
                    tabs[i].Visibility = Visibility.Visible;
                }
                else
                {
                    tabs[i].Visibility = Visibility.Hidden;
                }
            }
        }
    }
}
