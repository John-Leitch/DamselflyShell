using Components;
using Components.External;
using System;
using System.Diagnostics;
using ST = Damselfly.Components.Search.SearchItemType;
using SI = Damselfly.ViewModels.SearchItem;
using static Damselfly.Components.FileSystemCache;
using static System.IO.Path;
using Cache = Damselfly.Components.PathCache;
using Damselfly.Components.Naming;
using System.Linq;

namespace Damselfly.Components.Search
{
    using SearchMemoizer = ArgLockingMemoizer<string, SI[]>;
    using StringMemoizer = ArgLockingMemoizer<string, string>;

    public static class SearchItemBuilder
    {
        private static PathNamingStrategySet _entitName = new PathNamingStrategySet();

        private static readonly StringMemoizer
            _descriptionCache = Cache.Create<string>();

        private static readonly SearchMemoizer
            
            _commandCache = Cache.Create<SI[]>();

        private static readonly ArgLockingMemoizer<string, SI[]>
            _filecache = Cache.Create<SI[]>(),
            _dirCache = Cache.Create<SI[]>(),
            _shortcutCache = Cache.Create<SI[]>(),
            _manyCommandCache = Cache.Create<SI[]>();        

        public static string TryGetDescription(string filename) =>
            _descriptionCache.Call(
                x => FileExists(x) ? FileVersionInfo.GetVersionInfo(x).FileDescription : null,
                filename);

        public static SI[] FromFile(string filename) =>
            _filecache.Call(
                x => _entitName.GetNames(x).Select(y => new SI(y, x, ST.File)).ToArray(),
                filename);

        public static SI[] FromDirectory(string dirName) =>
            _dirCache.Call(
            //    x => _entitName.GetNames(x).Select(y => new SI(y, x, ST.Directory)).ToArray(),
            //    dirName);
                x => new[] { new SI(x, x, ST.Directory) },
                dirName);

        public static SI[] FromShortcut(string filename) =>
            _shortcutCache.Call(
                x => new[] { new SI(GetFileNameWithoutExtension(x), x, ST.StartMenu) },
                filename);

        public static SI[] FromCommand(string filename) =>
            _commandCache.Call(
                x => _entitName
                .GetNames(x)
                .Select(y =>
                    FileExists(y) ?
                        new SI(y, ST.File) :
                    DirectoryExists(x) ?
                        new SI(y, ST.Directory) :
                        new SI(x, y, ST.Command))
                .ToArray(),
                filename);

        public static SI[] ManyFromCommand(string command) =>
            _manyCommandCache.Call(
                x => FileExists(x) ?
                    new[] { FromFile(x), FromCommand(x) }.Join().ToArray() :
                    FromCommand(x),
                command);

        
    }
}
