using System.Windows.Input;

namespace Damselfly.Components.Input
{
    public class HotkeyBindingEventAgs : CancellableEventArgs
    {
        public Key Key { get; }

        public string Binding { get; }

        public HotkeyBindingEventAgs(Key key, string binding)
        {
            Key = key;
            Binding = binding;
        }
    }
}
