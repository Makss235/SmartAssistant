using SmartAssistant.Data.ProgramsData;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.SettingsTab.DataGrid.DGSimpleElement;

namespace SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab
{
    public class NameDGTemplate : DataTemplate
    {
        public NameDGTemplate()
        {
            ProgramElement programElement = new ProgramElement();
            Binding nameBinding = new Binding(nameof(programElement.Name));
            nameBinding.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;

            FrameworkElementFactory nameDGFactory = new FrameworkElementFactory(typeof(TextBox));
            //nameDGFactory.SetBinding(TextBox.TextProperty, nameBinding);
            nameDGFactory.SetValue(TextBox.BorderThicknessProperty, new Thickness(0));
            nameDGFactory.SetValue(TextBox.WidthProperty, (double)100);
            nameDGFactory.SetValue(TextBox.StyleProperty, new DGNameAndPathTextBoxStyle(nameBinding));

            VisualTree = nameDGFactory;
        }
    }
}
