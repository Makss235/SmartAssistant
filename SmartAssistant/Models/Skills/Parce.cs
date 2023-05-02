using AngleSharp;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SmartAssistant.Models.Skills
{
    public class Parce : StackPanel
    {
        public string Text { get; set; }

        public Parce()
        {
            Text = "";
            p();
        }

        private async void p()
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
                            Children.Add(new TextBlock()
                            {
                                Text = elems[i].TextContent,
                                MaxWidth = 400,
                                TextWrapping = TextWrapping.Wrap,
                                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                                FontSize = 15
                            });

                            Text += elems[i].TextContent;
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

                        Children.Add(new TextBlock()
                        {
                            Text = sitename,
                            HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                            FontSize = 15
                        });
                        Children.Add(downloadHyperlinkTextBlock);
                    }
                }
            }
        }
    }
}
