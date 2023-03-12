using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SmartAssistant.Infrastructure.Styles.Base;
using SmartAssistant.Resources;
using SmartAssistant.UserControls.AddPEWindow;

namespace SmartAssistant.Infrastructure.Styles.AddPEWindow
{
    public class AddPEMenuButtonStyle : Style
    {
        public AddPEMenuButtonStyle()
        {
            CommonButton commonB = new CommonButton();

            FrameworkElementFactory borderF = commonB.borderF;
            borderF.SetValue(Border.CornerRadiusProperty, new CornerRadius(25));

            Trigger MOTrueT = new Trigger
            {
                Property = Button.IsMouseOverProperty,
                Value = true
            };
            MOTrueT.Setters.Add(new Setter(Button.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("CommonLightBrush")));
            MOTrueT.Setters.Add(new Setter(Button.BorderBrushProperty, ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")));
            MOTrueT.Setters.Add(new Setter(Button.ForegroundProperty, ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")));
            
            Triggers.Add(MOTrueT);
            Setters.Add(new Setter(Button.BorderThicknessProperty, new Thickness(2)));
            Setters.Add(new Setter(Button.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")));
            Setters.Add(new Setter(Button.ForegroundProperty, ResApp.GetResources<SolidColorBrush>("CommonLightBrush")));
            Setters.Add(new Setter(Button.BorderBrushProperty, ResApp.GetResources<SolidColorBrush>("CommonLightBrush")));
            Setters.Add(new Setter(Button.FontFamilyProperty, new FontFamily("Segoe UI Semibold")));
            Setters.Add(new Setter(Button.TemplateProperty, new ControlTemplate(typeof(Button))
            {
                VisualTree = borderF
            }));
        }

        public AddPEMenuButtonStyle(Trigger MOTrueT, Trigger MOFalseT)
        {

            CommonButton commonB = new CommonButton();

            FrameworkElementFactory borderF = commonB.borderF;
            borderF.SetValue(Border.CornerRadiusProperty, new CornerRadius(25));

            Triggers.Add(MOTrueT);
            Triggers.Add(MOFalseT);
            Setters.Add(new Setter(Button.BorderThicknessProperty, new Thickness(2)));
            Setters.Add(new Setter(Button.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")));
            Setters.Add(new Setter(Button.ForegroundProperty, ResApp.GetResources<SolidColorBrush>("CommonLightBrush")));
            Setters.Add(new Setter(Button.BorderBrushProperty, ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")));
            Setters.Add(new Setter(Button.FontFamilyProperty, new FontFamily("Segoe UI Semibold")));
            Setters.Add(new Setter(Button.TemplateProperty, new ControlTemplate(typeof(Button))
            {
                VisualTree = borderF
            }));
            
        }
    }
}
