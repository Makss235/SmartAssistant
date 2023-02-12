using SmartAssistant.Data.ProgramsData;
using SmartAssistant.Data.WordsData;
using System.Collections.Generic;
using System.Diagnostics;

namespace SmartAssistant.Models.Skills
{
    public class ProgramsSkill
    {
        public bool OpenProgram(string text, WordsObj wordsObj)
        {
            List<bool> results = new List<bool>();

            foreach (var programObj in Programs.ProgramObjs)
            {
                foreach (var callingNameProgram in programObj.CallingNames)
                {
                    FuzzyString.FuzzyString fuzzyString = new FuzzyString.FuzzyString();
                    var fuzzy = fuzzyString.FuzzySentence(callingNameProgram, text);
                    if (fuzzy.Length == callingNameProgram.Length)
                    {
                        try
                        {
                            Process.Start(programObj.Path);
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
