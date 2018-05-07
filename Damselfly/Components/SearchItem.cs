using Components;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Media;

namespace Damselfly.Components
{
    public class SearchItem
    {
        public string Name { get; set; }

        public string ItemPath { get; set; }

        public SearchItemType Type { get; set; }

        public UsageRecord Usage { get; set; }

        private Lazy<ImageSource> _source;

        public ImageSource Source
        {
            get { return _source.Value; }
        }

        public SearchItem()
        {
            _source = new Lazy<ImageSource>(GetIconImageSource);
        }

        private ImageSource GetIconImageSource()
        {
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

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", Type, Name, ItemPath);
        }

        public static SearchItem FromFile(string filename)
        {
            return new SearchItem
            {
                Name =
                    Path.GetExtension(filename).ToLower() == ".msc" ? MscHelper.GetName(filename) :
                    FileVersionInfo.GetVersionInfo(filename).FileDescription ??
                    filename,

                ItemPath = filename,
                Type = SearchItemType.File,
                Usage = UsageDatabase.Instance.GetRecord(SearchItemType.File, filename),
            };
        }

        public static SearchItem FromDirectory(string path)
        {
            return new SearchItem()
            {
                Name = Path.GetFileName(path),
                ItemPath = path,
                Type = SearchItemType.Directory,
                Usage = UsageDatabase.Instance.GetRecord(SearchItemType.Directory, path),
            };
        }

        public static SearchItem FromShortcut(string shortcutPath)
        {
            var n = Path.GetFileNameWithoutExtension(shortcutPath);

            return new SearchItem()
            {
                Name = n,
                ItemPath = shortcutPath,
                Type = SearchItemType.StartMenu,
                Usage = UsageDatabase.Instance.GetRecord(SearchItemType.StartMenu, shortcutPath),
            };
        }

        public static SearchItem FromCommand(string command)
        {
            return new SearchItem()
            {
                Name = command,
                ItemPath = command != null && File.Exists(command) ? command : null,
                Type = SearchItemType.Command,
                Usage = UsageDatabase.Instance.GetRecord(SearchItemType.Command, command),
            };
        }
    }
}
