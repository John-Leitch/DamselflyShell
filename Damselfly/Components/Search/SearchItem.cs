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

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class SearchItem
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        private static readonly Memoizer<(string, string, ST), Img> _imageSourceMemoizer =
            new Memoizer<(string, string, ST), Img>(
                new SelectorComparer<(string, string, ST), (string, string)>(x => (x.Item1, x.Item2)));

        private static readonly SearchMemoizer
            _fromFileMemoizer = new SearchMemoizer(),
            _fromDirectoryMemoizer = new SearchMemoizer(),
            _fromShortcutMemoizer = new SearchMemoizer(),
            _fromCommandMemoizer = new SearchMemoizer();

        private readonly Lazy<Img> _source;

        public Img Source => _source.Value;

        public string Name { get; set; }

        public string ItemPath { get; set; }

        public ST Type { get; set; }

        public UsageRecord Usage { get; set; }

        public SearchItem() => _source = new Lazy<Img>(() => GetIconImageSource((ItemPath, Name, Type)));

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

        public override string ToString() => $"{Type.ToString()}, {Name}, {ItemPath}";

        private static Img GetIconImageSource((string, string, ST) tuple) =>
            _imageSourceMemoizer.Call(GetIconImageSourceCore, (tuple.Item1, tuple.Item2, tuple.Item3));

        private static Img GetIconImageSourceCore((string, string, ST) tuple)
        {
            var (itemPath, name, type) = tuple;

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
                (itemPath != null && File.Exists(itemPath)))
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

        public static SI FromFile(string filename) => _fromFileMemoizer.Call(FromFileCore, filename);

        private static string TryGetDescription(string filename)
        {
            var ver = FileVersionInfo.GetVersionInfo(filename);

            if (ver == null || string.IsNullOrWhiteSpace(ver.FileDescription))
            {
                return null;
            }

            return ver.FileDescription;
        }

        private static SI FromFileCore(string filename) => new SI
        {
            Name = string.Equals(Path.GetExtension(filename), ".msc", StringComparison.OrdinalIgnoreCase) ?
                MscHelper.GetName(filename) :
                TryGetDescription(filename) ?? filename,

            ItemPath = filename,
            Type = ST.File,
            Usage = Instance.GetRecord(ST.File, filename),
        };

        public static SI FromDirectory(string filename) => _fromDirectoryMemoizer.Call(FromDirectoryCore, filename);

        public static SI FromDirectoryCore(string path) => new SI
        {
            Name = Path.GetFileName(path),
            ItemPath = path,
            Type = ST.Directory,
            Usage = Instance.GetRecord(ST.Directory, path),
        };

        public static SI FromShortcut(string filename) => _fromShortcutMemoizer.Call(FromShortcutCore, filename);

        public static SI FromShortcutCore(string shortcutPath) => new SI
        {
            Name = Path.GetFileNameWithoutExtension(shortcutPath),
            ItemPath = shortcutPath,
            Type = ST.StartMenu,
            Usage = Instance.GetRecord(ST.StartMenu, shortcutPath),
        };

        public static SI FromCommand(string filename) => _fromCommandMemoizer.Call(FromCommandCore, filename);

        public static SI FromCommandCore(string command)
        {
            var t = File.Exists(command) ? ST.File :
                Directory.Exists(command) ? ST.Directory :
                ST.Command;

            return new SI
            {
                Name = command,
                ItemPath = t != ST.Command ? command : null,
                Type = t,
                Usage = Instance.GetRecord(t, command),
            };
        }
    }
}
