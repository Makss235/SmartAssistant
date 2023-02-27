using SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.SettingsTab.DataGrid.DGSimpleElement;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab.ColumnTemplates
{
    public class NameDGTemplateColumn : DataTemplate
    {
        public NameDGTemplateColumn()
        {
            ProgramElement programElement = new ProgramElement();
            Binding nameBinding = new Binding(nameof(programElement.Name));
            nameBinding.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;

            FrameworkElementFactory nameDGFactory = new FrameworkElementFactory(typeof(TextBox));
            //nameDGFactory.SetBinding(TextBox.TextProperty, nameBinding);
            nameDGFactory.SetValue(Control.BorderThicknessProperty, new Thickness(0));
            nameDGFactory.SetValue(FrameworkElement.WidthProperty, (double)100);
            nameDGFactory.SetValue(FrameworkElement.StyleProperty, new DGNameAndPathTextBoxStyle(nameBinding));

            VisualTree = nameDGFactory;
        }
    }
}
