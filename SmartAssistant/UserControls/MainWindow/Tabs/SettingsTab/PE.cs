using SmartAssistant.Data.ProgramsData;
using SmartAssistant.UserControls.Widgets;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace SmartAssistant.UserControls.MainWindow.Tabs.SettingsTab
{
    public class PE : UserControl, INotifyPropertyChanged
    {
        public ObservableCollection<string> ProgramNames { get; set; }

        private string _Path;

        public string Path
        {
            get => _Path;
            set => SetProperty(ref _Path, value);
        }

        public PE(ProgramObj programObj)
        {
            ProgramNames = new ObservableCollection<string>(programObj.CallingNames);
            Path = programObj.Path;

            InitializeComponent();
        }

        #region NPC

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            //if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

        #endregion

        private void InitializeComponent()
        {
            StackPanel stackPanel = new StackPanel();

            if (ProgramNames.Count > 1)
            {
                ListBox listBox = new ListBox();
                for (int i = 1; i < ProgramNames.Count; i++)
                {
                    listBox.Items.Add(ProgramNames[i]);
                }

                SExpander sExpander1 = new SExpander()
                {
                    HeaderContent = "Другие названия программы.loc",
                    IsExpanded = false,
                    BodyContent = listBox
                };
                stackPanel.Children.Add(sExpander1);
            }
            stackPanel.Children.Add(new TextBlock() { Text = Path });

            SExpander sExpander = new SExpander()
            {
                HeaderContent = new TextBlock()
                {
                    Text = ProgramNames[0]
                },
                BodyContent = stackPanel,
                IsExpanded = false
            };

            Content = sExpander;
        }
    }
}
