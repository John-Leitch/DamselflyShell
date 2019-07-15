using System;
using System.Windows.Input;

namespace Damselfly.Components.Input
{
    public class GlobalHotkeyEventArgs : EventArgs
    {
        public Key Key { get; }

        KeyboardAction Action { get; }

        public GlobalHotkeyEventArgs(Key key, KeyboardAction action)
        {
            Key = key;
            Action = action;
        }
    }
}
