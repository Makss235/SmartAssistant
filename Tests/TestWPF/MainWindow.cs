using AngleSharp;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Configuration = AngleSharp.Configuration;

namespace TestWPF
{
    internal class MainWindow : Window
    {
        StackPanel quickAnswerSP;
        public MainWindow()
        {
            Button button = new Button();
            button.Content = "parce";
            button.Width = 100;
            button.Height = 50;
            button.Click += Button_Click;

            quickAnswerSP = new StackPanel()
            {
                Margin = new Thickness(10),
            };

            StackPanel stackPanel = new StackPanel();
            stackPanel.Children.Add(quickAnswerSP);
            stackPanel.Children.Add(button);

            Content = stackPanel;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://yandex.ru/search/?text=%D1%87%D1%82%D0%BE+%D0%BF%D0%B5%D1%80%D0%B2%D0%BE%D0%B5+%D0%BA%D1%83%D1%80%D0%B8%D1%86%D0%B0+%D0%B8%D0%BB%D0%B8+%D1%8F%D0%B9%D1%86%D0%BE&lr=2";

            HttpClient client = new HttpClient();
            string page = await client.GetStringAsync(url);

            using var context = BrowsingContext.New(Configuration.Default);
            using var doc = await context.OpenAsync(req => req.Content(page));

            var quickAnswerDocument = doc.GetElementsByClassName(
                "serp-item serp-item_card serp-item_card-extra-shadow " +
                "serp-item_card-no-padding-bottom has-branding " +
                "has-branding__fact has-branding__show-hint");

            if (quickAnswerDocument.Length != 0)
            {
                quickAnswerDocument = quickAnswerDocument[0].
                    GetElementsByClassName("Fact");
                var quickAnswerElements = quickAnswerDocument[0].Children;

                for (int i = 0; i < quickAnswerElements.Length; i++)
                {
                    if (quickAnswerElements[i].ClassName != "Fact-Source" &&
                        quickAnswerElements[i].ClassName != "ExtraActions Typo Typo_text_s Typo_line_m Fact-Footer")
                    {
                        var divSelectors = quickAnswerElements[i].QuerySelectorAll("div");
                        if (divSelectors.Length == 0)
                        {
                            quickAnswerSP.Children.Add(new TextBlock()
                            {
                                Text = quickAnswerElements[i].TextContent,
                                MaxWidth = 400,
                                TextWrapping = TextWrapping.Wrap,
                                HorizontalAlignment = HorizontalAlignment.Left,
                                FontSize = 15
                            });
                        }
                    }
                    else if (quickAnswerElements[i].ClassName == "Fact-Source")
                    {
                        var pageref = quickAnswerElements[i].GetElementsByClassName("Link Fact-SiteSource")[0].GetAttribute("href");
                        var sitename = quickAnswerElements[i].GetElementsByClassName("Path-Item")[0].QuerySelector("b").TextContent;
                        var pagename = quickAnswerElements[i].GetElementsByClassName("OneLine Fact-Title Typo Typo_text_xm Typo_line_m")[0].TextContent;

                        quickAnswerSP.Children.Add(new TextBlock()
                        {
                            Text = sitename,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            FontSize = 15
                        });

                        var pagerefHyperlink = new Hyperlink()
                        {
                            NavigateUri = new Uri(pageref)
                        };
                        pagerefHyperlink.RequestNavigate += (s, e) =>
                        Process.Start(new ProcessStartInfo(pageref)
                        { UseShellExecute = true });

                        pagerefHyperlink.Inlines.Add(pagename);

                        var pagerefHyperlinkTextBlock = new TextBlock()
                        {
                            HorizontalAlignment = HorizontalAlignment.Left,
                            FontSize = 15
                        };
                        pagerefHyperlinkTextBlock.Inlines.Add(pagerefHyperlink);
                        quickAnswerSP.Children.Add(pagerefHyperlinkTextBlock);
                    }
                }
            }
            else quickAnswerSP.Children.Add(new TextBlock() { Text = "non" });
        }
    }
}