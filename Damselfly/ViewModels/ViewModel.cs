﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Damselfly.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void InvokePropertyChanged([CallerMemberName] string callerName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(callerName));
            }
        }

        protected void SetProperty<T>(ref T property, T value, [CallerMemberName] string callerName = null)
        {
            property = value;
            InvokePropertyChanged(callerName);
        }

    }
}
