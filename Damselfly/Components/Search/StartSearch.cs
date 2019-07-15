using Damselfly.Components.Search.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Components;
using System.Diagnostics;
using Damselfly.ViewModels;

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
            new StandardSearchHandler()
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
            new Func<List<SearchItem>>[]
            {
                () => StartMenuItems,
                () => Commands,
                () => SystemFiles,
                () => SpecialFolders
            }
                .ForceUnbufferedPerProcessorParallelism()
                .SelectMany(x => x())
                .OrderByDescending(x => x.Usage.HitCount)
                .ThenBy(x => x.Name);
                //.AsSequential();

            //StartMenuItems
            //    .ForceUnbufferedPerProcessorParallelism()
            //    .Concat(Commands.AsParallel())
            //    .Concat(SystemFiles.AsParallel())
            //    .Concat(SpecialFolders.AsParallel())
            //    .OrderByDescending(x => x.Usage.HitCount)
            //    .ThenBy(x => x.Name);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        public StartSearch() => _handlers.Iter(x => x.Init(this));

        public IEnumerable<SearchItem> Search(string query) =>
            _handlers
                .First(x => x.IsHandled(query))
                .Search(query)
                //.Distinct(x => x.Name)
                .OrderByDescending(x => x.Usage.HitCount)
                .ThenByDescending(x =>
                    query.Equals(x.Name, StringComparison.OrdinalIgnoreCase) ||
                    query.Equals(x.ItemPath, StringComparison.OrdinalIgnoreCase))
                .ThenBy(x => x.Name)
                .Distinct(x => x.Name)
                .Take(200);

        public Thread SearchAsync(string query, Action<string, IEnumerable<SearchItem>> callback) =>
            new Thread(x => callback((string)x, Search(Environment.ExpandEnvironmentVariables(query)))).Do(x => x.IsBackground = true).Do(x => x.Start(query));

        public void Save()
        {
            UsageDb.Save();
            _commandSource.Save();
        }
    }
}
