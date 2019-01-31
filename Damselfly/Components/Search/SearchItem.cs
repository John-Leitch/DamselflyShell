using Components;
using Components.External;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Media;
using ST = Damselfly.Components.Search.SearchItemType;
using SI = Damselfly.Components.Search.SearchItem;
using Img = System.Windows.Media.ImageSource;
using static Damselfly.Components.IconLoader;
using static Damselfly.Components.UsageDatabase;

namespace Damselfly.Components.Search
{
    using SearchMemoizer = ArgLockingMemoizer<string, SI>;
    using StringMemoizer = ArgLockingMemoizer<string, string>;

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class SearchItem
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        private static readonly Memoizer<(string, string, ST), Img> _imageSourceMemoizer =
            new Memoizer<(string, string, ST), Img>(
                new SelectorComparer<(string, string, ST), (string, string)>(x => (x.Item1, x.Item2)));

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

        private readonly Lazy<Img> _source;

        public Img Source => _source.Value;

        public string Name { get; set; }

        public string ItemPath { get; set; }

        public ST Type { get; set; }

        public UsageRecord Usage { get; set; }

        public SearchItem() => _source = new Lazy<Img>(() => GetIconImageSource((ItemPath, Name, Type)));

        public static Img GetIconImageSource((string, string, ST) tuple2)
        {
            Img GetIconImageSourceCore((string, string, ST) tupleInner)
            {
                var (itemPath, name, type) = tupleInner;

                if (itemPath != null)
                {
                    var p = itemPath.TrimEnd('\\');
                    int count;

                    if (p.StartsWith("\\\\") && ((count = p.Count(x => x == '\\')) == 2 || count == 3))
                    {
                        return GetSource(GetHandle(".\\"));
                    }
                }

                IntPtr h;

                if (type != ST.Command ||
                    (itemPath != null && FileExists(itemPath)))
                {
                    h = GetHandle(itemPath);
                }
                else
                {
                    try
                    {
                        var tokens = ArgLexer.Tokenize(WindowsPath.PrepareFilename(name));

                        h = tokens.Length > 0 ?
                            GetHandle(tokens[0]) :
                            SystemIcons.Application.Handle;
                    }
                    catch (Exception e)
                    {
                        Trace.TraceError(e.ToString());
                        h = SystemIcons.Application.Handle;
                    }
                }

                return GetSource(h);
            }

            return _imageSourceMemoizer.Call(GetIconImageSourceCore, (tuple2.Item1, tuple2.Item2, tuple2.Item3));
        }

        public static string TryGetDescription(string filename)
        {
            string TryGetDescriptionCore(string filenameInner)
            {
                var ver = FileVersionInfo.GetVersionInfo(filenameInner);

                if (ver == null || string.IsNullOrWhiteSpace(ver.FileDescription))
                {
                    return null;
                }

                return ver.FileDescription;
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
                Usage = Instance.GetRecord(ST.File, filename),
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
                Usage = Instance.GetRecord(ST.Directory, path),
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
                Usage = Instance.GetRecord(ST.StartMenu, shortcutPath),
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
                    Usage = Instance.GetRecord(t, commandInner),
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
