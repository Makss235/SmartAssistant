using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace SmartAssistant.UserControls.Base
{
    public class Tab : UserControl, INotifyPropertyChanged
    {
        #region ID : byte - Идентификатор вкладки

        /// <summary>Идентификатор вкладки</summary>
        private byte _ID;

        /// <summary>Идентификатор вкладки</summary>
        public byte ID
        {
            get => _ID;
            set => SetProperty(ref _ID, value);
        }

        #endregion

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
    }
}
