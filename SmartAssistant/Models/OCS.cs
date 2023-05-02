using System.Windows;

namespace SmartAssistant.Models
{
    public struct OCS
    {
        public bool Result { get; set; }
        public bool IsText { get; set; }
        public string AnswerSpeak { get; set; }
        public FrameworkElement AnswerPresenter { get; set; }

        public OCS()
        {
            Result = false;
            IsText = false;
            AnswerSpeak = string.Empty;
            AnswerPresenter = new FrameworkElement();
        }
    }
}
