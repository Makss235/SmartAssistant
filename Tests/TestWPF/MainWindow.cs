﻿using SmartAssistant.UserControls.Widgets;
using System.Windows;

namespace TestWPF
{
    internal class MainWindow : Window
    {
        public MainWindow()
        {
            var a = new SExpander();
            Content = a;
        }
    }
}
