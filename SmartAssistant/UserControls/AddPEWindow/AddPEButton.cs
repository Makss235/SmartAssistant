﻿using SmartAssistant.Infrastructure.Commands;
using SmartAssistant.UserControls.Base;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;

namespace SmartAssistant.UserControls.AddPEWindow
{
    public class AddPEButton : GroupButton
    {
        internal static event Action<byte> AddPEButtonPressedEvent;

        public AddPEButton(string title, bool isActive, byte id) :
            base(title, isActive, id)
        {

            Button button = new Button()
            {
                Width = 50,
                Height = 50,
                Command = ClickCommand
            };
            Content = button;
        }

        protected override void OnClickCommandExecuted(object sender)
        {
            AddPEButtonPressedEvent?.Invoke(ID);
        }
    }
}
