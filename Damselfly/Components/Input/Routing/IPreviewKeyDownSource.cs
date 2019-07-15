using System;
using System.Windows.Input;

namespace Damselfly.Components.Input.Routing
{
    public interface IPreviewKeyDownSource : IInputSource
    {
        event KeyEventHandler PreviewKeyDown;
    }
}