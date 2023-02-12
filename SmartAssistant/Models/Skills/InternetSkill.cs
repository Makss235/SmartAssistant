using SmartAssistant.Data.SitesData;
using SmartAssistant.Data.WordsData;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace SmartAssistant.Models.Skills
{
    public class InternetSkill
    {
        public bool Search(string text, WordsObj wordsObj)
        {
            foreach (var requestString in wordsObj.TriggerWords)
            {
                int indexOfSearch = text.IndexOf(requestString);
                if (indexOfSearch != -1)
                {
                    try
                    {
                        char[] charArraySearch = text.ToCharArray()
                        [(indexOfSearch + requestString.Length + 1)..text.Length];
                        System.Diagnostics.Process.Start(
                            @"C:\Program Files\Internet Explorer\iexplore.exe",
                            "https://yandex.ru/search/?text=" + string.Join("", charArraySearch));
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public bool OpenSite(string text, WordsObj wordsObj)
        {
            List<bool> results = new List<bool>();

            for (int i = 0; i < Sites.SiteObjs.Count; i++)
            {
                var siteObj = Sites.SiteObjs[i];
                for (int j = 0; j < siteObj.Names.Count; j++)
                {
                    FuzzyString.FuzzyString fuzzyString = new FuzzyString.FuzzyString();
                    var fuzzy = fuzzyString.FuzzySentence(siteObj.Names[j], text);
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
            foreach (bool result in results)
            {
                if (!result) return false;
            }
            return true;
        }
    }
}
