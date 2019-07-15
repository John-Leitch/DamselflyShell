using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Damselfly.Components.Input.Routing
{
    public interface IInputHub
    {
        Dictionary<IInputSink, Type> Sinks { get; }

        Dictionary<IInputSource, Type> Sources { get; }

        void Register(IInputObject inputObj);
    }    
}