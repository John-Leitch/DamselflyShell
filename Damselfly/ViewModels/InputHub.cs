using System;
using System.Collections.Generic;
using System.Linq;
using Damselfly.Components.Input.Routing;

namespace Damselfly.ViewModels
{
    public class InputHub : IInputHub
    {
        public Dictionary<Type, IInputSink> Sinks { get; }

        public Dictionary<Type, IInputSource> Sources { get; }
        Dictionary<IInputSink, Type> IInputHub.Sinks { get; }
        Dictionary<IInputSource, Type> IInputHub.Sources { get; }

        public void Register(IInputObject inputObj)
        {
            if (inputObj is IInputSource source)
            {
                foreach (var t in source
                    .GetType()
                    .GetInterfaces()
                    .Where(x =>
                        x != typeof(IInputSink) &&
                        x.IsAssignableFrom(typeof(IInputSink))))
                {
                    Sources.Add(t, source);
                }
            }

            if (inputObj is IInputSink sink)
            {
                foreach (var t in sink
                    .GetType()
                    .GetInterfaces()
                    .Where(x =>
                        x.IsConstructedGenericType &&
                        x.GetGenericTypeDefinition() == typeof(IInputSink))
                    .Select(x => x.GetGenericArguments().Single()))
                {
                    if (Sinks.ContainsKey(t))
                    {

                    }

                    Sinks.Add(t, sink);


                }
            }


;        }

        //public void Discover(object root)
        //{
        //    var fields = root
        //        .GetType()
        //        .GetMembers(
        //            BindingFlags.NonPublic |
        //            BindingFlags.Public |
        //            BindingFlags.Instance |
        //            BindingFlags.Static);
        //}
    }
}
