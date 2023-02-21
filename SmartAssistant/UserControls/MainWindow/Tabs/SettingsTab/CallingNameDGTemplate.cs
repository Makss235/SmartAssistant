using SmartAssistant.Data.ProgramsData;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.SettingsTab.DataGrid.DGSimpleElement;

namespace SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab
{
    public class CallingNameDGTemplate : DataTemplate
    {
        public CallingNameDGTemplate()
        {
            ProgramElement forTitleProgramObj = new ProgramElement();

            FrameworkElementFactory callingNameDGListBoxFactory = new FrameworkElementFactory(typeof(ListBox));
            callingNameDGListBoxFactory.SetBinding(ListBox.ItemsSourceProperty, new Binding(nameof(forTitleProgramObj.CallingNames)));
            //TODO: Максим SelectedCallingName
            //callingNameDGListBoxFactory.SetBinding(ListBox.SelectedItemProperty, new Binding(nameof(forTitleProgramObj.CallingNames)));

            FrameworkElementFactory callingNameTextBoxFactory = new FrameworkElementFactory(typeof(TextBox));
            callingNameTextBoxFactory.SetValue(TextBox.WidthProperty, (double)50);
            FrameworkElementFactory callingNameDGAddButtonFactory = new FrameworkElementFactory(typeof(Button));
            callingNameDGAddButtonFactory.SetValue(Button.WidthProperty, (double)25);
            callingNameDGAddButtonFactory.SetValue(Button.ContentProperty, "+");
            callingNameDGAddButtonFactory.SetValue(Button.StyleProperty, new DGCallingNameButtonStyle(new CornerRadius(0, 10, 10, 0), (double)20, new Thickness(1)));

            FrameworkElementFactory callingNameDGHorizontalStackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
            callingNameDGHorizontalStackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            callingNameDGHorizontalStackPanelFactory.AppendChild(callingNameTextBoxFactory);
            callingNameDGHorizontalStackPanelFactory.AppendChild(callingNameDGAddButtonFactory);

            FrameworkElementFactory callingNameDGDeleteButton = new FrameworkElementFactory(typeof(Button));
            callingNameDGDeleteButton.SetValue(Button.WidthProperty, (double)25);
            callingNameDGDeleteButton.SetValue(Button.HeightProperty, (double)25);
            callingNameDGDeleteButton.SetValue(Button.ContentProperty, "-");
            callingNameDGDeleteButton.SetValue(Button.StyleProperty, new DGCallingNameButtonStyle(new CornerRadius(10), (double)30, new Thickness(-1, -12, -1, 0)));

            FrameworkElementFactory callingNameDGVerticalStackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
            callingNameDGVerticalStackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Vertical);
            callingNameDGVerticalStackPanelFactory.SetValue(StackPanel.MarginProperty, new Thickness(0, 5, 0, 5));
            callingNameDGVerticalStackPanelFactory.AppendChild(callingNameDGListBoxFactory);
            callingNameDGVerticalStackPanelFactory.AppendChild(callingNameDGHorizontalStackPanelFactory);
            callingNameDGVerticalStackPanelFactory.AppendChild(callingNameDGDeleteButton);

            //FrameworkElementFactory a = new FrameworkElementFactory(typeof(Class1));

            VisualTree = callingNameDGVerticalStackPanelFactory;
        }
    }
}
