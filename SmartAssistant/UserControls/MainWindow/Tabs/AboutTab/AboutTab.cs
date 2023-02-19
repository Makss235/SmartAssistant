using SmartAssistant.Data.LocalizationData;
using SmartAssistant.Infrastructure.Commands;
using SmartAssistant.UserControls.MainWindow.Tabs.Base;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SmartAssistant.UserControls.MainWindow.Tabs.AboutTab
{
    public class AboutTab : Tab
    {
        public AboutTab(byte id, double width, double height, Visibility visibility)
        {
            ID = id;
            Width = width;
            Height = height;
            Visibility = visibility;

            Style style = new Style();
            //style.TargetType = typeof(TextBlock);
            style.Setters.Add(new Setter(TextBlock.FontSizeProperty, (double)15));
            style.Setters.Add(new Setter(TextBlock.FontFamilyProperty, new FontFamily("Segoe UI Semibold")));
            style.Setters.Add(new Setter(TextBlock.TextWrappingProperty, TextWrapping.Wrap));
            Style = style;

            var loc = Localize.JsonObject.MainWindowLoc.TabsLoc.AboutProgramTabLoc;

            #region a1
            TextBlock textBlock11 = new TextBlock()
            {
                Text = loc.NameProgramLoc,
                Margin = new Thickness(0, 0, 10, 0)
            };
            TextBlock textBlock12 = new TextBlock()
            {
                Text = "Привет, Иван!"
            };

            StackPanel stackPanel1 = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(15, 10, 0, 0),
            };
            stackPanel1.Children.Add(textBlock11);
            stackPanel1.Children.Add(textBlock12);
            #endregion

            #region a2
            TextBlock textBlock21 = new TextBlock()
            {
                Text = loc.NameBuildLoc,
                Margin = new Thickness(0, 0, 10, 0)
            };
            TextBlock textBlock22 = new TextBlock()
            {
                Text = "SmartAssistant"
            };

            StackPanel stackPanel2 = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(15, 10, 0, 0),
            };
            stackPanel2.Children.Add(textBlock21);
            stackPanel2.Children.Add(textBlock22);
            #endregion

            #region a3
            TextBlock textBlock31 = new TextBlock()
            {
                Text = loc.VersionLoc,
                Margin = new Thickness(0, 0, 10, 0)
            };
            TextBlock textBlock32 = new TextBlock()
            {
                Text = "0.0.2.1"
            };

            StackPanel stackPanel3 = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(15, 10, 0, 0),
            };
            stackPanel3.Children.Add(textBlock31);
            stackPanel3.Children.Add(textBlock32);
            #endregion

            #region a4
            TextBlock textBlock41 = new TextBlock()
            {
                Text = loc.AuthorsLoc.TitleLoc,
                Margin = new Thickness(0, 0, 10, 0)
            };

            TextBlock textBlock42 = new TextBlock()
            { Text = loc.AuthorsLoc.MakssLoc };
            TextBlock textBlock43 = new TextBlock()
            { Text = loc.AuthorsLoc.MrVeserLoc };
            TextBlock textBlock44 = new TextBlock()
            { Text = loc.AuthorsLoc.FlowenyLoc };

            StackPanel stackPanel41 = new StackPanel() { Orientation = Orientation.Vertical };
            stackPanel41.Children.Add(textBlock42);
            stackPanel41.Children.Add(textBlock43);
            stackPanel41.Children.Add(textBlock44);

            StackPanel stackPanel4 = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(15, 10, 0, 0),
            };
            stackPanel4.Children.Add(textBlock41);
            stackPanel4.Children.Add(stackPanel41);
            #endregion

            #region a5
            TextBlock textBlock51 = new TextBlock()
            {
                Text = loc.DownloadLinkLoc,
                Margin = new Thickness(0, 0, 10, 0)
            };
            Hyperlink hyperlink = new Hyperlink()
            {
                NavigateUri = new Uri("https://goo.su/YCMpX2")
            };
            hyperlink.RequestNavigate += Hyperlink_RequestNavigate;
            hyperlink.Inlines.Add("https://goo.su/YCMpX2");

            TextBlock textBlock52 = new TextBlock();
            textBlock52.Inlines.Add(hyperlink);

            Uri qr = new Uri("pack://application:,,,/Resources/QR.png", UriKind.RelativeOrAbsolute);

            var b = new BitmapImage(qr);
            Image image = new Image() { Source = b };
            Label label = new Label()
            {
                Content = image,
                Width = 150,
                Height = 150,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(20, 10, 10, 0)
            };

            StackPanel stackPanel5 = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(15, 10, 0, 0),
            };
            stackPanel5.Children.Add(textBlock51);
            stackPanel5.Children.Add(textBlock52);
            stackPanel5.Children.Add(label);
            #endregion

            TextBlock textBlock = new TextBlock()
            {
                Text = Localize.JsonObject.MainWindowLoc.TabsLoc.AboutProgramTabLoc.TitleLoc,
                FontSize = 20,
                Margin = new Thickness(0, 15, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            StackPanel stackPanel = new StackPanel() { Orientation = Orientation.Vertical };
            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(stackPanel1);
            stackPanel.Children.Add(stackPanel2);
            stackPanel.Children.Add(stackPanel3);
            stackPanel.Children.Add(stackPanel4);
            stackPanel.Children.Add(stackPanel5);

            Grid mainGrid = new Grid();
            mainGrid.Children.Add(stackPanel);
            Content = mainGrid;
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://goo.su/YCMpX2") { UseShellExecute = true });
        }
    }
}
