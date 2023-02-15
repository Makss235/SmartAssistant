using SmartAssistant.Data.ProgramsData;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab
{
    public class CallingNameDGTemplate : DataTemplate
    {
        public CallingNameDGTemplate()
        {
            ProgramObj forTitleProgramObj = new ProgramObj();

            FrameworkElementFactory callingNameDGListBoxFactory = new FrameworkElementFactory(typeof(ListBox));
            callingNameDGListBoxFactory.SetBinding(ListBox.ItemsSourceProperty, new Binding(nameof(forTitleProgramObj.CallingNames)));
            //TODO: Максим SelectedCallingName
            //callingNameDGListBoxFactory.SetBinding(ListBox.SelectedItemProperty, new Binding(nameof(forTitleProgramObj.CallingNames)));
            FrameworkElementFactory callingNameDGAddButtonFactory = new FrameworkElementFactory(typeof(Button));
            callingNameDGAddButtonFactory.SetValue(Button.WidthProperty, (double)25);
            callingNameDGAddButtonFactory.SetValue(Button.ContentProperty, "+");

            FrameworkElementFactory callingNameDGHorizontalStackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
            callingNameDGHorizontalStackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            callingNameDGHorizontalStackPanelFactory.AppendChild(callingNameDGListBoxFactory);
            callingNameDGHorizontalStackPanelFactory.AppendChild(callingNameDGAddButtonFactory);

            FrameworkElementFactory callingNameDGDeleteButton = new FrameworkElementFactory(typeof(Button));
            callingNameDGDeleteButton.SetValue(Button.WidthProperty, (double)25);
            callingNameDGDeleteButton.SetValue(Button.HeightProperty, (double)25);
            callingNameDGDeleteButton.SetValue(Button.ContentProperty, "-");
            callingNameDGDeleteButton.SetValue(Button.StyleProperty, Application.Current.Resources["DGAddRowButtonStyle"]);
            FrameworkElementFactory callingNameDGVerticalStackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
            callingNameDGVerticalStackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Vertical);
            callingNameDGVerticalStackPanelFactory.SetValue(StackPanel.MarginProperty, new Thickness(0, 5, 0, 5));
            callingNameDGVerticalStackPanelFactory.AppendChild(callingNameDGHorizontalStackPanelFactory);
            callingNameDGVerticalStackPanelFactory.AppendChild(callingNameDGDeleteButton);

            VisualTree = callingNameDGVerticalStackPanelFactory;
        }
    }
}
