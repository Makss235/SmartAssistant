using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace SmartAssistant
{
    class MyWindow : Window
    {
        public MyWindow()
        {
            Width = 500;
            Height = 300;
            Title = "My Simple Window";
            Grid grid = new Grid();
            IAddChild add = grid;
            Button button = new Button();
            button.Content = "hhhh";
            add.AddChild(button);
            IAddChild addChild = this;
            addChild.AddChild(grid);
        }
    }

    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Window myWin = new MyWindow();
            myWin.Show();
            Application myApp = new Application();
            myApp.Run();
        }
    }
}
