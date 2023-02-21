using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.SettingsTab.DataGrid.DGSimpleElement;

namespace SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab
{
    public class PathDGTemplate : DataTemplate
    {
        public PathDGTemplate()
        {
            ProgramElement programElement = new ProgramElement();
            Binding pathBinding = new Binding(nameof(programElement.Path));
            pathBinding.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;

            FrameworkElementFactory pathDGFactory = new FrameworkElementFactory(typeof(TextBox));
            pathDGFactory.SetBinding(TextBox.TextProperty, pathBinding);
            pathDGFactory.SetValue(TextBox.BorderThicknessProperty, new Thickness(0));
            pathDGFactory.SetValue(TextBox.WidthProperty, (double)100);
            pathDGFactory.SetValue(TextBox.TextWrappingProperty, TextWrapping.Wrap);
            pathDGFactory.SetValue(TextBox.StyleProperty, new DGNameAndPathTextBoxStyle(pathBinding));
            
            VisualTree = pathDGFactory;
        }
    }
}
