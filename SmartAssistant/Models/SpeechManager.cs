using System;

namespace SmartAssistant.Models
{
    public static class SpeechManager
    {
        

        static SpeechManager()
        {
            STT.CCSTTF.ChangingTextSTTFEvent += ChangingRequest;
        }

        private static void ChangingRequest(string text)
        {
            
        }
    }
}
