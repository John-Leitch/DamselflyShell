using Components;
using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Threading;
using Img = System.Windows.Media.ImageSource;
using ST = Damselfly.Components.Search.SearchItemType;
using System.Drawing;
using System.Diagnostics;
using static Damselfly.Components.IconLoader;
using static System.Drawing.SystemIcons;

namespace Damselfly.Components.Search
{
    public static class ImageSourceBackgroundWorker
    {
        private static Stack<((string, string, ST), Action<Img>)> _imgQueue = new Stack<((string, string, ST), Action<Img>)>();

        private static Lazy<Dispatcher> _dispatcher =
            new Lazy<Dispatcher>(() => AutoSingleton.Get<SearchWindow>().Dispatcher);

        private static readonly Thread[] _imgThreads = Enumerable
            .Range(0, 4)
            .Select(_ =>
                new Thread(
                    () =>
                    {
                        while (true)
                        {
                            (string, string, ST) imgTup = default;
                            Action<Img> callback = null;

                            lock (_imgQueue)
                            {
                                if (_imgQueue.Count != 0)
                                {
                                    (imgTup, callback) = _imgQueue.Pop();
                                }
                            }

                            if (callback == null)
                            {
                                Thread.Sleep(1);
                                continue;
                            }

                            try
                            {
                                var img = LoadSource(imgTup);
                                _dispatcher.Value.BeginInvoke(() => callback(img));
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(string.Format("IconLoader error: {0}", e));
                                var errImg = LoadSource(Error.Handle);
                                _dispatcher.Value.BeginInvoke(() => callback(errImg));
                            }

                        }
                    })
                    .Do(x => x.IsBackground = true)
                    .Do(x => x.Start()))
                    .ToArray();

        public static void LoadAsync(string itemPath, string name, ST type, Action<Img> callback)
        {
            callback(DefaultImage.Value);

            if ((type == ST.Command && name == null) ||
                (type != ST.Command && itemPath == null))
            {
                return;
            }

            lock (_imgQueue)
            {
                var tup = (itemPath, name, type);

                if (!_imgQueue.Any(x => x.Item1 == tup))
                {
                    _imgQueue.Push((tup, callback));
                }
            }
        }
    }
}
