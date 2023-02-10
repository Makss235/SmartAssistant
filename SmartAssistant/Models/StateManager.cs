using SmartAssistant.Data;
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
        public static event Action SpeechStateVerifiedEvent;

        public static AppSpeechStates CurrentSpeechState
        {
            get => CurrentSpeechState;
            set
            {
                CurrentSpeechState = value;
                SpeechStateChangedEvent?.Invoke(CurrentSpeechState);
            }
        }

        private static string text;

        static StateManager()
        {
            STT.CCSTTF.ChangingTextSTTFEvent += ChangingRequest;
        }

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
            var greetongWords = GreetingWords.GreetingsObj;

            if (CurrentSpeechState == AppSpeechStates.PressedButton) 
                SpeechStateVerifiedEvent?.Invoke();
            else if (CurrentSpeechState == AppSpeechStates.Opened)
            {

            }
        }
    }
}
