using SmartAssistant.Data.LocalizationData;
using SmartAssistant.UserControls.Base;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
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

            Style styleTextBlock = new Style();
            styleTextBlock.Setters.Add(new Setter(TextBlock.FontSizeProperty, (double)15));
            styleTextBlock.Setters.Add(new Setter(TextBlock.FontFamilyProperty, new FontFamily("Segoe UI Semibold")));
            styleTextBlock.Setters.Add(new Setter(TextBlock.TextWrappingProperty, TextWrapping.Wrap));
            Style = styleTextBlock;

            var loc = Localize.JsonObject.MainWindowLoc.TabsLoc.AboutProgramTabLoc;

            #region NameProgram

            TextBlock nameProgramLocTextBlock = new TextBlock()
            {
                Text = loc.NameProgramLoc
            };
            TextBlock nameProgramTextBlock = new TextBlock()
            {
                Text = "Привет, Иван!",
                Margin = new Thickness(10, 0, 0, 0)
            };

            StackPanel nameProgramStackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 10, 0, 0),
            };
            nameProgramStackPanel.Children.Add(nameProgramLocTextBlock);
            nameProgramStackPanel.Children.Add(nameProgramTextBlock);

            #endregion

            #region NameBuild

            TextBlock nameBuildLocTextBlock = new TextBlock()
            {
                Text = loc.NameBuildLoc
            };
            TextBlock nameBuildTextBlock = new TextBlock()
            {
                Text = "SmartAssistant",
                Margin = new Thickness(10, 0, 0, 0)
            };

            StackPanel nameBuildStackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 10, 0, 0),
            };
            nameBuildStackPanel.Children.Add(nameBuildLocTextBlock);
            nameBuildStackPanel.Children.Add(nameBuildTextBlock);

            #endregion

            #region Version

            TextBlock versionLocTextBlock = new TextBlock()
            {
                Text = loc.VersionLoc
            };
            TextBlock versionTextBlock = new TextBlock()
            {
                Text = "0.0.2.1",
                Margin = new Thickness(10, 0, 0, 0)
            };

            StackPanel versionStackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 10, 0, 0),
            };
            versionStackPanel.Children.Add(versionLocTextBlock);
            versionStackPanel.Children.Add(versionTextBlock);

            #endregion

            #region Authors

            TextBlock authorsLocTextBlock = new TextBlock()
            {
                Text = loc.AuthorsLoc.TitleLoc
            };

            TextBlock makssAuthorTextBlock = new TextBlock()
            { Text = loc.AuthorsLoc.MakssLoc };
            TextBlock mrVeserAuthorTextBlock = new TextBlock()
            { Text = loc.AuthorsLoc.MrVeserLoc };
            TextBlock flowenyAuthorTextBlock = new TextBlock()
            { Text = loc.AuthorsLoc.FlowenyLoc };

            StackPanel authorsStackPanel1 = new StackPanel() 
            { 
                Orientation = Orientation.Vertical,
                Margin = new Thickness(10, 0, 0, 0),
            };
            authorsStackPanel1.Children.Add(makssAuthorTextBlock);
            authorsStackPanel1.Children.Add(mrVeserAuthorTextBlock);
            authorsStackPanel1.Children.Add(flowenyAuthorTextBlock);

            StackPanel authorsStackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 10, 0, 0),
            };
            authorsStackPanel.Children.Add(authorsLocTextBlock);
            authorsStackPanel.Children.Add(authorsStackPanel1);

            #endregion

            #region Links

            TextBlock downloadLinkLocTextBlock = new TextBlock()
            {
                Text = loc.DownloadLinkLoc
            };
            Hyperlink downloadHyperlink = new Hyperlink()
            {
                NavigateUri = new Uri("https://goo.su/YCMpX2")
            };
            downloadHyperlink.RequestNavigate += DownloadHyperlink_RequestNavigate;
            downloadHyperlink.Inlines.Add("https://goo.su/YCMpX2");

            TextBlock downloadHyperlinkTextBlock = new TextBlock();
            downloadHyperlinkTextBlock.Inlines.Add(downloadHyperlink);

            Label downloadQRLabel = new Label()
            {
                Content = new Image() { Source = new BitmapImage(
                    new Uri("pack://application:,,,/Resources/QR.png", 
                    UriKind.RelativeOrAbsolute)) },
                Width = 150,
                Height = 150,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 5, 0, 0)
            };

            StackPanel downloadHyperlinkStackPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(0, 10, 0, 0),
            };
            downloadHyperlinkStackPanel.Children.Add(downloadLinkLocTextBlock);
            downloadHyperlinkStackPanel.Children.Add(downloadHyperlinkTextBlock);
            downloadHyperlinkStackPanel.Children.Add(downloadQRLabel);

            TextBlock GitHubLinkLocTextBlock = new TextBlock()
            {
                Text = loc.GitHubLinkLoc,
                TextAlignment = TextAlignment.Left,
                Margin = new Thickness(25, 10, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Width = 300,
                TextWrapping = TextWrapping.Wrap
            };

            StackPanel linksStackPanel = new StackPanel() 
            { Orientation = Orientation.Horizontal };
            linksStackPanel.Children.Add(downloadHyperlinkStackPanel);
            linksStackPanel.Children.Add(GitHubLinkLocTextBlock);

            #endregion

            TextBlock warningTextBlock = new TextBlock() 
            { 
                Text = loc.WarningLoc,
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 10, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center,
                TextWrapping = TextWrapping.Wrap

            };

            TextBlock titleTextBlock = new TextBlock()
            {
                Text = loc.TitleLoc,
                FontSize = 20,
                Margin = new Thickness(0, 15, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            StackPanel mainStackPanel = new StackPanel() 
            { 
                Orientation = Orientation.Vertical,
                Margin = new Thickness(20, 0, 20, 10)
            };
            mainStackPanel.Children.Add(titleTextBlock);
            mainStackPanel.Children.Add(nameProgramStackPanel);
            mainStackPanel.Children.Add(nameBuildStackPanel);
            mainStackPanel.Children.Add(versionStackPanel);
            mainStackPanel.Children.Add(authorsStackPanel);
            mainStackPanel.Children.Add(linksStackPanel);
            mainStackPanel.Children.Add(warningTextBlock);

            Grid mainGrid = new Grid();
            mainGrid.Children.Add(mainStackPanel);
            Content = mainGrid;
        }

        private void DownloadHyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://goo.su/YCMpX2") { UseShellExecute = true });
        }
    }
}
