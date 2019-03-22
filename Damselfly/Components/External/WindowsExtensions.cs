using System;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Components
{
    public static class WindowsExtensions
    {
        public static DispatcherOperation BeginInvoke(this Dispatcher dispatcher, Action action) =>
            dispatcher.BeginInvoke(action);

        public static void Freeze(this Dispatcher dispatcher, Action action) =>
            dispatcher.Invoke(() => dispatcher.DisableProcessing().Using(action));

        public static void Freeze(this DispatcherObject dispatcherObject, Action action) =>
            dispatcherObject.Dispatcher.Freeze(action);

        public static DispatcherOperation BeginFreeze(this Dispatcher dispatcher, Action action) =>
            dispatcher.BeginInvoke(() => dispatcher.DisableProcessing().Using(action));

        public static DispatcherOperation BeginFreeze(this DispatcherObject dispatcherObject, Action action) =>
            dispatcherObject.Dispatcher.BeginFreeze(action);

        public static Task FreezeAsync(this Dispatcher dispatcher, Action action) =>
            dispatcher.BeginInvoke(() => dispatcher.DisableProcessing().Using(action)).Task;

        public static Task FreezeAsync(this DispatcherObject dispatcherObject, Action action) =>
            dispatcherObject.Dispatcher.FreezeAsync(action);

        

    }
}
