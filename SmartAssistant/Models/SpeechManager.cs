using System;

namespace SmartAssistant.Models
{
    public static class SpeechManager
    {
        static SpeechManager()
        {
            StateManager.SpeechStateVerifiedEvent += ChangingRequest;
        }

        public static void Initialize() { }

        private static void ChangingRequest(string text)
        {
            
        }
    }
}
