using SmartAssistant.Infrastructure.Commands;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;

namespace SmartAssistant.UserControls.Base
{
    public class GroupButton : UserControl, INotifyPropertyChanged
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

        #region IsActive : bool - Состояние кнопки

        /// <summary>Состояние кнопки</summary>
        private bool _IsActive;

        /// <summary>Состояние кнопки</summary>
        public bool IsActive
        {
            get => _IsActive;
            set => SetProperty(ref _IsActive, value);
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

        public static event Action<byte> GroupButtonPressedEvent;

        public ICommand ClickCommand;
        protected virtual bool CanClickCommandExecute(object sender) => true;
        protected virtual void OnClickCommandExecuted(object sender)
        {
            GroupButtonPressedEvent.Invoke(ID);
        }

        public GroupButton(string title, bool isActive, byte id)
        {
            Title = title;
            IsActive = isActive;
            ID = id;
            ClickCommand = new LambdaCommand(
                OnClickCommandExecuted,
                CanClickCommandExecute);
        }
    }
}
