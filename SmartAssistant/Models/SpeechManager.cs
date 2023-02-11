using System;

namespace SmartAssistant.Models
{
    public static class SpeechManager
    {
        static SpeechManager()
        {
            StateManager.SpeechStateVerifiedEvent += ChangingRequest;
        }

        private static void ChangingRequest(string text)
        {
            
        }
    }
}
