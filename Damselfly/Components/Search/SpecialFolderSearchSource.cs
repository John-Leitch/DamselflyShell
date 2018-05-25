﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Damselfly.Components.Search
{
    public class SpecialFolderSearchSource : SearchSource
    {
        protected override List<SearchItem> LoadItems()
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
                Environment.SpecialFolder.Startup,
            };

            var downloads = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "Downloads");

            return specialFolders
                .Select(Environment.GetFolderPath)
                .Concat(new[] { downloads })
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(SearchItem.FromDirectory)
                .ToList();
        }
    }
}