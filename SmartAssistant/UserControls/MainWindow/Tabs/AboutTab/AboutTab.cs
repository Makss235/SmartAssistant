using SmartAssistant.Data.LocalizationData;
using SmartAssistant.Resources;
using SmartAssistant.UserControls.Base;
using SmartAssistant.UserControls.Widgets;
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
        private AboutProgramTabLoc loc;
        private Style styleTextBlock;

        private TextBlock titleTextBlock;

        private TextBlock nameProgramLocTextBlock;
        private TextBlock nameProgramTextBlock;
        private StackPanel nameProgramStackPanel;

        private TextBlock nameBuildLocTextBlock;
        private TextBlock nameBuildTextBlock;
        private StackPanel nameBuildStackPanel;

        private TextBlock versionLocTextBlock;
        private TextBlock versionTextBlock;
        private StackPanel versionStackPanel;

        private TextBlock authorsLocTextBlock;
        private TextBlock makssAuthorTextBlock;
        private TextBlock mrVeserAuthorTextBlock;
        private TextBlock flowenyAuthorTextBlock;
        private StackPanel authorsStackPanel1;
        private StackPanel authorsStackPanel;

        private TextBlock downloadLinkLocTextBlock;
        private Hyperlink downloadHyperlink;
        private TextBlock downloadHyperlinkTextBlock;
        private Label downloadQRLabel;
        private StackPanel downloadHyperlinkStackPanel;
        private TextBlock GitHubLinkLocTextBlock;
        private StackPanel linksStackPanel;

        private TextBlock warningTextBlock;
        private StackPanel mainStackPanel;
        private Grid mainGrid;

        public AboutTab(byte id, double width, double height, Visibility visibility)
            : base(id, width, height, visibility)
        {
            loc = Localize.JsonObject.MainWindowLoc.MainWindowTabsLoc.AboutProgramTabLoc;

            InitializeStyle();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            titleTextBlock = new TextBlock()
            {
                Text = loc.TitleLoc,
                FontSize = 20,
                Margin = new Thickness(0, 15, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            #region NameProgram

            nameProgramLocTextBlock = new TextBlock()
            {
                Text = loc.NameProgramLoc
            };
            nameProgramTextBlock = new TextBlock()
            {
                // TODO: Makss localize
                Text = "Привет, Иван!",
                Margin = new Thickness(10, 0, 0, 0)
            };

            nameProgramStackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 10, 0, 0),
            };
            nameProgramStackPanel.Children.Add(nameProgramLocTextBlock);
            nameProgramStackPanel.Children.Add(nameProgramTextBlock);

            #endregion

            #region NameBuild

            nameBuildLocTextBlock = new TextBlock()
            {
                Text = loc.NameBuildLoc
            };
            nameBuildTextBlock = new TextBlock()
            {
                Text = "SmartAssistant",
                Margin = new Thickness(10, 0, 0, 0)
            };

            nameBuildStackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 10, 0, 0),
            };
            nameBuildStackPanel.Children.Add(nameBuildLocTextBlock);
            nameBuildStackPanel.Children.Add(nameBuildTextBlock);

            #endregion

            #region Version

            versionLocTextBlock = new TextBlock()
            {
                Text = loc.VersionLoc
            };
            versionTextBlock = new TextBlock()
            {
                Text = "0.0.2.1",
                Margin = new Thickness(10, 0, 0, 0)
            };

            versionStackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 10, 0, 0),
            };
            versionStackPanel.Children.Add(versionLocTextBlock);
            versionStackPanel.Children.Add(versionTextBlock);

            #endregion

            #region Authors

            authorsLocTextBlock = new TextBlock()
            {
                Text = loc.AuthorsLoc.TitleLoc
            };

            makssAuthorTextBlock = new TextBlock()
            { Text = loc.AuthorsLoc.MakssLoc };
            mrVeserAuthorTextBlock = new TextBlock()
            { Text = loc.AuthorsLoc.MrVeserLoc };
            flowenyAuthorTextBlock = new TextBlock()
            { Text = loc.AuthorsLoc.FlowenyLoc };

            authorsStackPanel1 = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(10, 0, 0, 0),
            };
            authorsStackPanel1.Children.Add(makssAuthorTextBlock);
            authorsStackPanel1.Children.Add(mrVeserAuthorTextBlock);
            authorsStackPanel1.Children.Add(flowenyAuthorTextBlock);

            authorsStackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 10, 0, 0),
            };
            authorsStackPanel.Children.Add(authorsLocTextBlock);
            authorsStackPanel.Children.Add(authorsStackPanel1);

            #endregion

            #region Links

            downloadLinkLocTextBlock = new TextBlock()
            {
                Text = loc.DownloadLinkLoc
            };
            downloadHyperlink = new Hyperlink()
            {
                NavigateUri = new Uri("https://goo.su/YCMpX2")
            };
            downloadHyperlink.RequestNavigate += DownloadHyperlink_RequestNavigate;
            downloadHyperlink.Inlines.Add("https://goo.su/YCMpX2");

            downloadHyperlinkTextBlock = new TextBlock();
            downloadHyperlinkTextBlock.Inlines.Add(downloadHyperlink);

            downloadQRLabel = new Label()
            {
                Content = new Image()
                {
                    Source = new BitmapImage(
                    new Uri("pack://application:,,,/Resources/QR.png",
                    UriKind.RelativeOrAbsolute))
                },
                Width = 150,
                Height = 150,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 5, 0, 0)
            };

            downloadHyperlinkStackPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(0, 10, 0, 0),
            };
            downloadHyperlinkStackPanel.Children.Add(downloadLinkLocTextBlock);
            downloadHyperlinkStackPanel.Children.Add(downloadHyperlinkTextBlock);
            downloadHyperlinkStackPanel.Children.Add(downloadQRLabel);

            GitHubLinkLocTextBlock = new TextBlock()
            {
                Text = loc.GitHubLinkLoc,
                TextAlignment = TextAlignment.Left,
                Margin = new Thickness(25, 10, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Width = 300,
                TextWrapping = TextWrapping.Wrap
            };

            linksStackPanel = new StackPanel()
            { Orientation = Orientation.Horizontal };
            linksStackPanel.Children.Add(downloadHyperlinkStackPanel);
            linksStackPanel.Children.Add(GitHubLinkLocTextBlock);

            #endregion

            warningTextBlock = new TextBlock()
            {
                Text = loc.WarningLoc,
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 10, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center,
                TextWrapping = TextWrapping.Wrap
            };

            mainStackPanel = new StackPanel()
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


            mainGrid = new Grid();
            mainGrid.Children.Add(mainStackPanel);
            Content = mainGrid;
        }

        private void InitializeStyle()
        {
            styleTextBlock = new Style(typeof(UserControl)) { BasedOn = ResApp.GetResources<Style>("TabStyle") };
            styleTextBlock.Setters.Add(new Setter(TextBlock.FontSizeProperty, (double)15));
            styleTextBlock.Setters.Add(new Setter(TextBlock.FontFamilyProperty, new FontFamily("Segoe UI Semibold")));
            styleTextBlock.Setters.Add(new Setter(TextBlock.TextWrappingProperty, TextWrapping.Wrap));
            Style = styleTextBlock;
        }

        private void DownloadHyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://goo.su/YCMpX2") { UseShellExecute = true });
        }
    }
}
