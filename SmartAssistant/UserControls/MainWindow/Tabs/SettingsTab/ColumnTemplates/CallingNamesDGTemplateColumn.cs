using SmartAssistant.Infrastructure.Styles.Base;
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
            callingNameDGListBoxF.SetBinding(ItemsControl.ItemsSourceProperty, new Binding(nameof(forTitleProgramObj.CallingNames)));
            callingNameDGListBoxF.SetValue(ListBox.StyleProperty, new CommonListBoxStyle(
                new CornerRadius(0),
                new Thickness(0),
                ResApp.GetResources<SolidColorBrush>("Transparent"),
                ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")));
            callingNameDGListBoxF.SetValue(ListBox.ItemContainerStyleProperty, new CommonListBoxItemStyle(
                new CornerRadius(10),
                new Thickness(2),
                ResApp.GetResources<SolidColorBrush>("DarkerBrush"),
                ResApp.GetResources<SolidColorBrush>("Transparent"),
                ResApp.GetResources<SolidColorBrush>("Transparent"),
                ResApp.GetResources<SolidColorBrush>("Transparent"),
                ResApp.GetResources<SolidColorBrush>("CommonMediumBrush"),
                ResApp.GetResources<SolidColorBrush>("FadedBrush"),
                ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")));

            //TODO: Максим SelectedCallingName
            //callingNameDGListBoxFactory.SetBinding(ListBox.SelectedItemProperty, new Binding(nameof(forTitleProgramObj.CallingNames)));

            VisualTree = callingNameDGListBoxF;
        }
    }
}
