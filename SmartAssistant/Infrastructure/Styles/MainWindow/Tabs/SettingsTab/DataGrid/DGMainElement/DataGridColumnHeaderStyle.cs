using SmartAssistant.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.SettingsTab.DataGrid.DGMainElement
{
    [TemplatePart(Name = "PART_LeftHeaderGripper", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_RightHeaderGripper", Type = typeof(Thumb))]
    public class DataGridColumnHeaderStyle : Style
    {
        public DataGridColumnHeaderStyle()
        {
            bool RecognizesAccessKeyTrue = true;
            double ColumnHeaderMinHeight = 25;
            double ColumnHeaderMinWidth = 100;
            string LeftThumbName = "PART_LeftHeaderGripper";
            string RightThumbName = "PART_RightHeaderGripper";

            FrameworkElementFactory contentPresenterFactory = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterFactory.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
            contentPresenterFactory.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            contentPresenterFactory.SetValue(ContentPresenter.RecognizesAccessKeyProperty, RecognizesAccessKeyTrue);

            FrameworkElementFactory gridFactory = new FrameworkElementFactory(typeof(Grid));
            gridFactory.SetValue(FrameworkElement.MarginProperty, new Thickness(10));

            gridFactory.AppendChild(contentPresenterFactory);

            FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.SetValue(Border.BorderThicknessProperty, new Thickness(2, 3, 2, 3));
            borderFactory.SetValue(Border.BackgroundProperty, Application.Current.Resources["SelectionLightBrush"] as SolidColorBrush);
            borderFactory.SetValue(Border.BorderBrushProperty, Application.Current.Resources["ButtonMouseOverBrush"] as SolidColorBrush);

            borderFactory.AppendChild(gridFactory);

            FrameworkElementFactory ThumbFactory1 = new FrameworkElementFactory(typeof(Thumb));
            ThumbFactory1.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            ThumbFactory1.SetValue(FrameworkElement.StyleProperty, Application.Current.Resources["ColumnHeaderGripperStyle"]);
            ThumbFactory1.SetValue(FrameworkElement.NameProperty, LeftThumbName);

            FrameworkElementFactory ThumbFactory2 = new FrameworkElementFactory(typeof(Thumb));
            ThumbFactory2.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Right);
            ThumbFactory2.SetValue(FrameworkElement.StyleProperty, Application.Current.Resources["ColumnHeaderGripperStyle"]);
            ThumbFactory2.SetValue(FrameworkElement.NameProperty, RightThumbName);

            FrameworkElementFactory mainGridFactory = new FrameworkElementFactory(typeof(Grid));
            mainGridFactory.AppendChild(borderFactory);
            mainGridFactory.AppendChild(ThumbFactory1);
            mainGridFactory.AppendChild(ThumbFactory2);

            Setters.Add(new Setter(Control.VerticalContentAlignmentProperty, VerticalAlignment.Center));
            Setters.Add(new Setter(Control.HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
            Setters.Add(new Setter(Control.ForegroundProperty, Application.Current.Resources["ButtonMouseOverBrush"] as SolidColorBrush));
            Setters.Add(new Setter(FrameworkElement.MinHeightProperty, ColumnHeaderMinHeight));
            Setters.Add(new Setter(FrameworkElement.MinWidthProperty, ColumnHeaderMinWidth));
            Setters.Add(new Setter(Control.TemplateProperty, new ControlTemplate(typeof(DataGridColumnHeader))
            {
                VisualTree = mainGridFactory
            }));
        }
    }

    public class ColumnHeaderGripperStyle : Style
    {
        public ColumnHeaderGripperStyle()
        {
            double ThumbWidth = 8;

            FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.SetValue(Border.BackgroundProperty, Application.Current.Resources["TransparentBrush"] as SolidColorBrush);
            borderFactory.SetValue(Border.BorderThicknessProperty, new Thickness(0));

            Setters.Add(new Setter(FrameworkElement.CursorProperty, Cursors.SizeWE));
            Setters.Add(new Setter(FrameworkElement.WidthProperty, ThumbWidth));
            Setters.Add(new Setter(Control.TemplateProperty, new ControlTemplate(typeof(Thumb))
            {
                VisualTree = borderFactory,
            }));
        }
    }
}
