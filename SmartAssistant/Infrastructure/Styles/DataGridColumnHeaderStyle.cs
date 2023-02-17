using SmartAssistant.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

namespace SmartAssistant
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
            contentPresenterFactory.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
            contentPresenterFactory.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            contentPresenterFactory.SetValue(ContentPresenter.RecognizesAccessKeyProperty, RecognizesAccessKeyTrue);

            FrameworkElementFactory gridFactory = new FrameworkElementFactory(typeof(Grid));
            gridFactory.SetValue(Grid.MarginProperty, new Thickness(10));

            gridFactory.AppendChild(contentPresenterFactory);

            FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.SetValue(Border.BorderThicknessProperty, new Thickness(2, 3, 2, 3));
            borderFactory.SetValue(Border.BackgroundProperty, BasicColors.SelectionLightBrush);
            borderFactory.SetValue(Border.BorderBrushProperty, BasicColors.ButtonMouseOverBrush);

            borderFactory.AppendChild(gridFactory);

            FrameworkElementFactory ThumbFactory1 = new FrameworkElementFactory(typeof(Thumb));
            ThumbFactory1.SetValue(Thumb.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            ThumbFactory1.SetValue(Thumb.StyleProperty, Application.Current.Resources["ColumnHeaderGripperStyle"]);
            ThumbFactory1.SetValue(Thumb.NameProperty, "PART_LeftHeaderGripper");

            FrameworkElementFactory ThumbFactory2 = new FrameworkElementFactory(typeof(Thumb));
            ThumbFactory2.SetValue(Thumb.HorizontalAlignmentProperty, HorizontalAlignment.Right);
            ThumbFactory2.SetValue(Thumb.StyleProperty, Application.Current.Resources["ColumnHeaderGripperStyle"]);
            ThumbFactory2.SetValue(Thumb.NameProperty, RightThumbName);

            FrameworkElementFactory mainGridFactory = new FrameworkElementFactory(typeof(Grid));
            mainGridFactory.AppendChild(borderFactory);
            mainGridFactory.AppendChild(ThumbFactory1);
            mainGridFactory.AppendChild(ThumbFactory2);

            Setters.Add(new Setter(DataGridColumnHeader.VerticalContentAlignmentProperty, VerticalAlignment.Center));
            Setters.Add(new Setter(DataGridColumnHeader.HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
            Setters.Add(new Setter(DataGridColumnHeader.ForegroundProperty, BasicColors.ButtonMouseOverBrush));
            Setters.Add(new Setter(DataGridColumnHeader.MinHeightProperty, ColumnHeaderMinHeight));
            Setters.Add(new Setter(DataGridColumnHeader.MinWidthProperty, ColumnHeaderMinWidth));
            Setters.Add(new Setter(DataGridColumnHeader.TemplateProperty, new ControlTemplate(typeof(DataGridColumnHeader))
            {
                VisualTree = mainGridFactory
            }));
        }
    }

    public class ColumnHeaderGripperStyle : Style
    {
        public ColumnHeaderGripperStyle()
        {
            var a = new Style() { TargetType = typeof(Thumb) };

            double ThumbWidth = 8;

            FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.SetValue(Border.BackgroundProperty, BasicColors.TransparentBrush);
            borderFactory.SetValue(Border.BorderThicknessProperty, new Thickness(0));

            BasedOn = a;
            Setters.Add(new Setter(Thumb.CursorProperty, Cursors.SizeWE));
            Setters.Add(new Setter(Thumb.WidthProperty, ThumbWidth));
            Setters.Add(new Setter(Thumb.TemplateProperty, new ControlTemplate(typeof(Thumb))
            {
                VisualTree = borderFactory,
            }));
        }
    }
}
