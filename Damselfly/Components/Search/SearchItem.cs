using Components;
using Components.External;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Media;

namespace Damselfly.Components.Search
{
    public class SearchItem 
    {
        private static Memoizer<Tuple<string, string>, ImageSource> _imageSourceMemoizer =
            new Memoizer<Tuple<string, string>, ImageSource>();

        public string Name { get; set; }

        public string ItemPath { get; set; }

        public SearchItemType Type { get; set; }

        public UsageRecord Usage { get; set; }

        private Lazy<ImageSource> _source;

        public ImageSource Source => _source.Value;

        public SearchItem()
        {
            _source = new Lazy<ImageSource>(GetIconImageSource);
        }

        private ImageSource GetIconImageSource()
        {
            return _imageSourceMemoizer.Call(
                GetIconImageSourceCore,
                Tuple.Create(ItemPath, Name));
        }

        private ImageSource GetIconImageSourceCore(Tuple<string, string> tuple)
        {
            if (ItemPath != null)
            {
                var p = ItemPath.TrimEnd('\\');
                int count;

                if (p.StartsWith("\\\\") && ((count = p.Count(x => x == '\\')) == 2 || count == 3))
                {
                    return IconLoader.GetSource(IconLoader.GetHandle(".\\"));
                }
            }

            IntPtr h;

            if (Type != SearchItemType.Command ||
                (ItemPath != null && File.Exists(ItemPath)))
            {
                h = IconLoader.GetHandle(ItemPath);
            }
            else
            {
                try
                {
                    var tokens = ArgLexer.Tokenize(WindowsPath.PrepareFilename(Name));

                    h = tokens.Length > 0 ?
                        IconLoader.GetHandle(tokens[0]) :
                        SystemIcons.Application.Handle;
                }
                catch
                {
                    h = SystemIcons.Application.Handle;
                }
            }

            return IconLoader.GetSource(h);
        }

        public override string ToString() => $"{Type}, {Name}, {ItemPath}";

        public static SearchItem FromFile(string filename) => new SearchItem
        {
            Name =
                Path.GetExtension(filename).ToLower() == ".msc" ? MscHelper.GetName(filename) :
                FileVersionInfo.GetVersionInfo(filename).FileDescription ??
                filename,

            ItemPath = filename,
            Type = SearchItemType.File,
            Usage = UsageDatabase.Instance.GetRecord(SearchItemType.File, filename),
        };

        public static SearchItem FromDirectory(string path) => new SearchItem()
        {
            Name = Path.GetFileName(path),
            ItemPath = path,
            Type = SearchItemType.Directory,
            Usage = UsageDatabase.Instance.GetRecord(SearchItemType.Directory, path),
        };

        public static SearchItem FromShortcut(string shortcutPath) => new SearchItem()
        {
            Name = Path.GetFileNameWithoutExtension(shortcutPath),
            ItemPath = shortcutPath,
            Type = SearchItemType.StartMenu,
            Usage = UsageDatabase.Instance.GetRecord(SearchItemType.StartMenu, shortcutPath),
        };

        public static SearchItem FromCommand(string command)
        {
            var t = File.Exists(command) ? SearchItemType.File :
                Directory.Exists(command) ? SearchItemType.Directory :
                SearchItemType.Command;

            return new SearchItem()
            {
                Name = command,
                ItemPath = t != SearchItemType.Command ? command : null,
                Type = t,
                Usage = UsageDatabase.Instance.GetRecord(t, command),
            };
        }

        public string GetCommand()
        {
            switch (Type)
            {
                case SearchItemType.File:
                case SearchItemType.StartMenu:
                case SearchItemType.Directory:
                    return ItemPath;

                default:
                    return Name;
            }
        }
    }
}
