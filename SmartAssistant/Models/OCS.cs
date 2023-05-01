namespace SmartAssistant.Models
{
    public struct OCS
    {
        public bool Result { get; set; }
        public bool IsText { get; set; }
        public string Text { get; set; }

        public OCS()
        {
            Result = false;
            IsText = false;
            Text = string.Empty;
        }
    }
}
