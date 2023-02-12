using System.Collections.Generic;
using System.Windows;

namespace SmartAssistant.Models.Skills
{
    public class Programs
    {
        public bool OpenProgram(string text, List<string> args)
        {
            MessageBox.Show(text);
            return true;
        }
    }
}
