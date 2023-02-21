using SmartAssistant.Data.ProgramsData;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using SmartAssistant.Infrastructure.Styles.MainWindow.Tabs.SettingsTab.DataGrid.DGSimpleElement;
using SmartAssistant.UserControls.Base;

namespace SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab
{
    public class CallingNameDGTemplate : DataTemplate
    {
        public CallingNameDGTemplate()
        {
            ProgramElement forTitleProgramObj = new ProgramElement();

            FrameworkElementFactory callingNameDGListBoxFactory = new FrameworkElementFactory(typeof(ListBox));
            callingNameDGListBoxFactory.SetBinding(ListBox.ItemsSourceProperty, new Binding(nameof(forTitleProgramObj.CallingNames)));
            
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
            textBoxF.SetValue(TextBox.BackgroundProperty, Application.Current.Resources["Transparent"]);
            textBoxF.SetValue(TextBox.BorderThicknessProperty, new Thickness(0));
            textBoxF.SetValue(TextBox.WidthProperty, (double)115);
            textBoxF.SetValue(TextBox.HeightProperty, (double)25);
            textBoxF.SetValue(TextBox.FontSizeProperty, (double)15);
            textBoxF.SetValue(TextBox.VerticalAlignmentProperty, VerticalAlignment.Center);
            textBoxF.SetValue(TextBox.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            textBoxF.SetValue(TextBox.TextWrappingProperty, TextWrapping.Wrap);
            textBoxF.SetValue(TextBox.MarginProperty, new Thickness(5, 0, 0, 0));

            FrameworkElementFactory buttonF = new FrameworkElementFactory(typeof(Button));
            buttonF.SetValue(Button.WidthProperty, (double)30);
            buttonF.SetValue(Button.HeightProperty, (double)30);
            buttonF.SetValue(Button.ContentProperty, "+");
            buttonF.SetValue(Button.BackgroundProperty, Application.Current.Resources["Transparent"]);
            buttonF.SetValue(Button.BorderThicknessProperty, new Thickness(0));
            buttonF.SetValue(Button.VerticalAlignmentProperty, VerticalAlignment.Center);
            buttonF.SetValue(Button.HorizontalAlignmentProperty, HorizontalAlignment.Right);

            FrameworkElementFactory stackPanelF = new FrameworkElementFactory(typeof(StackPanel));
            stackPanelF.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            stackPanelF.SetValue(StackPanel.WidthProperty, (double)145);
            stackPanelF.AppendChild(textBoxF);
            stackPanelF.AppendChild(buttonF);

            FrameworkElementFactory mainBorderF = new FrameworkElementFactory(typeof(Border));
            mainBorderF.SetValue(Border.HeightProperty, (double)30);
            mainBorderF.SetValue(Border.WidthProperty, (double)145);
            mainBorderF.SetValue(Border.BorderBrushProperty, Application.Current.Resources["BackgroundMediumBrush"]);
            mainBorderF.SetValue(Border.BackgroundProperty, Application.Current.Resources["BackgroundLightBrush"]);
            mainBorderF.SetValue(Border.CornerRadiusProperty, new CornerRadius(10));
            mainBorderF.SetValue(Border.BorderThicknessProperty, new Thickness(1));
            mainBorderF.AppendChild(stackPanelF);

            VisualTree = mainBorderF;
        }
    }
}
