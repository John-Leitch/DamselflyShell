using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Damselfly.ViewModels;

namespace Damselfly.Components.Search
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class StartMenuSearchSource : SearchSource
    {
        private readonly string[] _directories = new[]
        {
            Environment.GetFolderPath(Environment.SpecialFolder.StartMenu),
            Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu)
        };

        private readonly string[] _extensions = new[]
        {
            "lnk",
            "url",
            "appref-ms"
        };

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        protected override List<SearchItem> LoadItems() =>
            _directories
                .SelectMany(x => Directory.GetFiles(x, "*", SearchOption.AllDirectories))
                .Where(x => _extensions
                    .Any(y => x.EndsWith("." + y, StringComparison.InvariantCultureIgnoreCase)))
                .SelectMany(SearchItemBuilder.FromShortcut)
                .ToList();
    }
}
