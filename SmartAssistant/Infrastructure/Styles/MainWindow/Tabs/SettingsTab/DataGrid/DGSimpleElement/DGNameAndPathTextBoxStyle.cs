using SmartAssistant.Resources;
using SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab;
using SmartAssistant.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.SettingsTab.DataGrid.DGSimpleElement
{
    public class DGNameAndPathTextBoxStyle : Style
    {
        public DGNameAndPathTextBoxStyle(Binding text)
        {
            FrameworkElementFactory textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
            textBlockFactory.SetValue(TextBlock.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("Transparent"));
            textBlockFactory.SetValue(TextBlock.ForegroundProperty, ResApp.GetResources<SolidColorBrush>("DarkerBrush"));
            textBlockFactory.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);
            textBlockFactory.SetValue(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            textBlockFactory.SetValue(TextBlock.FontFamilyProperty, new FontFamily("Segoe UI Semibold"));
            textBlockFactory.SetValue(TextBlock.TextWrappingProperty, TextWrapping.Wrap);
            textBlockFactory.SetBinding(TextBlock.TextProperty, text);

            FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.SetValue(Border.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("CommonLightBrush"));
            borderFactory.SetValue(Border.BorderBrushProperty, ResApp.GetResources<SolidColorBrush>("Transparent"));
            borderFactory.SetValue(Border.BorderThicknessProperty, new Thickness(0));
            borderFactory.SetValue(Border.SnapsToDevicePixelsProperty, true);

            borderFactory.AppendChild(textBlockFactory);

            Setters.Add(new Setter(TextBox.TemplateProperty, new ControlTemplate(typeof(TextBox))
            {
                VisualTree = borderFactory
            }));
        }
    }
}
