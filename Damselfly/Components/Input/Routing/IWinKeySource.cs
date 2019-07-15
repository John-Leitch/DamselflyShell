using System;

namespace Damselfly.Components.Input.Routing
{
    public interface IWinKeySource : IInputSource
    {
        event EventHandler WinKeyPressed;
    }
}