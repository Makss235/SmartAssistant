using SmartAssistant.Data.ProgramsData;
using SmartAssistant.Data.WordsData;
using System.Collections.Generic;
using System.Diagnostics;

namespace SmartAssistant.Models.Skills
{
    public class ProgramsSkill
    {
        public OCS OpenProgram(ICS iCS)
        {
            List<bool> results = new List<bool>();

            foreach (var programObj in Programs.JsonObject)
            {
                foreach (var callingNameProgram in programObj.CallingNames)
                {
                    FuzzyString.FuzzyString fuzzyString = new FuzzyString.FuzzyString();
                    var fuzzy = fuzzyString.FuzzySentence(callingNameProgram, iCS.Text);
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
