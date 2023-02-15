using SmartAssistant.Data.ProgramsData;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab
{
    public class NameDGTemplate : DataTemplate
    {
        public NameDGTemplate()
        {
            ProgramObj forTitleProgramObj = new ProgramObj();

            FrameworkElementFactory nameDGFactory = new FrameworkElementFactory(typeof(TextBox));
            nameDGFactory.SetBinding(TextBox.TextProperty, new Binding(nameof(forTitleProgramObj.Name)));
            nameDGFactory.SetValue(TextBox.BorderThicknessProperty, new Thickness(0));
            nameDGFactory.SetValue(TextBox.WidthProperty, (double)100);

            VisualTree = nameDGFactory;
        }
    }
}
