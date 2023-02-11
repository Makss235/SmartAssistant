using SmartAssistant.Data;
using System;
using System.Collections.Generic;

namespace SmartAssistant.Models
{
    public class SetSkills
    {
        private string namespaceCalling = "SmartAssistant.Models.Skills.";
        private string nameMethodCallingDefault = "Calling";

        public SetSkills()
        {
            StateManager.SpeechStateVerifiedEvent += DefineSkills;
        }

        private void DefineSkills(string text)
        {
            List<WordsObj> wordsList = new List<WordsObj>();
            for (int i = 0; i < Words.WordsObjs.Count; i++)
            {
                for (int j = 0; j < Words.WordsObjs[i].TriggerWords.Count; j++)
                {
                    var triggerWord = Words.WordsObjs[i].TriggerWords[j];
                    FuzzyString.FuzzyString fuzzyString = new FuzzyString.FuzzyString();
                    var fuzzy = fuzzyString.FuzzySentence(triggerWord, text);

                    if (Equals(fuzzy, triggerWord))
                    {
                        text = fuzzyString.ReplaceFuzzyWord(triggerWord, text);
                        wordsList.Add(Words.WordsObjs[i]);
                        break;
                    }
                }
            }

            if (wordsList.Count > 1) CallingSkills(wordsList, text);
            else if (wordsList.Count == 1) CallingSkill(wordsList[0], text);
            // TODO: Сделать проверку на 0 
        }

        private void CallingSkill(WordsObj words, string text)
        {
            Type type = Type.GetType(namespaceCalling + words.Parameters.ClassName);
            object instance = Activator.CreateInstance(type);

            if (words.Parameters.MethodName == null)
                words.Parameters.MethodName = "Calling";

            try
            {
                var methodInfo = type.GetMethod(words.Parameters.MethodName);
                bool result = (bool)methodInfo.Invoke(instance, new object[]
                {
                    text
                });
            }
            catch
            {

            }
        }

        private void CallingSkills(List<WordsObj> wordsList, string text)
        {

        }
    }
}
