using Components.Json;
using Damselfly.Components.Search.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Components;
using System.Diagnostics;

namespace Damselfly.Components.Search
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class StartSearch
    {
        public UsageDatabase UsageDb { get; } = UsageDatabase.Load();

        private readonly SearchHandler[] _handlers = new SearchHandler[]
        {
            new EmptySearchHandler(),
            new FileSystemSearchHandler(),
            new StandardSearchHandler(),
        };

        private readonly SearchSource
            _startMenuSource = new StartMenuSearchSource(),
            _systemFileSource = new SystemFileSearchSource(),
            _specialFolderSource = new SpecialFolderSearchSource(),
            _commandSource = new CommandSearchSource();

        public List<SearchItem> StartMenuItems => _startMenuSource.GetItems();
        public List<SearchItem> Commands => _commandSource.GetItems();
        public List<SearchItem> SystemFiles => _systemFileSource.GetItems();
        public List<SearchItem> SpecialFolders => _specialFolderSource.GetItems();

        public IEnumerable<SearchItem> AllItems =>
            StartMenuItems
                .Concat(Commands)
                .Concat(SystemFiles)
                .Concat(SpecialFolders)
                .OrderByDescending(x => x.Usage.HitCount)
                .ThenBy(x => x.Name);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        public StartSearch() => _handlers.Iter(x => x.Init(this));

        public IEnumerable<SearchItem> Search(string query) =>
            _handlers
                .First(x => x.IsHandled(query))
                .Search(query)
                //.Distinct(x => x.Name)
                .OrderByDescending(x => x.Usage.HitCount)
                .ThenBy(x => x.Name)
                .Take(200);

        public void SearchAsync(string query, Action<IEnumerable<SearchItem>> callback) =>
            ThreadPool.QueueUserWorkItem(x => callback(Search(query)));

        public void Save()
        {
            UsageDb.Save();
            _commandSource.Save();
        }
    }
}
