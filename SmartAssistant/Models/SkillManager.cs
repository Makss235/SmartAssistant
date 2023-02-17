using SmartAssistant.Data.MultiAnswersData;
using SmartAssistant.Data.WordsData;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;

namespace SmartAssistant.Models
{
    public static class SkillManager
    {
        private static string namespaceSkills = "SmartAssistant.Models.Skills.";
        private static string nameMethodCallingDefault = "Calling";

        public static event Action<string> AnswerChangedEvent;

        static SkillManager()
        {
            StateManager.SpeechStateVerifiedEvent += DefineSkills;
        }

        public static void Initialize() { }

        public static void DefineSkills(string text)
        {
            Thread.Sleep(10);
            List<WordsObj> wordsList = new List<WordsObj>();
            for (int i = 0; i < Words.JsonObject.Count; i++)
            {
                for (int j = 0; j < Words.JsonObject[i].TriggerWords.Count; j++)
                {
                    var triggerWord = Words.JsonObject[i].TriggerWords[j];
                    FuzzyString.FuzzyString fuzzyString = new FuzzyString.FuzzyString();
                    var fuzzy = fuzzyString.FuzzySentence(triggerWord, text);

                    if (Equals(fuzzy, triggerWord))
                    {
                        text = fuzzyString.ReplaceFuzzyWord(triggerWord, text);
                        wordsList.Add(Words.JsonObject[i]);
                        break;
                    }
                }
            }

            if (wordsList.Count > 1) DefineAnswersAndCallingSkills(wordsList, text);
            else if (wordsList.Count == 1) DefineAnswerAndCallingSkill(wordsList[0], text);
            else NoDefinedAnswer();
        }

        private static void NoDefinedAnswer()
        {
            var noDefinedAnswers = MultiAnswers.JsonObject.NoDefined;
            string resultNoDefinedAnswer = noDefinedAnswers[new Random().Next(noDefinedAnswers.Count)];
            AnswerChangedEvent?.Invoke(resultNoDefinedAnswer);
            MessageBox.Show(resultNoDefinedAnswer);
        }

        private static void DefineAnswersAndCallingSkills(List<WordsObj> wordsObjs, string text)
        {
            List<bool> results = new List<bool>();
            for (int i = 0; i < wordsObjs.Count; i++)
                results.Add(CallingSkill(wordsObjs[i], text));
            foreach (bool result in results)
            {
                if (!result)
                {
                    var negativeAnswers = MultiAnswers.JsonObject.Negative;
                    string resultNegativeAnswer = negativeAnswers[new Random().Next(negativeAnswers.Count)];
                    AnswerChangedEvent?.Invoke(resultNegativeAnswer);
                    return;
                }
            } 

            var positiveAnswers = MultiAnswers.JsonObject.Positive;
            string resultPositiveAnswer = positiveAnswers[new Random().Next(positiveAnswers.Count)];
            AnswerChangedEvent?.Invoke(resultPositiveAnswer);
        }

        private static void DefineAnswerAndCallingSkill(WordsObj wordsObj, string text)
        {
            bool result = CallingSkill(wordsObj, text);
            if (result)
            {
                var positiveAnswers = wordsObj.Answers.Positive;
                string resultPositiveAnswer = positiveAnswers[new Random().Next(positiveAnswers.Count)];
                AnswerChangedEvent?.Invoke(resultPositiveAnswer);
            }
            else
            {
                var negativeAnswers = wordsObj.Answers.Negative;
                string resultNegativeAnswer = negativeAnswers[new Random().Next(negativeAnswers.Count)];
                AnswerChangedEvent?.Invoke(resultNegativeAnswer);
            }
        }

        private static bool CallingSkill(WordsObj wordsObj, string text)
        {
            Type type = Type.GetType(namespaceSkills + wordsObj.Parameters.ClassName + "Skill");
            object instance = Activator.CreateInstance(type);

            if (wordsObj.Parameters.MethodName == null)
                wordsObj.Parameters.MethodName = nameMethodCallingDefault;

            try
            {
                var methodInfo = type.GetMethod(wordsObj.Parameters.MethodName);
                return (bool)methodInfo.Invoke(instance, new object[]
                {
                    text,
                    wordsObj
                });
            }
            catch
            {
                return false;
            }
        }
    }
}
