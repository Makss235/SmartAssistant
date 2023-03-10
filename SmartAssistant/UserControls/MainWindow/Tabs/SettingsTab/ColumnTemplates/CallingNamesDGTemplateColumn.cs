using SmartAssistant.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab.ColumnTemplates
{
    public class CallingNamesDGTemplateColumn : DataTemplate
    {
        public CallingNamesDGTemplateColumn()
        {
            ProgramElement forTitleProgramElement = new ProgramElement();

            FrameworkElementFactory callingNameDGListBoxF = new FrameworkElementFactory(typeof(ListBox));
            callingNameDGListBoxF.SetValue(ListBox.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("TransparentBrush"));
            callingNameDGListBoxF.SetValue(ListBox.BorderThicknessProperty, new Thickness(0));
            callingNameDGListBoxF.SetBinding(ItemsControl.ItemsSourceProperty, new Binding(nameof(forTitleProgramElement.CallingNames)));

            //TODO: Максим SelectedCallingName
            //callingNameDGListBoxFactory.SetBinding(ListBox.SelectedItemProperty, new Binding(nameof(forTitleProgramObj.CallingNames)));

            VisualTree = callingNameDGListBoxF;
        }
    }
}
