using System.Diagnostics;
using System.Reflection;

namespace STT
{
    public class STT
    {
        private string language;
        private string exePythonPath;
        private string directory;
        private string script;

        public Process STTProcess { get; private set; }

        public STT(string language)
        {
            this.language = language;
            STTProcess = new Process();
            exePythonPath = Path.Combine(Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location), "Python310\\python.exe");
            directory = Path.Combine(Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location), "stt\\");
            script = "main.py";
        }

        public void Start() { Init(); STTProcess.Start(); }
        public void Stop() { STTProcess.Kill(); }

        private void Init()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = exePythonPath;

            startInfo.WorkingDirectory = directory;
            startInfo.Arguments = script;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardOutput = true;
            STTProcess.StartInfo = startInfo;
        }
    }
}