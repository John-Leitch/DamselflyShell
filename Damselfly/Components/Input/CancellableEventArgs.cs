using System;

namespace Damselfly.Components.Input
{
    public class CancellableEventArgs : EventArgs
    {
        public bool IsCanceled { get; private set; }

        public void Cancel() => IsCanceled = true;
    }
}
