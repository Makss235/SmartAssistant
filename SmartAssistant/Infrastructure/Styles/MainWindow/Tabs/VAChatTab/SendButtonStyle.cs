﻿using SmartAssistant.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SmartAssistant
{
    public class SendButtonStyle : Style
    {
        public SendButtonStyle()
        {
            FrameworkElementFactory contentPresenterFactory = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterFactory.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenterFactory.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);

            FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.SetBinding(Border.BorderBrushProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("BorderBrush")
            });
            borderFactory.SetBinding(Border.BackgroundProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Background")
            });
            borderFactory.SetValue(Border.CornerRadiusProperty, new CornerRadius(25));
            borderFactory.SetValue(Border.BorderThicknessProperty, new Thickness(2));
            borderFactory.AppendChild(contentPresenterFactory);

            Trigger mouseOverTrigger = new Trigger
            {
                Property = Button.IsMouseOverProperty,
                Value = true
            };
            mouseOverTrigger.Setters.Add(new Setter(Button.BorderBrushProperty, BasicColors.BackgroundDarkBrush));

            Trigger mousePressedTrigger = new Trigger
            {
                Property = Button.IsPressedProperty,
                Value = true
            };
            mousePressedTrigger.Setters.Add(new Setter(Button.BorderBrushProperty, BasicColors.ButtonPressedBrush));

            Triggers.Add(mouseOverTrigger);
            Triggers.Add(mousePressedTrigger);
            Setters.Add(new Setter(Button.BorderBrushProperty, BasicColors.BackgroundMediumBrush));
            Setters.Add(new Setter(Button.BackgroundProperty, BasicColors.TransparentBrush));
            Setters.Add(new Setter(Button.TemplateProperty, new ControlTemplate(typeof(Button))
            {
                VisualTree = borderFactory
            }));
        }
    }
}