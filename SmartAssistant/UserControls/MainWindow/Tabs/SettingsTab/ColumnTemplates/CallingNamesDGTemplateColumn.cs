using SmartAssistant.Data.ProgramsData;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.SettingsTab.DataGrid.DGSimpleElement;
using SmartAssistant.UserControls.Base;

namespace SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab.ColumnTemplates
{
    public class CallingNamesDGTemplateColumn : DataTemplate
    {
        public CallingNamesDGTemplateColumn()
        {
            ProgramElement forTitleProgramObj = new ProgramElement();

            FrameworkElementFactory callingNameDGListBoxFactory = new FrameworkElementFactory(typeof(ListBox));
            callingNameDGListBoxFactory.SetBinding(ItemsControl.ItemsSourceProperty, new Binding(nameof(forTitleProgramObj.CallingNames)));

            // TODO: Veser слишком длинные названия переменных
            //TODO: Максим SelectedCallingName
            //callingNameDGListBoxFactory.SetBinding(ListBox.SelectedItemProperty, new Binding(nameof(forTitleProgramObj.CallingNames)));

            //FrameworkElementFactory callingNameTextBoxFactory = new FrameworkElementFactory(typeof(TextBox));
            //callingNameTextBoxFactory.SetValue(TextBox.WidthProperty, (double)50);
            //FrameworkElementFactory callingNameDGAddButtonFactory = new FrameworkElementFactory(typeof(Button));
            //callingNameDGAddButtonFactory.SetValue(Button.WidthProperty, (double)25);
            //callingNameDGAddButtonFactory.SetValue(Button.ContentProperty, "+");
            //callingNameDGAddButtonFactory.SetValue(Button.StyleProperty, new DGCallingNameButtonStyle(new CornerRadius(0, 10, 10, 0), (double)20, new Thickness(1)));

            //FrameworkElementFactory callingNameDGHorizontalStackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
            //callingNameDGHorizontalStackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            //callingNameDGHorizontalStackPanelFactory.AppendChild(callingNameTextBoxFactory);
            //callingNameDGHorizontalStackPanelFactory.AppendChild(callingNameDGAddButtonFactory);

            //FrameworkElementFactory callingNameDGDeleteButton = new FrameworkElementFactory(typeof(Button));
            //callingNameDGDeleteButton.SetValue(Button.WidthProperty, (double)25);
            //callingNameDGDeleteButton.SetValue(Button.HeightProperty, (double)25);
            //callingNameDGDeleteButton.SetValue(Button.ContentProperty, "-");
            //callingNameDGDeleteButton.SetValue(Button.StyleProperty, new DGCallingNameButtonStyle(new CornerRadius(10), (double)30, new Thickness(-1, -12, -1, 0)));

            //FrameworkElementFactory callingNameDGVerticalStackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
            //callingNameDGVerticalStackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Vertical);
            //callingNameDGVerticalStackPanelFactory.SetValue(StackPanel.MarginProperty, new Thickness(0, 5, 0, 5));
            //callingNameDGVerticalStackPanelFactory.AppendChild(callingNameDGListBoxFactory);
            //callingNameDGVerticalStackPanelFactory.AppendChild(callingNameDGHorizontalStackPanelFactory);
            //callingNameDGVerticalStackPanelFactory.AppendChild(callingNameDGDeleteButton);

            FrameworkElementFactory textBoxF = new FrameworkElementFactory(typeof(TextBox));
            textBoxF.SetValue(Control.BackgroundProperty, Application.Current.Resources["Transparent"]);
            textBoxF.SetValue(Control.BorderThicknessProperty, new Thickness(0));
            textBoxF.SetValue(FrameworkElement.WidthProperty, (double)115);
            textBoxF.SetValue(FrameworkElement.HeightProperty, (double)25);
            textBoxF.SetValue(Control.FontSizeProperty, (double)15);
            textBoxF.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
            textBoxF.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            textBoxF.SetValue(TextBox.TextWrappingProperty, TextWrapping.Wrap);
            textBoxF.SetValue(FrameworkElement.MarginProperty, new Thickness(5, 0, 0, 0));

            FrameworkElementFactory buttonF = new FrameworkElementFactory(typeof(Button));
            buttonF.SetValue(FrameworkElement.WidthProperty, (double)30);
            buttonF.SetValue(FrameworkElement.HeightProperty, (double)30);
            buttonF.SetValue(ContentControl.ContentProperty, "+");
            buttonF.SetValue(Control.BackgroundProperty, Application.Current.Resources["Transparent"]);
            buttonF.SetValue(Control.BorderThicknessProperty, new Thickness(0));
            buttonF.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
            buttonF.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Right);

            FrameworkElementFactory stackPanelF = new FrameworkElementFactory(typeof(StackPanel));
            stackPanelF.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            stackPanelF.SetValue(FrameworkElement.WidthProperty, (double)145);
            stackPanelF.AppendChild(textBoxF);
            stackPanelF.AppendChild(buttonF);

            FrameworkElementFactory mainBorderF = new FrameworkElementFactory(typeof(Border));
            mainBorderF.SetValue(FrameworkElement.HeightProperty, (double)30);
            mainBorderF.SetValue(FrameworkElement.WidthProperty, (double)145);
            mainBorderF.SetValue(Border.BorderBrushProperty, Application.Current.Resources["BackgroundMediumBrush"]);
            mainBorderF.SetValue(Border.BackgroundProperty, Application.Current.Resources["BackgroundLightBrush"]);
            mainBorderF.SetValue(Border.CornerRadiusProperty, new CornerRadius(10));
            mainBorderF.SetValue(Border.BorderThicknessProperty, new Thickness(1));
            mainBorderF.AppendChild(stackPanelF);

            VisualTree = mainBorderF;
        }
    }
}
