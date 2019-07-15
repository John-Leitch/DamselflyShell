using System;

namespace Damselfly.Components.Input.Routing
{
    public interface ISetGlobalHotkeySource : IInputSource
    {
        event EventHandler<HotkeyBindingEventAgs> SetGlobalHotkeyPressed;
    }
}
