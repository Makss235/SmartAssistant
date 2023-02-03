using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CCSTTF
{
    /// <summary>
    /// CCSTTF - catching changes STT (speech to text) file
    /// </summary>
    public class CCSTTF : INotifyPropertyChanged
    {
        private string STTF;
        private Thread CCSTTF_Tread;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

        private string _TextSTT = "";

        public string TextSTT { 
            get => _TextSTT;
            set => SetProperty(ref _TextSTT, value);
        }

        public CCSTTF()
        {
            STTF = "STTF.txt";
            CCSTTF_Tread = new Thread(() => ChangeDateSTTF());
        }

        public void Start() => CCSTTF_Tread.Start();
        public void Stop() => CCSTTF_Tread.Abort();

        public void ChangeDateSTTF()
        {
            DateTime currentWritingTime = File.GetLastWriteTime(STTF);
            DateTime previousWritingTime = File.GetLastWriteTime(STTF);

            while (true)
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

        public string OpenSTT(string STT)
        {
            while (true)
            {
                try
                {
                    return File.ReadAllText(STT);
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