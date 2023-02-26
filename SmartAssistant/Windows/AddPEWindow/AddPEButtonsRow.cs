using SmartAssistant.UserControls.AddPEWindow;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SmartAssistant.Windows.AddPEWindow
{
    public class AddPEButtonsRow : StackPanel
    {
        List<AddPEGroupButton> addPEGroupButtons;

        public AddPEButtonsRow()
        {
            addPEGroupButtons = new List<AddPEGroupButton>();

            TabNavigationButton.OnButtonPressed += TabNavigationButton_OnButtonPressed;
            AddPEGroupButton.AddPEButtonPressed += TabNavigationButton_OnButtonPressed;
            MainFieldRow.abc += TabNavigationButton_OnButtonPressed;
            Orientation = Orientation.Horizontal;
            Margin = new Thickness(20);

            // TODO: Makss localize
            AddPEGroupButton addNameButton = new AddPEGroupButton("Название", true, 0)
            { Margin = new Thickness(0, 0, 20, 0) };
            addPEGroupButtons.Add(addNameButton);
            AddPEGroupButton addCallingNamesButton = new AddPEGroupButton("Как будете звать?", false, 1)
            { Margin = new Thickness(0, 0, 20, 0) };
            addPEGroupButtons.Add(addCallingNamesButton);
            AddPEGroupButton addPathButton = new AddPEGroupButton("Путь", false, 2)
            { Margin = new Thickness(0, 0, 20, 0) };
            addPEGroupButtons.Add(addPathButton);

            Children.Add(addNameButton);
            Children.Add(addCallingNamesButton);
            Children.Add(addPathButton);
        }

        private void TabNavigationButton_OnButtonPressed(byte id)
        {
            // TODO: Veser реакция на нажатие кнопки
            for (int i = 0; i < addPEGroupButtons.Count; i++)
            {
                if (id == addPEGroupButtons[i].ID)
                {
                    //MessageBox.Show(id.ToString());
                }
                else
                {
                    
                }
            }
        }
    }
}
