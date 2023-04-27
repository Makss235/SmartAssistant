using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Configuration = AngleSharp.Configuration;

namespace TestWPF
{
    internal class MainWindow : Window
    {
        StackPanel sp;
        public MainWindow()
        {
            Button button = new Button();
            button.Content = "parce";
            button.Width = 100;
            button.Height = 50;
            button.Click += Button_Click;

            sp = new StackPanel()
            {
                Margin = new Thickness(10),
            };

            StackPanel stackPanel = new StackPanel();
            stackPanel.Children.Add(sp);
            stackPanel.Children.Add(button);

            Content = stackPanel;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://yandex.ru/search/?text=%D0%BA%D0%B0%D0%BA+%D0%BF%D0%BE%D0%BC%D0%B5%D0%BD%D1%8F%D1%82%D1%8C+%D0%BF%D1%80%D0%B8%D0%B2%D0%B0%D1%82%D0%BD%D0%BE%D1%81%D1%82%D1%8C+%D1%80%D0%B5%D0%BF%D0%BE%D0%B7%D0%B8%D1%82%D0%BE%D1%80%D0%B8%D1%8F+%D0%BD%D0%B0+github&lr=120612&src=suggest_Pers";

            HttpClient client = new HttpClient();
            string page = await client.GetStringAsync(url);

            using var context = BrowsingContext.New(Configuration.Default);
            using var doc = await context.OpenAsync(req => req.Content(page));

            var quickAnswer = doc.GetElementsByClassName(
                "serp-item serp-item_card serp-item_card-extra-shadow " +
                "serp-item_card-no-padding-bottom has-branding " +
                "has-branding__fact has-branding__show-hint");
            if (quickAnswer.Length != 0)
            {
                quickAnswer = quickAnswer[0].GetElementsByClassName(
                    "Fact Fact_flexSize_no Fact_answerGap_l");
                var elems = quickAnswer[0].Children;

                for (int i = 0; i < elems.Length; i++)
                {
                    if (elems[i].ClassName != "Fact-Source" && 
                        elems[i].ClassName != "ExtraActions Typo Typo_text_s Typo_line_m Fact-Footer")
                    {
                        var lll = elems[i].QuerySelectorAll("div");
                        //if (lll.Length != 0)
                        {
                            sp.Children.Add(new TextBlock()
                            {
                                Text = elems[i].TextContent,
                                MaxWidth = 400,
                                TextWrapping = TextWrapping.Wrap,
                                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                                FontSize = 15
                            });
                        }
                    }
                    else if (elems[i].ClassName == "Fact-Source")
                    {
                        var href = elems[i].GetElementsByClassName("Link Fact-SiteSource")[0].GetAttribute("href");
                        var sitename = elems[i].GetElementsByClassName("Path-Item")[0].QuerySelector("b").TextContent;
                        var pagename = elems[i].GetElementsByClassName("OneLine Fact-Title Typo Typo_text_xm Typo_line_m")[0].TextContent;

                        var downloadHyperlink = new Hyperlink()
                        {
                            NavigateUri = new Uri(href)
                        };
                        downloadHyperlink.RequestNavigate += (s, e) =>
                        Process.Start(new ProcessStartInfo(href)
                        { UseShellExecute = true });

                        downloadHyperlink.Inlines.Add(pagename);

                        var downloadHyperlinkTextBlock = new TextBlock()
                        {
                            HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                            FontSize = 15
                        };
                        downloadHyperlinkTextBlock.Inlines.Add(downloadHyperlink);

                        sp.Children.Add(new TextBlock()
                        {
                            Text = sitename,
                            HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                            FontSize = 15
                        });
                        sp.Children.Add(downloadHyperlinkTextBlock);
                    }
                }





                //for (int i = 0; i < instr.Length; i++)
                //{
                //    sp.Children.Add(new StackPanel()
                //    {
                //        Children = {
                //            new TextBlock()
                //            {
                //                Text = $"{i + 1}) ",
                //                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                //                FontSize = 15
                //            },

                //            new TextBlock() 
                //            { 
                //                Text = instr[i].TextContent, 
                //                MaxWidth = 400, 
                //                TextWrapping = TextWrapping.Wrap, 
                //                HorizontalAlignment = System.Windows.HorizontalAlignment.Left, 
                //                FontSize = 15 
                //            } 
                //        },
                //        Orientation = Orientation.Horizontal
                //    });
                //}

                
            }
            else sp.Children.Add(new TextBlock() { Text = "non" });
        }
    }
}
/*
 Fact-Summarize Typo Typo_text_xxl Typo_line_m
 Fact-ECFragment Fact-ECFragment Fact-ECFragment_typo
 Fact-ECTitle Typo Typo_text_l Typo_line_m Typo_type_bold
 Fact-ECFragment Fact-ECFragment_marker_number Fact-ECFragment Fact-ECFragment_typo
 Fact-ECFragment Fact-ECFragment Fact-ECFragment_typo
 
 */