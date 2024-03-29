﻿using SmartAssistant.Resources;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.VAChatTab
{
    public class TypingMessageTextBoxStyle : Style
    {
        public TypingMessageTextBoxStyle(double Width)
        {
            FrameworkElementFactory textBoxF = new FrameworkElementFactory(typeof(TextBox));
            textBoxF.SetValue(TextBox.BorderThicknessProperty, new Thickness(0));
            textBoxF.SetValue(TextBox.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("Transparent"));
            textBoxF.SetValue(TextBox.TextWrappingProperty, TextWrapping.Wrap);
            textBoxF.SetValue(TextBox.PaddingProperty, new Thickness(15, 4, 15, 4));
            textBoxF.SetValue(TextBox.VerticalContentAlignmentProperty, VerticalAlignment.Center);
            textBoxF.SetValue(TextBox.FontSizeProperty, (double)16);
            textBoxF.SetValue(TextBox.FontFamilyProperty, new FontFamily("Segoe UI Semibold"));
            textBoxF.SetBinding(TextBox.TextProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Text")
            });
            //textBoxF.SetBinding(Border.HeightProperty, new Binding
            //{
            //    RelativeSource = RelativeSource.TemplatedParent,
            //    Path = new PropertyPath("Height")
            //});
            //textBoxF.SetBinding(Border.MinHeightProperty, new Binding
            //{
            //    RelativeSource = RelativeSource.TemplatedParent,
            //    Path = new PropertyPath("MinHeight")
            //});
            //textBoxF.SetBinding(Border.MaxHeightProperty, new Binding
            //{
            //    RelativeSource = RelativeSource.TemplatedParent,
            //    Path = new PropertyPath("MaxHeight")
            //});

            FrameworkElementFactory borderF = new FrameworkElementFactory(typeof(Border));
            borderF.SetValue(Border.BackgroundProperty, ResApp.GetResources<SolidColorBrush>("CommonLightBrush"));
            borderF.SetValue(Border.BorderThicknessProperty, new Thickness(2));
            //borderF.SetValue(Border.HeightProperty, (double)50);
            borderF.SetValue(Border.WidthProperty, (double)Width - 120);
            borderF.SetValue(Border.CornerRadiusProperty, new CornerRadius(20));
            borderF.SetBinding(Border.BorderBrushProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("BorderBrush")
            });
            borderF.SetBinding(Border.HeightProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Height")
            });
            borderF.SetBinding(Border.MinHeightProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("MinHeight")
            });
            borderF.SetBinding(Border.MaxHeightProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("MaxHeight")
            });

            borderF.AppendChild(textBoxF);

            Trigger mouseOverT = new Trigger
            {
                Property = TextBox.IsMouseOverProperty,
                Value = true
            };
            mouseOverT.Setters.Add(new Setter(TextBox.BorderBrushProperty, ResApp.GetResources<SolidColorBrush>("CommonDarkBrush")));

            Triggers.Add(mouseOverT);
            Setters.Add(new Setter(Control.BorderBrushProperty, ResApp.GetResources<SolidColorBrush>("CommonMediumBrush")));
            Setters.Add(new Setter(Control.MinHeightProperty, (double)50));
            Setters.Add(new Setter(Control.TemplateProperty, new ControlTemplate(typeof(TextBox))
            {
                VisualTree = borderF
            }));
            
        }
    }
}
