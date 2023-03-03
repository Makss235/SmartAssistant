using SmartAssistant.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab.ColumnTemplates
{
    public class CallingNamesDGTemplateColumn : DataTemplate
    {
        public CallingNamesDGTemplateColumn()
        {
            ProgramElement forTitleProgramObj = new ProgramElement();

            FrameworkElementFactory callingNameDGListBoxF = new FrameworkElementFactory(typeof(ListBox));
            callingNameDGListBoxF.SetValue(ListBox.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("TransparentBrush"));
            callingNameDGListBoxF.SetValue(ListBox.BorderThicknessProperty, new Thickness(0));
            callingNameDGListBoxF.SetBinding(ItemsControl.ItemsSourceProperty, new Binding(nameof(forTitleProgramObj.CallingNames)));

            //TODO: Максим SelectedCallingName
            //callingNameDGListBoxFactory.SetBinding(ListBox.SelectedItemProperty, new Binding(nameof(forTitleProgramObj.CallingNames)));

            VisualTree = callingNameDGListBoxF;
        }
    }
}
