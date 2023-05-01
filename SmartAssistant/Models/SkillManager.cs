using SmartAssistant.Data.MultiAnswersData;
using SmartAssistant.Data.WordsData;
using System;
using System.Collections.Generic;
using System.Threading;

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
            AnswerChangedEvent += SpeakAnswer;
        }

        private static void SpeakAnswer(string text)
        {
            TTS.Speak(text);
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

            DefineAnswer(wordsList, text);
        }

        private static void DefineAnswer(List<WordsObj> wordsObjs, string text)
        {
            if (wordsObjs.Count > 1)
            {
                List<OCS> results = new List<OCS>();
                for (int i = 0; i < wordsObjs.Count; i++)
                    results.Add(CallingSkill(wordsObjs[i], text));
                foreach (var result in results)
                {
                    if (result.IsText)
                    {
                        AnswerChangedEvent?.Invoke(result.Text);
                        return;
                    }
                    else
                    {
                        if (!result.Result)
                        {
                            NegativeMultiAnswer();
                            return;
                        }
                    }
                }
                PositiveMultiAnswer();
            }
            else if (wordsObjs.Count == 1)
            {
                var wordsObj = wordsObjs[0];
                OCS oCSResult = CallingSkill(wordsObj, text);
                if (!oCSResult.IsText)
                {
                    if (oCSResult.Result) 
                        PositiveSingleAnswer(wordsObj);
                    else NegativeSingleAnswer(wordsObj);
                }
                else AnswerChangedEvent?.Invoke(oCSResult.Text);
            }
            else NoDefinedAnswer();
        }

        private static void PositiveMultiAnswer()
        {
            var positiveAnswers = MultiAnswers.JsonObject.Positive;
            string resultPositiveAnswer = positiveAnswers[new Random().Next(positiveAnswers.Count)];
            AnswerChangedEvent?.Invoke(resultPositiveAnswer);
        }

        private static void NegativeMultiAnswer()
        {
            var negativeAnswers = MultiAnswers.JsonObject.Negative;
            string resultNegativeAnswer = negativeAnswers[new Random().Next(negativeAnswers.Count)];
            AnswerChangedEvent?.Invoke(resultNegativeAnswer);
        }

        private static void PositiveSingleAnswer(WordsObj wordsObj)
        {
            var positiveAnswers = wordsObj.Answers.Positive;
            string resultPositiveAnswer = positiveAnswers[new Random().Next(positiveAnswers.Count)];
            AnswerChangedEvent?.Invoke(resultPositiveAnswer);
        }

        private static void NegativeSingleAnswer(WordsObj wordsObj)
        {
            var negativeAnswers = wordsObj.Answers.Negative;
            string resultNegativeAnswer = negativeAnswers[new Random().Next(negativeAnswers.Count)];
            AnswerChangedEvent?.Invoke(resultNegativeAnswer);
        }

        private static void NoDefinedAnswer()
        {
            var noDefinedAnswers = MultiAnswers.JsonObject.NoDefined;
            string resultNoDefinedAnswer = noDefinedAnswers[new Random().Next(noDefinedAnswers.Count)];
            AnswerChangedEvent?.Invoke(resultNoDefinedAnswer);
        }

        private static OCS CallingSkill(WordsObj wordsObj, string text)
        {
            Type type = Type.GetType(namespaceSkills + wordsObj.Parameters.ClassName + "Skill");
            object instance = Activator.CreateInstance(type);

            if (wordsObj.Parameters.MethodName == null)
                wordsObj.Parameters.MethodName = nameMethodCallingDefault;

            ICS inputCallingSkills = new ICS()
            {
                WordsObj = wordsObj,
                Text = text,
            };

            try
            {
                var methodInfo = type.GetMethod(wordsObj.Parameters.MethodName);
                return (OCS)methodInfo.Invoke(instance, new object[]
                { inputCallingSkills });
            }
            catch
            {
                return new OCS() { Result = false};
            }
        }
    }
}
