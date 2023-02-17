using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace STT
{
    /// <summary>
    /// CCSTTF - catching changes STT (speech to text) file
    /// </summary>
    public class CCSTTF
    {
        private string STTF;
        private Thread CCSTTF_Thread;
        private bool canClose = false;

        public static Action<string> ChangingTextSTTFEvent;

        private string _TextSTT = "";

        public string TextSTT { 
            get => _TextSTT;
            set 
            {
                _TextSTT = value;
                ChangingTextSTTFEvent?.Invoke(TextSTT);
            }
        }

        public CCSTTF()
        {
            STTF = "STTF.txt";
            CCSTTF_Thread = new Thread(() => CChangeDateSTTF());
        }

        public void Start() => CCSTTF_Thread.Start();
        public void Stop() => canClose = true;

        public void CChangeDateSTTF()
        {
            DateTime currentWritingTime = File.GetLastWriteTime(STTF);
            DateTime previousWritingTime = File.GetLastWriteTime(STTF);

            while (!canClose)
            {
                string text = "";
                currentWritingTime = File.GetLastWriteTime(STTF);
                if (currentWritingTime == previousWritingTime)
                {
                    Thread.Sleep(100);
                    continue;
                }
                else if (currentWritingTime > previousWritingTime)
                {
                    text = OpenSTT(STTF);
                    previousWritingTime = currentWritingTime;
                }

                if (Equals(text, String.Empty) ||
                    Equals(text, null)) continue;
                else TextSTT = text;
                Thread.Sleep(100);
            }
        }

        public string OpenSTT(string STTF)
        {
            while (true)
            {
                try
                {
                    return File.ReadAllText(STTF);
                }
                catch (IOException)
                {
                    Thread.Sleep(1);
                    continue;
                }
            }
        }
    }
}