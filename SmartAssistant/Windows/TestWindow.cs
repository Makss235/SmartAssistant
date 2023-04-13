using SmartAssistant.UserControls.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SmartAssistant.Windows
{
    public class TestWindow : Window
    {
        public TestWindow()
        {
            SButton sButton = new SButton();
            Content = sButton;
        }
    }
}
