namespace SmartAssistant.Data.SettingsData
{
    public class SetObj
    {
        public string Language { get; set; }
        public MainWindowSet MainWindowSet { get; set; }
    }

    public class MainWindowSet
    {
        public Size_MW Size_MW { get; set; }
    }

    public class Size_MW
    {
        /// <summary>Ширина окна</summary>
        public int Width { get; set; }

        /// <summary>Высота окна</summary>
        public int Height { get; set; }

        /// <summary>Ширина главной части окна</summary>
        public int MainFieldWidth { get; set; }

        /// <summary>Ширина границы-меню</summary>
        public int BorderWidth { get; set; }

        /// <summary>Ширина левого меню</summary>
        public int LeftMenuWidth { get; set; }
    }
}
