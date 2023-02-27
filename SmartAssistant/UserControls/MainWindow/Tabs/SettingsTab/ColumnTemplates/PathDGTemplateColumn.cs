using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.SettingsTab.DataGrid.DGSimpleElement;

namespace SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab.ColumnTemplates
{
    public class PathDGTemplateColumn : DataTemplate
    {
        public PathDGTemplateColumn()
        {
            ProgramElement programElement = new ProgramElement();
            Binding pathBinding = new Binding(nameof(programElement.Path));
            pathBinding.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;

            FrameworkElementFactory pathDGFactory = new FrameworkElementFactory(typeof(TextBox));
            pathDGFactory.SetBinding(TextBox.TextProperty, pathBinding);
            pathDGFactory.SetValue(Control.BorderThicknessProperty, new Thickness(0));
            pathDGFactory.SetValue(FrameworkElement.WidthProperty, (double)100);
            pathDGFactory.SetValue(TextBox.TextWrappingProperty, TextWrapping.Wrap);
            pathDGFactory.SetValue(FrameworkElement.StyleProperty, new DGNameAndPathTextBoxStyle(pathBinding));

            VisualTree = pathDGFactory;
        }
    }
}
