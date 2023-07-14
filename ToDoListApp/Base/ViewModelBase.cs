using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ToDoListApp.Base
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged<T>(out T prop, T value, [CallerMemberName] string? propName = null)
        {
            prop = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
