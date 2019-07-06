using Components;
using Components.External;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using ST = Damselfly.Components.Search.SearchItemType;
using SI = Damselfly.Components.Search.SearchItem;
using Img = System.Windows.Media.ImageSource;
using static Damselfly.Components.IconLoader;
using static Damselfly.Components.UsageDatabase;
using Damselfly.ViewModels;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Threading;
using Components.PInvoke;
using System.Runtime.InteropServices;

namespace Damselfly.Components.Search
{
    using SearchMemoizer = ArgLockingMemoizer<string, SI>;
    using StringMemoizer = ArgLockingMemoizer<string, string>;

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class SearchItem : ViewModel
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        private static readonly Memoizer<(string, string, ST), Img> _imageSourceMemoizer =
            new Memoizer<(string, string, ST), Img>(
                new SelectorComparer<(string, string, ST), (string, string)>(x => (x.Item1, x.Item2)));
                //new SelectorComparer<(string, string, ST), (string, string, ST)>(x => (x.Item1, x.Item2, x.Item3)));


        private static readonly SearchMemoizer
            _fromFileMemoizer = new SearchMemoizer(StringComparer.OrdinalIgnoreCase),
            _fromDirectoryMemoizer = new SearchMemoizer(StringComparer.OrdinalIgnoreCase),
            _fromShortcutMemoizer = new SearchMemoizer(StringComparer.OrdinalIgnoreCase),
            _fromCommandMemoizer = new SearchMemoizer(StringComparer.OrdinalIgnoreCase);

        private static readonly StringMemoizer _tryGetDescriptionMemoizer =
            new StringMemoizer(StringComparer.OrdinalIgnoreCase);

        private static readonly ArgLockingMemoizer<string, bool>
            _fileExistsMemoizer = new ArgLockingMemoizer<string, bool>(StringComparer.OrdinalIgnoreCase),
            _directoryExistsMemoizer = new ArgLockingMemoizer<string, bool>(StringComparer.OrdinalIgnoreCase);

        private static Stack<((string, string, ST), Action<Img>)> _imgQueue = new Stack<((string, string, ST), Action<Img>)>();

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

