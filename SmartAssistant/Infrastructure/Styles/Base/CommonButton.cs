using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.Infrastructure.Styles.Base
{
    public class CommonButton : Style
    {
        private FrameworkElementFactory contentPresenterF { get; set; }
        public FrameworkElementFactory borderF { get; set; }
        public Trigger mouseOverT { get; set; }
        public Trigger pressedT { get; set; }
        public CommonButton()
        {
            contentPresenterF = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterF.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
            contentPresenterF.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenterF.SetBinding(ContentPresenter.MarginProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Padding")
            });

            borderF = new FrameworkElementFactory(typeof(Border));
            borderF.SetBinding(Border.BackgroundProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Background")
            });
            borderF.SetBinding(Border.BorderBrushProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("BorderBrush")
            });
            borderF.SetBinding(Border.BorderThicknessProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("BorderThickness")
            });

            borderF.AppendChild(contentPresenterF);

            mouseOverT = new Trigger
            {
                Property = Button.IsMouseOverProperty,
                Value = true
            };

            pressedT = new Trigger
            {
                Property = Button.IsPressedProperty,
                Value = true
            };
        }
    }
}
