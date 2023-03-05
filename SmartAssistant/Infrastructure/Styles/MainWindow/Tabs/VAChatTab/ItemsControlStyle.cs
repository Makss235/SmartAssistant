using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.VAChatTab
{
    public class ItemsControlStyle : Style
    {
        public ItemsControlStyle() 
        { 
            FrameworkElementFactory itemsPresenterF = new FrameworkElementFactory(typeof(ItemsPresenter));
            itemsPresenterF.SetValue(ItemsPresenter.SnapsToDevicePixelsProperty, true);
            itemsPresenterF.SetValue(ItemsPresenter.VerticalAlignmentProperty, VerticalAlignment.Bottom);

            FrameworkElementFactory borderF = new FrameworkElementFactory(typeof(Border));
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
            borderF.SetBinding(Border.BorderBrushProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("BorderBrush")
            });
            borderF.SetBinding(Border.PaddingProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Padding")
            });

            borderF.AppendChild(itemsPresenterF);
            Setters.Add(new Setter(ItemsControl.TemplateProperty, new ControlTemplate
            {
                VisualTree = borderF
            }));
        }
    }
}
