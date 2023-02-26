using SmartAssistant.UserControls.AddPEWindow;
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
    public class MainFieldRow : Grid
    {
        private AddNameTab addNameTab;
        private AddCallingNamesTab addCallingNamesTab;
        private AddPathTab addPathTab;
        private List<Tab> tabs;

        public static event Action<byte> abc;
        public static event Action<ProgramElement> privet;

        public MainFieldRow()
        {
            AddPEGroupButton.AddPEButtonPressed += ChangeVisibilityTabs;
            TabNavigationButton.OnButtonPressed += ChangeVisibilityTabs;
            abc += ChangeVisibilityTabs;
            tabs = new List<Tab>();

            // TODO: Makss width and height dependent from Settings
            addNameTab = new AddNameTab(id: 0, width: 500,
                height: 260, visibility: Visibility.Visible);
            tabs.Add(addNameTab);
            addCallingNamesTab = new AddCallingNamesTab(id: 1, width: 500,
                height: 260, visibility: Visibility.Hidden);
            tabs.Add(addCallingNamesTab);
            addPathTab = new AddPathTab(id: 2, width: 500,
                height: 260, visibility: Visibility.Hidden);
            tabs.Add(addPathTab);
            addPathTab.DoneButtonPressed += AddPathTab_DoneButtonPressed;

            Children.Add(addNameTab);
            Children.Add(addCallingNamesTab);
            Children.Add(addPathTab);
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
                        privet?.Invoke(programElement);
                    }
                    else
                    {
                        abc?.Invoke(addPathTab.ID);
                    }
                }
                else
                {
                    abc?.Invoke(addCallingNamesTab.ID);
                }
            }
            else
            {
                abc?.Invoke(addNameTab.ID);
            }
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
