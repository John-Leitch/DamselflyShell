using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Damselfly.ViewModels
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        protected void InvokePropertyChanged([CallerMemberName] string callerName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));

        protected void SetProperty<T>(ref T property, T value, [CallerMemberName] string callerName = null)
        {
            property = value;
            InvokePropertyChanged(callerName);
        }

    }
}
