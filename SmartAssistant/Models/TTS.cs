using System.Speech.Synthesis;

namespace SmartAssistant.Models
{
    public static class TTS
    {
        private static SpeechSynthesizer speechSynthesizer;

        static TTS()
        {
            speechSynthesizer = new SpeechSynthesizer();

            speechSynthesizer.Volume = 100;
            speechSynthesizer.Rate = 2;

            foreach (InstalledVoice installedVoice in speechSynthesizer.GetInstalledVoices())
            {
                if (installedVoice.VoiceInfo.Id == "Aleksandr-hq")
                    speechSynthesizer.SelectVoice(installedVoice.VoiceInfo.Name);
            }
        }

        public static void Initialize() { }

        public static void Speak(string text)
        {
            speechSynthesizer.SpeakAsync(text);
        }
    }
}
