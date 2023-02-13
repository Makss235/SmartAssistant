using SmartAssistant.Data.GreetingsData;
using SmartAssistant.Data.TriggersData;
using System;

namespace SmartAssistant.Models
{
    public static class StateManager
    {
        public enum AppSpeechStates
        {
            /// <summary>Программа находится в трее</summary>
            Collapsed,
            /// <summary>Программа открыта на панели задач</summary>
            Opened,
            /// <summary>Нажата кнопка "говорить"</summary>
            PressedButton
        }

        public static event Action<AppSpeechStates> SpeechStateChangedEvent;
        public static event Action<string> SpeechStateVerifiedEvent;

        private static AppSpeechStates _CurrentSpeechState = AppSpeechStates.Collapsed;
        public static AppSpeechStates CurrentSpeechState
        {
            get => _CurrentSpeechState;
            set
            {
                _CurrentSpeechState = value;
                SpeechStateChangedEvent?.Invoke(_CurrentSpeechState);
            }
        }

        private static string text;

        static StateManager()
        {
            STT.CCSTTF.ChangingTextSTTFEvent += ChangingRequest;
        }

        public static void Initialize() { }

        private static void ChangingRequest(string Text)
        {
            if (!Equals(Text, string.Empty) && !Equals(Text, null) && !Equals(Text, text))
            {
                text = Text;
                CheckStates();
            }
        }

        private static void CheckStates()
        {
            var triggerWords = TriggerWords.TriggersObj;
            var greetingWords = GreetingWords.GreetingsObj;

            if (CurrentSpeechState == AppSpeechStates.PressedButton) 
                SpeechStateVerifiedEvent?.Invoke(text);
            else if (CurrentSpeechState == AppSpeechStates.Opened)
            {
                for (int i = 0; i < triggerWords.Count; i++)
                {
                    var fuzzyString = new FuzzyString.FuzzyString();
                    if (fuzzyString.FuzzySentence(text, triggerWords[i]).Length
                        == triggerWords[i].Length)
                    {
                        SpeechStateVerifiedEvent?.Invoke(text);
                        break;
                    }
                }
            }
            else if (CurrentSpeechState == AppSpeechStates.Collapsed)
            {
                int quantity = 0;
                for (int i = 0; i < triggerWords.Count; i++)
                {
                    var fuzzyString = new FuzzyString.FuzzyString();
                    if (fuzzyString.FuzzySentence(text, triggerWords[i]).Length
                        == triggerWords[i].Length)
                    {
                        quantity += triggerWords[i].Split(' ').Length;
                        break;
                    }
                    else
                    {
                        if (i == triggerWords.Count - 1) return;
                        else continue;
                    }
                }
                for (int i = 0; i < greetingWords.Count; i++)
                {
                    var fuzzyString = new FuzzyString.FuzzyString();
                    if (fuzzyString.FuzzySentence(text, greetingWords[i]).Length
                        == greetingWords[i].Length)
                    {
                        quantity += greetingWords[i].Split(' ').Length;
                        break;
                    }
                    else
                    {
                        if (i == greetingWords.Count - 1) return;
                        else continue;
                    }
                }

                //if (quantity == textRequest.Split(' ').Length)
                //{
                //    dataSpeech.TextAnswer = "Я Вас внимательно слушаю";
                //    ServiceTTS.SpeechSynthesizer.SpeakAsync(dataSpeech.TextAnswer);
                //}
                //else
                SpeechStateVerifiedEvent?.Invoke(text);
            }
        }
    }
}
