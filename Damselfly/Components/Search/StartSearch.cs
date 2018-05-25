using Components.Json;
using Damselfly.Components.Search.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Damselfly.Components.Search
{
    public class StartSearch
    {
        private UsageDatabase _usageDb = UsageDatabase.Load();

        public UsageDatabase UsageDb
        {
            get { return _usageDb; }
        }

        private SearchHandler[] _handlers = new SearchHandler[]
        {
            new EmptySearchHandler(),
            new FileSystemSearchHandler(),
            new StandardSearchHandler(),
        };

        private SearchSource
            _startMenuSource = new StartMenuSearchSource(),
            _systemFileSource = new SystemFileSearchSource(),
            _specialFolderSource = new SpecialFolderSearchSource(),
            _commandSource = new CommandSearchSource();

        public List<SearchItem> StartMenuItems
        {
            get { return _startMenuSource.GetItems(); }
        }

        public List<SearchItem> Commands
        {
            get { return _commandSource.GetItems(); }
        }

        public List<SearchItem> SystemFiles
        {
            get { return _systemFileSource.GetItems(); }
        }

        public List<SearchItem> SpecialFolders
        {
            get { return _specialFolderSource.GetItems(); }
        }

        public IEnumerable<SearchItem> AllItems
        {
            get
            {
                return StartMenuItems
                    .Concat(Commands)
                    .Concat(SystemFiles)
                    .Concat(SpecialFolders);
            }
        }

        public StartSearch()
        {
            foreach (var h in _handlers)
            {
                h.Init(this);
            }
        }

        public IEnumerable<SearchItem> Search(string query)
        {
            var handler = _handlers.First(x => x.IsHandled(query));
            var matches = handler.Search(query);

            return matches
                //.Distinct(x => x.Name)
                .OrderByDescending(x => x.Usage.HitCount)
                .ThenBy(x => x.Name)
                .Take(200);
        }

        public void SearchAsync(string query, Action<IEnumerable<SearchItem>> callback)
        {
            ThreadPool.QueueUserWorkItem(x =>
            {
                callback(Search(query));
            });
        }

        public void Save()
        {
            _usageDb.Save();
            _commandSource.Save();
        }
    }
}
