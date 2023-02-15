using SmartAssistant.Data.ProgramsData;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab
{
    public class PathDGTemplate : DataTemplate
    {
        public PathDGTemplate()
        {
            ProgramObj forTitleProgramObj = new ProgramObj();

            FrameworkElementFactory pathDGFactory = new FrameworkElementFactory(typeof(TextBox));
            pathDGFactory.SetBinding(TextBox.TextProperty, new Binding(nameof(forTitleProgramObj.Path)));
            pathDGFactory.SetValue(TextBox.BorderThicknessProperty, new Thickness(0));
            pathDGFactory.SetValue(TextBox.WidthProperty, (double)100);
            pathDGFactory.SetValue(TextBox.TextWrappingProperty, TextWrapping.Wrap);

            VisualTree = pathDGFactory;
        }
    }
}