                            var img = GetIconImageSource(imgTup);
                            AutoSingleton.Get<SearchWindow>().Dispatcher.BeginInvoke(() => callback(img));

                        }
                    })
                    .Do(x => x.IsBackground = true)
                    .Do(x => x.Start()))
            .ToArray();

        private Img _searchItemSource;

        public Img SearchItemSource
        {
            get => _searchItemSource ?? DefaultImage.Value;
            set => SetProperty(ref _searchItemSource, value);
        }

        private ST _type;

        public ST Type
        {
            get => _type;
            set
            {
                _type = value;
                QueueLoad();
            }
        }

        private string _itemPath;

        public string ItemPath
        {
            get => _itemPath;
            set
            {
                _itemPath = value;
                QueueLoad();
            }
        }

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                QueueLoad();
            }
        }

        public UsageRecord Usage { get; set; }

        public static Lazy<Img> DefaultImage = new Lazy<Img>(() =>
        {
            Img src = null;
            AutoSingleton.Get<SearchWindow>().Dispatcher.Invoke(() => src = GetSource(SystemIcons.Application.Handle));
            return src;
        });

        private void QueueLoad()
        {
            if ((Type == ST.Command && Name == null) ||
                (Type != ST.Command && ItemPath == null))
            {
                return;
            }

            lock (_imgQueue)
            {
                var tup = (ItemPath, Name, Type);

                if (!_imgQueue.Any(x => x.Item1 == tup))
                {
                    _imgQueue.Push((tup, x => SearchItemSource = x));
                }
            }
        }

        public static IntPtr GetIconHandle((string, string, ST) tupleInner)
        {
            var (itemPath, name, type) = tupleInner;

            if (type == ST.Command)
            {
                itemPath = name;
            }

            if (itemPath != null)
            {
                var p = itemPath.TrimEnd('\\');
                int count;

                if (p.StartsWith("\\\\") && ((count = p.Count(x => x == '\\')) == 2 || count == 3))
                {
                    return GetHandle(".\\");
                }
            }

            IntPtr h;            

            if (itemPath != null && FileExists(itemPath))
            {
                h = GetFileIcon(itemPath);
                //h = Icon.ExtractAssociatedIcon(itemPath).Handle;
            }
            else if (type != ST.Command)
            {
                h = GetHandle(itemPath);
            }
            else
            {
                var tokens = ArgLexer.Tokenize(name);

                if (tokens.Length == 0)
                {
                    h = SystemIcons.Error.Handle;
                }
                else if (FileExists(tokens[0]))
                {
                    h = GetFileIcon(tokens[0]);
                    //h = Icon.ExtractAssociatedIcon(tokens[0]).Handle;
                }
                else
                {
                    var exe = tokens[0];

                    if (exe.StartsWith("\"") && exe.EndsWith("\""))
                    {
                        exe = exe.Substring(1, exe.Length - 2);
                    }

                    var fullpath = WindowsPath.Search(exe);

                    if (fullpath != null && FileExists(fullpath))
                    {
                        h = GetFileIcon(fullpath);
                    }
                    else if (exe != null && FileExists(exe))
                    {
                        h = GetFileIcon(exe);
                    }
                    else
                    {
                        h = SystemIcons.Error.Handle;
                    }
                }
            }

            return h;
        }

        public static Img GetIconImageSource((string, string, ST) tuple2)
        {
            Img GetIconImageSourceCore((string, string, ST) tupleInner)
            {
                return GetSource(GetIconHandle(tupleInner));
            }

            return _imageSourceMemoizer.Call(GetIconImageSourceCore, (tuple2.Item1, tuple2.Item2, tuple2.Item3));
        }

        public static string TryGetDescription(string filename)
        {
            string TryGetDescriptionCore(string filenameInner)
            {
                var ver = FileVersionInfo.GetVersionInfo(filenameInner);

                return ver == null || string.IsNullOrWhiteSpace(ver.FileDescription) ? null : ver.FileDescription;
            }

            return _tryGetDescriptionMemoizer.Call(TryGetDescriptionCore, filename);
        }

        public static SI FromFile(string filenameInner)
        {
            SI FromFileCore(string filename) => new SI
            {
                Name = string.Equals(Path.GetExtension(filename), ".msc", StringComparison.OrdinalIgnoreCase) ?
                MscHelper.GetName(filename) :
                TryGetDescription(filename) ?? filename,

                ItemPath = filename,
                Type = ST.File,
                Usage = Instance.GetRecord(ST.File, filename)
            };

            return _fromFileMemoizer.Call(FromFileCore, filenameInner);
        }

        public static SI FromDirectory(string filenameInner)
        {
            SI FromDirectoryCore(string path) => new SI
            {
                Name = Path.GetFileName(path),
                ItemPath = path,
                Type = ST.Directory,
                Usage = Instance.GetRecord(ST.Directory, path)
            };

            return _fromDirectoryMemoizer.Call(FromDirectoryCore, filenameInner);
        }

        public static SI FromShortcut(string filenameInner)
        {
            SI FromShortcutCore(string shortcutPath) => new SI
            {
                Name = Path.GetFileNameWithoutExtension(shortcutPath),
                ItemPath = shortcutPath,
                Type = ST.StartMenu,
                Usage = Instance.GetRecord(ST.StartMenu, shortcutPath)
            };

            return _fromShortcutMemoizer.Call(FromShortcutCore, filenameInner);
        }

        public static SI FromCommand(string filenameInner)
        {
            SI FromCommandCore(string commandInner)
            {
                var t = FileExists(commandInner) ? ST.File :
                    DirectoryExists(commandInner) ? ST.Directory :
                    ST.Command;

                return new SI
                {
                    Name = commandInner,
                    ItemPath = t != ST.Command ? commandInner : null,
                    Type = t,
                    Usage = Instance.GetRecord(t, commandInner)
                };
            }

            return _fromCommandMemoizer.Call(FromCommandCore, filenameInner);
        }

        public string GetCommand()
        {
            switch (Type)
            {
                case ST.File:
                case ST.StartMenu:
                case ST.Directory:
                    return ItemPath;

                default:
                    return Name;
            }
        }

        private static bool FileExists(string filename) => _fileExistsMemoizer.Call(File.Exists, filename);

        private static bool DirectoryExists(string filename) => _directoryExistsMemoizer.Call(Directory.Exists, filename);

        public override string ToString() => $"{Type.ToString()}, {Name}, {ItemPath}";
    }
}
