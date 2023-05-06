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
            string url = "https://yandex.ru/search/?text=%D1%87%D1%82%D0%BE+%D1%82%D0%B0%D0%BA%D0%BE%D0%B5+%D1%88%D0%B8%D0%B7%D0%B0&lr=2";

            HttpClient client = new HttpClient();
            string page = await client.GetStringAsync(url);

            using var context = BrowsingContext.New(Configuration.Default);
            using var doc = await context.OpenAsync(req => req.Content(page));

            var quickAnswerDocument = doc.GetElementsByClassName("serp-item has-branding__show-hint");
            if (quickAnswerDocument.Length > 0)
            {
                var quickAnswerDocument1 = quickAnswerDocument[0].
                    GetElementsByClassName("Fact");
                if (quickAnswerDocument1.Length == 0)
                {
                    quickAnswerDocument1 = quickAnswerDocument[0].
                        GetElementsByClassName("typo_text_fact");
                }
                var quickAnswerElements = quickAnswerDocument1[0].Children;

                for (int i = 0; i < quickAnswerElements.Length; i++)
                {
                    if (quickAnswerElements[i].ClassName == "Fact-Summarize Typo Typo_text_xxl Typo_line_m")
                    {
                        quickAnswerSP.Children.Add(new TextBlock()
                        {
                            Text = quickAnswerElements[i].TextContent,
                            MaxWidth = 400,
                            TextWrapping = TextWrapping.Wrap,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            FontSize = 20
                        });
                    }
                    else if (quickAnswerElements[i].ClassName != "Fact-Source" &&
                             quickAnswerElements[i].ClassName != 
                             "ExtraActions Typo Typo_text_s Typo_line_m Fact-Footer")
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
                        var pathItem = quickAnswerElements[i].GetElementsByClassName("Path-Item");
                        if (pathItem.Length != 0)
                        {
                            if (pathItem[0].QuerySelector("b").TextContent != "" ||
                                pathItem[0].QuerySelector("b").TextContent != null)
                            {
                                quickAnswerSP.Children.Add(new TextBlock()
                                {
                                    Text = pathItem[0].QuerySelector("b").TextContent,
                                    HorizontalAlignment = HorizontalAlignment.Left,
                                    FontSize = 15
                                });
                            }
                        }

                        var pageref = quickAnswerElements[i].GetElementsByClassName("Link");
                        if (pageref.Length != 0)
                        {
                            var pagerefHyperlink = new Hyperlink()
                            {
                                NavigateUri = new Uri(pageref[0].GetAttribute("href"))
                            };
                            pagerefHyperlink.RequestNavigate += (s, e) =>
                            Process.Start(new ProcessStartInfo(pageref[0].GetAttribute("href"))
                            { UseShellExecute = true });

                            var pagename = quickAnswerElements[i].GetElementsByClassName(
                            "OneLine Fact-Title Typo Typo_text_xm Typo_line_m");
                            if (pagename.Length != 0)
                            {
                                pagerefHyperlink.Inlines.Add(pagename[0].TextContent);
                            }

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
            }
            else quickAnswerSP.Children.Add(new TextBlock() { Text = "non" });
        }
    }
}