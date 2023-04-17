using SmartAssistant.Data.ProgramsData;
using SmartAssistant.UserControls.Widgets;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows;
using SmartAssistant.Windows.AddCNWindow;
using SmartAssistant.Infrastructure.Commands;
using System;

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

        public event Action<PE> A;

        private AddCNWindow addCNWindow;

        private ListBox listBox;
        private SExpander sExpander1;

        public PE(ProgramObj programObj)
        {
            ProgramNames = new ObservableCollection<string>(programObj.CallingNames);
            Path = programObj.Path;

            addCNWindow = new AddCNWindow(new Point(100, 100));
            addCNWindow.AddCallingNameEvent += AddCNWindow_AddCallingNameEvent;

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
            MenuItem menuItem = new MenuItem()
            {
                Header = "Удалить"
            };
            menuItem.Click += (se, e) =>
            {
                listBox.Items.Remove(listBox.SelectedItem);
                if (listBox.Items.Count == 0)
                {
                    sExpander1.Visibility = Visibility.Collapsed;
                }
            };
            MenuItem menuItem1 = new MenuItem()
            {
                Header = "Добавить"
            };
            menuItem1.Click += (se, e) => addCNWindow.Show();

            ContextMenu contextMenu = new ContextMenu();
            contextMenu.Items.Add(menuItem1);
            contextMenu.Items.Add(menuItem);

            listBox = new ListBox();
            listBox.ContextMenu = contextMenu;
            sExpander1 = new SExpander()
            {
                HeaderContent = "Другие названия программы.loc",
                IsExpanded = false,
                BodyContent = listBox
            };

            if (ProgramNames.Count > 1)
                for (int i = 1; i < ProgramNames.Count; i++)
                    listBox.Items.Add(ProgramNames[i]);
            else
                sExpander1.Visibility = Visibility.Collapsed;

            Button button = new Button()
            {
                Content = "+",
                Height = 25,
                Margin = new Thickness(5, 2, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
            };
            button.Click += Button_Click;

            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;
            sp.Children.Add(sExpander1);
            sp.Children.Add(button);

            StackPanel stackPanel = new StackPanel();
            stackPanel.Children.Add(sp);
            stackPanel.Children.Add(new TextBlock() { Text = Path });

            MenuItem menuItem2 = new MenuItem()
            {
                Header = "Удалить",
                Command = new LambdaCommand((s) => A?.Invoke(this), (s) => true)
            };

            ContextMenu contextMenu1 = new ContextMenu();
            contextMenu1.Items.Add(menuItem2);

            TextBlock textBlock = new TextBlock()
            {
                Text = ProgramNames[0],
                ContextMenu = contextMenu1
            };

            SExpander sExpander = new SExpander()
            {
                HeaderContent = textBlock,
                BodyContent = stackPanel,
                IsExpanded = false
            };

            Content = sExpander;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addCNWindow.Show();
        }

        private void AddCNWindow_AddCallingNameEvent(string obj)
        {
            listBox.Items.Add(obj);
            sExpander1.IsExpanded = true; 
            sExpander1.Visibility = Visibility.Visible;
        }
    }
}
