using SmartAssistant.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.SettingsTab.DataGrid.DGMainElement
{
    public class DataGridCellStyle : Style
    {
        public DataGridCellStyle()
        {
            FrameworkElementFactory contentPresenterFactory = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterFactory.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
            contentPresenterFactory.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);

            FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.SetValue(Border.BackgroundProperty, Application.Current.Resources["TransparentBrush"] as SolidColorBrush);
            borderFactory.SetValue(Border.BorderBrushProperty, Application.Current.Resources["ButtonMouseOverBrush"] as SolidColorBrush);
            borderFactory.SetValue(Border.BorderThicknessProperty, new Thickness(1, 0, 1, 0));
            borderFactory.SetValue(Border.PaddingProperty, new Thickness(5, 0, 5, 3));

            borderFactory.AppendChild(contentPresenterFactory);
            Setters.Add(new Setter(Control.ForegroundProperty, Application.Current.Resources["BackgroundMediumBrush"] as SolidColorBrush));
            Setters.Add(new Setter(Control.TemplateProperty, new ControlTemplate(typeof(DataGridCell))
            {
                VisualTree = borderFactory
            }));

        }
    }
}
