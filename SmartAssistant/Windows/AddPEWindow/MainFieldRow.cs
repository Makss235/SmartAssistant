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

        private ToolTipText errorNameCheckToolTip;
        private ToolTipText errorNameDoneToolTip;
        private ToolTipText errorCNCheckToolTip;
        private ToolTipText errorCNDoneToolTip;

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

                    var startPointToolTip = new Point(Left + 225, Top + 110);
                    errorCNDoneToolTip = new ToolTipText(startPointToolTip, "Вы не указали имена программы", 270);
                    errorCNDoneToolTip.Show(5000);
                }
            }
            else
            {
                MovingToTabEvent?.Invoke(addNameTab.ID);

                var startPointToolTip = new Point(Left + 70, Top + 115);
                errorNameDoneToolTip = new ToolTipText(startPointToolTip, "Вы не указали название программы");
                errorNameDoneToolTip.Show(5000);
            }
        }

        private void SettingsTab_AddPEChecked(bool resultNameChecked, bool resultCNChecked, bool resultPathChecked)
        {
            if (!resultNameChecked)
            {
                addNameTab.IsNormalName = resultNameChecked;
                MovingToTabEvent?.Invoke(addNameTab.ID);

                var startPointToolTip = new Point(Left + 70, Top + 115);
                errorCNCheckToolTip = new ToolTipText(startPointToolTip, "Это название уже занято");
                errorCNCheckToolTip.Show(5000);
            }
            else if (!resultCNChecked)
            {
                addCallingNamesTab.IsNormalCallingName = resultCNChecked;
                MovingToTabEvent?.Invoke(addCallingNamesTab.ID);

                var startPointToolTip = new Point(Left + 225, Top + 110);
                errorNameCheckToolTip = new ToolTipText(startPointToolTip, "Одно или несколько имен уже используются", 270);
                errorNameCheckToolTip.Show(5000);
            }
            else if (!resultPathChecked)
            {
                addPathTab.IsNormalPath = false;
            }
            else Close();
        }
    }
}
