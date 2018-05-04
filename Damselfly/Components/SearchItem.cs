using Components;
using System;
using System.Drawing;
using System.Windows.Media;

namespace Damselfly.Components
{
    public class SearchItem
    {
        public string Name { get; set; }

        public string Path { get; set; }

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

            if (Type != SearchItemType.Command)
            {
                h = IconLoader.GetHandle(Path);
            }
            else
            {
                try
                {
                    var tokens = ArgLexer.Tokenize(Name);

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
            return string.Format("{0}, {1}, {2}", Type, Name, Path);
        }
    }
}
