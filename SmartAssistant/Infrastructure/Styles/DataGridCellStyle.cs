using SmartAssistant.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SmartAssistant
{
    public class DataGridCellStyle : Style
    {
        public DataGridCellStyle() 
        {
            FrameworkElementFactory contentPresenterFactory = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterFactory.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
            contentPresenterFactory.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);

            FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.SetValue(Border.BackgroundProperty, BasicColors.TransparentBrush);
            borderFactory.SetValue(Border.BorderBrushProperty, BasicColors.ButtonMouseOverBrush);
            borderFactory.SetValue(Border.BorderThicknessProperty, new Thickness(1, 0, 1, 0));
            borderFactory.SetValue(Border.PaddingProperty, new Thickness(5, 0, 5, 3));

            borderFactory.AppendChild(contentPresenterFactory);
            Setters.Add(new Setter(DataGridCell.ForegroundProperty, BasicColors.BackgroundMediumBrush));
            Setters.Add(new Setter(DataGridCell.TemplateProperty, new ControlTemplate(typeof(DataGridCell))
            {
                VisualTree = borderFactory
            }));
            
        }
    }
}
