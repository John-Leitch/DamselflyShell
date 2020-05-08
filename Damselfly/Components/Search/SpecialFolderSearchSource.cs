using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Damselfly.ViewModels;

namespace Damselfly.Components.Search
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class SpecialFolderSearchSource : SearchSource
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        protected override ConcurrentBag<SearchItem> LoadItems()
        {
            var specialFolders = new Environment.SpecialFolder[]
            {
                Environment.SpecialFolder.AdminTools,
                Environment.SpecialFolder.Desktop,
                Environment.SpecialFolder.Favorites,
                Environment.SpecialFolder.MyComputer,
                Environment.SpecialFolder.MyDocuments,
                Environment.SpecialFolder.MyMusic,
                Environment.SpecialFolder.MyPictures,
                Environment.SpecialFolder.MyVideos,
                Environment.SpecialFolder.NetworkShortcuts,
                Environment.SpecialFolder.PrinterShortcuts,
                Environment.SpecialFolder.Programs,
                Environment.SpecialFolder.StartMenu,
                Environment.SpecialFolder.Startup
            };

            var downloads = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "Downloads");

            return new ConcurrentBag<SearchItem>(
                specialFolders
                    .Select(Environment.GetFolderPath)
                    .Concat(new[] { downloads })
                    .Where(x => !string.IsNullOrEmpty(x))
                    .SelectMany(SearchItemBuilder.FromDirectory));
        }
    }
}
