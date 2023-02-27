using SmartAssistant.UserControls.AddPEWindow.Tabs.AddCallingNamesTab;
using SmartAssistant.UserControls.AddPEWindow.Tabs.AddNameTab;
using SmartAssistant.UserControls.AddPEWindow.Tabs.AddPathTab;
using SmartAssistant.UserControls.Base;
using SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SmartAssistant.Windows.AddPEWindow
{
    public partial class AddPEWindow : Window
    {
        private List<Tab> tabs;

        private AddNameTab addNameTab;
        private AddCallingNamesTab addCallingNamesTab;
        private AddPathTab addPathTab;
        private Grid mainFieldGrid;

        public static event Action<ProgramElement> AddPEDone;
        public event Action<byte> MovingToTabEvent;

        private Grid ICMainFieldRow()
        {
            tabs = new List<Tab>();

            // TODO: Makss width and height dependent from Settings
            addNameTab = new AddNameTab(id: 0, width: 500,
                height: 260, visibility: Visibility.Visible);
            addNameTab.TabNavigationButtonPressed += TabNavigationButtonPressedHandler;
            tabs.Add(addNameTab);

            addCallingNamesTab = new AddCallingNamesTab(id: 1, width: 500,
                height: 260, visibility: Visibility.Hidden);
            addCallingNamesTab.TabNavigationButtonPressed += TabNavigationButtonPressedHandler;
            tabs.Add(addCallingNamesTab);

            addPathTab = new AddPathTab(id: 2, width: 500,
                height: 260, visibility: Visibility.Hidden);
            addPathTab.TabNavigationButtonPressed += TabNavigationButtonPressedHandler;
            tabs.Add(addPathTab);
            addPathTab.DoneButtonPressed += AddPathTab_DoneButtonPressed;

            mainFieldGrid = new Grid();
            mainFieldGrid.Children.Add(addNameTab);
            mainFieldGrid.Children.Add(addCallingNamesTab);
            mainFieldGrid.Children.Add(addPathTab);
            return mainFieldGrid;
        }

        private void TabNavigationButtonPressedHandler(byte id)
        {
            MovingToTabEvent?.Invoke(id);
        }

        private void AddPathTab_DoneButtonPressed()
        {
            if (addNameTab.IsNormalName)
            {
                if (addCallingNamesTab.CallingNames.Count != 0)
                {
                    if (!Equals(addPathTab.EnteredPath, string.IsNullOrEmpty))
                    {
                        ProgramElement programElement = new ProgramElement(
                            addNameTab.EnteredName,
                            addCallingNamesTab.CallingNames,
                            addPathTab.EnteredPath);
                        AddPEDone?.Invoke(programElement);
                        Close();
                    }
                    else MovingToTabEvent?.Invoke(addPathTab.ID);
                }
                else MovingToTabEvent?.Invoke(addCallingNamesTab.ID);
            }
            else MovingToTabEvent?.Invoke(addNameTab.ID);
        }
    }
}
