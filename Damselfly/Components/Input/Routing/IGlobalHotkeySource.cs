using System;

namespace Damselfly.Components.Input.Routing
{
    public interface IGlobalHotkeySource : IInputSource
    {
        event EventHandler<GlobalHotkeyEventArgs> GlobalHotkeyPressed;
    }
}
