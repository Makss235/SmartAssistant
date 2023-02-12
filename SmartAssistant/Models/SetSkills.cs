using SmartAssistant.Data;
using System;
using System.Collections.Generic;
using System.Windows;

namespace SmartAssistant.Models
{
    public static class SetSkills
    {
        private static string namespaceSkills = "SmartAssistant.Models.Skills.";
        private static string nameMethodCallingDefault = "Calling";

        static SetSkills()
        {
            StateManager.SpeechStateVerifiedEvent += DefineSkills;
        }

        public static void Initialize() { }

        private static void DefineSkills(string text)
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

            if (wordsList.Count > 1) MessageBox.Show(wordsList[0].Answers.Positive[0]);
            else if (wordsList.Count == 1) CallingSkill(wordsList[0], text);
            // TODO: Сделать проверку на 0 
        }

        private static bool CallingSkill(WordsObj words, string text)
        {
            Type type = Type.GetType(namespaceSkills + words.Parameters.ClassName);
            object instance = Activator.CreateInstance(type);

            if (words.Parameters.MethodName == null)
                words.Parameters.MethodName = "Calling";

            try
            {
                var methodInfo = type.GetMethod(words.Parameters.MethodName);
                bool result = (bool)methodInfo.Invoke(instance, new object[]
                {
                    text,
                    words.Parameters.Args
                });
                return result;
            }
            catch
            {
                return false;
            }
        }

        private static void CallingSkills(List<WordsObj> wordsList, string text)
        {
            List<bool> results = new List<bool>();
            for (int i = 0; i < wordsList.Count; i++)
            {
                results.Add(CallingSkill(wordsList[i], text));
            }
            foreach (bool result in results)
            {
                if (!result) return;
            }
        }
    }
}
