﻿using SmartAssistant.UserControls.AddPEWindow;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SmartAssistant.Windows.AddPEWindow
{
    public partial class AddPEWindow : Window
    {
        private List<AddPEGroupButton> addPEGroupButtons;

        private AddPEGroupButton addNameButton;
        private AddPEGroupButton addCallingNamesButton;
        private AddPEGroupButton addPathButton;
        private StackPanel addPEButtonsStackPanel;

        private StackPanel ICAddPEButtonsRow()
        {
            addPEGroupButtons = new List<AddPEGroupButton>();
            MovingToTabEvent += MovingToTabHandler;

            // TODO: Makss localize
            addNameButton = new AddPEGroupButton(addPEWindowLoc.AddPEButtonsLoc.AddNameButtonLoc, true, 0)
            { Margin = new Thickness(0, 0, 20, 0) };
            addNameButton.ButtonPressed += ButtonPressedHandler;
            addPEGroupButtons.Add(addNameButton);

            addCallingNamesButton = new AddPEGroupButton(addPEWindowLoc.AddPEButtonsLoc.AddCallingNamesButtonLoc, false, 1)
            { Margin = new Thickness(0, 0, 20, 0) };
            addCallingNamesButton.ButtonPressed += ButtonPressedHandler;
            addPEGroupButtons.Add(addCallingNamesButton);

            addPathButton = new AddPEGroupButton(addPEWindowLoc.AddPEButtonsLoc.AddPathButtonLoc, false, 2)
            { Margin = new Thickness(0, 0, 20, 0) };
            addPathButton.ButtonPressed += ButtonPressedHandler;
            addPEGroupButtons.Add(addPathButton);

            addPEButtonsStackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(20)
            };
            addPEButtonsStackPanel.Children.Add(addNameButton);
            addPEButtonsStackPanel.Children.Add(addCallingNamesButton);
            addPEButtonsStackPanel.Children.Add(addPathButton);
            return addPEButtonsStackPanel;
        }

        private void ButtonPressedHandler(byte id)
        {
            MovingToTabEvent?.Invoke(id);
        }

        private void MovingToTabHandler(byte id)
        {
            for (int i = 0; i < addPEGroupButtons.Count; i++)
            {
                if (id == addPEGroupButtons[i].ID)
                {
                    addPEGroupButtons[i].IsActive = true;
                    tabs[i].Visibility = Visibility.Visible;
                }
                else
                {
                    addPEGroupButtons[i].IsActive = false;
                    tabs[i].Visibility = Visibility.Hidden;
                }
            }
        }
    }
}
