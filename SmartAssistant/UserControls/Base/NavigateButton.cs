using SmartAssistant.Infrastructure.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;

namespace SmartAssistant.UserControls.Base
{
    public abstract class NavigateButton : UserControl, INotifyPropertyChanged
    {
        #region NPC

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

        #endregion

        public enum TypeButton
        {
            Previous,
            Next
        }

        #region Title : string - Заголовок кнопки

        /// <summary>Заголовок кнопки</summary>
        private string _Title;

        /// <summary>Заголовок кнопки</summary>
        public string Title
        {
            get => _Title;
            set => SetProperty(ref _Title, value);
        }

        #endregion

        #region TypeButton : byte - Тип кнопки

        /// <summary>Тип кнопки</summary>
        private TypeButton _Type;

        /// <summary>Тип кнопки</summary>
        public TypeButton Type
        {
            get => _Type;
            set => SetProperty(ref _Type, value);
        }

        #endregion

        #region ID : byte - Идентификатор кнопки

        /// <summary>Идентификатор кнопки</summary>
        private byte _ID;

        /// <summary>Идентификатор кнопки</summary>
        public byte ID
        {
            get => _ID;
            set => SetProperty(ref _ID, value);
        }

        #endregion

        public ICommand ClickCommand;
        protected virtual bool CanClickCommandExecute(object sender) => true;
        protected abstract void OnClickCommandExecuted(object sender);

        public NavigateButton(string title, TypeButton type, byte id)
        {
            Title = title;
            Type = type;
            ID = id;

            ClickCommand = new LambdaCommand(
                OnClickCommandExecuted,
                CanClickCommandExecute);
        }
    }
}
