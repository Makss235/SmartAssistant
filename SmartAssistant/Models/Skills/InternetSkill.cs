using SmartAssistant.Data.SitesData;
using System.Collections.Generic;

namespace SmartAssistant.Models.Skills
{
    public class InternetSkill
    {
        public OCS Search(ICS iCS)
        {
            OCS oCS = new OCS()
            {
                IsText = false,
                Result = false
            };

            foreach (var requestString in iCS.WordsObj.TriggerWords)
            {
                int indexOfSearch = iCS.Text.IndexOf(requestString);
                if (indexOfSearch != -1)
                {
                    try
                    {
                        char[] charArraySearch = iCS.Text.ToCharArray()
                        [(indexOfSearch + requestString.Length + 1)..iCS.Text.Length];
                        System.Diagnostics.Process.Start(
                            @"C:\Program Files\Internet Explorer\iexplore.exe",
                            "https://yandex.ru/search/?text=" + string.Join("", charArraySearch));

                        Parce parce = new Parce();
                        oCS.AnswerPresenter = parce;

                        oCS.Result = true;
                        oCS.IsText = true;
                        oCS.AnswerSpeak = parce.Text;
                        return oCS;
                    }
                    catch
                    {
                        return oCS;
                    }
                }
            }
            return oCS;
        }

        public OCS OpenSite(ICS iCS)
        {
            List<bool> results = new List<bool>();

            for (int i = 0; i < Sites.JsonObject.Count; i++)
            {
                var siteObj = Sites.JsonObject[i];
                for (int j = 0; j < siteObj.Names.Count; j++)
                {
                    FuzzyString.FuzzyString fuzzyString = new FuzzyString.FuzzyString();
                    var fuzzy = fuzzyString.FuzzySentence(siteObj.Names[j], iCS.Text);
                    if (fuzzy.Length == siteObj.Names[j].Length)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(
                                @"C:\Program Files\Internet Explorer\iexplore.exe",
                                siteObj.Url);
                            results.Add(true);
                        }
                        catch
                        {
                            results.Add(false);
                        }
                    }
                }
            }
            OCS oCS = new OCS();
            oCS.IsText = false;

            foreach (bool result in results)
            {
                if (!result)
                {
                    oCS.Result = false;
                    return oCS;
                };
            }
            oCS.Result = true;
            return oCS;
        }
    }
}
