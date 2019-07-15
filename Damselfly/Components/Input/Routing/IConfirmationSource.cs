using System;

namespace Damselfly.Components.Input.Routing
{
    public interface IConfirmationSource : IInputSource
    {
        event EventHandler<CancellableEventArgs> GlobalHotkeyPressed;
    }
}
