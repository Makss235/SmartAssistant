using SmartAssistant.Data.ProgramsData;
using SmartAssistant.Infrastructure;
using System.Collections.Generic;

namespace SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab
{
    public class ProgramElement : NPC
    {
        #region Колонки в таблице

        #region Name : string - Имя программы

        /// <summary>Имя программы</summary>
        private string _Name = string.Empty;

        /// <summary>Имя программы</summary>
        public string Name
        {
            get => _Name;
            set => SetProperty(ref _Name, value);
        }

        #endregion

        #region CallingName : AsyncObservableCollection<string> - Как будете звать?

        /// <summary>Как будете звать?</summary>
        public AsyncObservableCollection<string> CallingNames { get; private set; }

        #endregion

        #region Path : string - Путь к программе

        /// <summary>Путь к программе</summary>
        private string _Path = string.Empty;

        /// <summary>Путь к программе</summary>
        public string Path
        {
            get => _Path;
            set => SetProperty(ref _Path, value);
        }

        #endregion

        #endregion

        #region Constructors

        // TODO: Makss может стоит убрать первую колонку
        public ProgramElement(string name, List<string> callingName, string path)
        {
            Name = name;
            CallingNames = new AsyncObservableCollection<string>(callingName);
            Path = path;
        }

        public ProgramElement(ProgramObj programObj)
        {
            Name = programObj.Name;
            CallingNames = new AsyncObservableCollection<string>(programObj.CallingNames);
            Path = programObj.Path;
        }

        public ProgramElement() { }

        #endregion
    }
}
