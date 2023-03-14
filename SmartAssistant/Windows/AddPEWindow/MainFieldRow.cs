using SmartAssistant.UserControls.AddPEWindow.Tabs.AddCallingNamesTab;
using SmartAssistant.UserControls.AddPEWindow.Tabs.AddNameTab;
using SmartAssistant.UserControls.AddPEWindow.Tabs.AddPathTab;
using SmartAssistant.UserControls.Base;
using SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab;
using SmartAssistant.UserControls.Widgets;
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

        public event Action<ProgramElement> AddPEDone;
        public event Action<byte> MovingToTabEvent;

        private Grid ICMainFieldRow()
        {
            tabs = new List<Tab>();
            sender.AddPEChecked += SettingsTab_AddPEChecked;

            // TODO: Makss width and height dependent from Settings
            addNameTab = new AddNameTab(id: 0, width: 500,
                height: 260, visibility: Visibility.Visible);
            addNameTab.TabNavigationButtonPressed += TabNavigationButtonPressedHandler;
            addNameTab.CorrectnessTextChanged += TabCorrectnessTextChanged;
            tabs.Add(addNameTab);

            addCallingNamesTab = new AddCallingNamesTab(id: 1, width: 500,
                height: 260, visibility: Visibility.Hidden);
            addCallingNamesTab.TabNavigationButtonPressed += TabNavigationButtonPressedHandler;
            addCallingNamesTab.CorrectnessTextChanged += TabCorrectnessTextChanged;
            tabs.Add(addCallingNamesTab);

            addPathTab = new AddPathTab(id: 2, width: 500,
                height: 260, visibility: Visibility.Hidden);
            addPathTab.TabNavigationButtonPressed += TabNavigationButtonPressedHandler;
            addPathTab.CorrectnessTextChanged += TabCorrectnessTextChanged;
            addPathTab.DoneButtonPressed += AddPathTab_DoneButtonPressed;
            tabs.Add(addPathTab);

            mainFieldGrid = new Grid();
            mainFieldGrid.Children.Add(addNameTab);
            mainFieldGrid.Children.Add(addCallingNamesTab);
            mainFieldGrid.Children.Add(addPathTab);
            return mainFieldGrid;
        }

        private void TabCorrectnessTextChanged(byte id, bool isCorrect)
        {
            for (int i = 0; i < addPEGroupButtons.Count; i++)
            {
                if (id == addPEGroupButtons[i].ID)
                {
                    addPEGroupButtons[i].IsCorrect = isCorrect;
                }
            }
        }

        private void TabNavigationButtonPressedHandler(byte id)
        {
            MovingToTabEvent?.Invoke(id);
        }

        private void AddPathTab_DoneButtonPressed()
        {
            if (addNameTab.IsNormalName)
            {
                // TODO: Makss сделать доп свойство для CallingNames
                if (addCallingNamesTab.CallingNames.Count != 0)
                {
                    if (addPathTab.IsNormalPath)
                    {
                        ProgramElement programElement = new ProgramElement(
                            addNameTab.EnteredName,
                            addCallingNamesTab.CallingNames,
                            addPathTab.EnteredPath);
                        AddPEDone?.Invoke(programElement);
                    }
                }
                else
                {
                    addCallingNamesTab.IsNormalCallingName = false;
                    MovingToTabEvent?.Invoke(addCallingNamesTab.ID);
                }
            }
            else MovingToTabEvent?.Invoke(addNameTab.ID);
        }

        private void SettingsTab_AddPEChecked(bool arg1, bool arg2, bool arg3)
        {
            if (!arg1)
            {
                addNameTab.IsNormalName = arg1;
                MovingToTabEvent?.Invoke(addNameTab.ID);

                var point = new Point(Left + 70, Top + 115);
                ToolTipText popupToolTip = new ToolTipText(point, "Это имя уже занято");
                popupToolTip.Show(5000);
            }
            else if (!arg2)
            {
                addCallingNamesTab.IsNormalCallingName = arg2;
                MovingToTabEvent?.Invoke(addCallingNamesTab.ID);

                var point = new Point(Left + 225, Top + 110);
                ToolTipText popupToolTip = new ToolTipText(point, "Одно или несколько имен уже заняты", 250);
                popupToolTip.Show(5000);
            }
            else if (!arg3)
            {
                addPathTab.IsNormalPath = false;
            }
            else Close();
        }
    }
}
