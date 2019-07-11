using Components;
using System;
using System.Diagnostics;
using ST = Damselfly.Components.Search.SearchItemType;
using SI = Damselfly.ViewModels.SearchItem;
using static Damselfly.Components.FileSystemCache;
using static System.IO.Path;
using Cache = Damselfly.Components.PathCache;

namespace Damselfly.Components.Search
{
    using SearchMemoizer = ArgLockingMemoizer<string, SI>;
    using StringMemoizer = ArgLockingMemoizer<string, string>;

    public static class SearchItemBuilder
    {
        private static readonly StringMemoizer
            _descriptionCache = Cache.Create<string>();

        private static readonly SearchMemoizer
            _filecache = Cache.Create<SI>(),
            _dirCache = Cache.Create<SI>(),
            _shortcutCache = Cache.Create<SI>(),
            _commandCache = Cache.Create<SI>();

        private static readonly ArgLockingMemoizer<string, SI[]>
            _manyCommandCache = Cache.Create<SI[]>();        

        public static string TryGetDescription(string filename) =>
            _descriptionCache.Call(
                x => FileExists(x) ? FileVersionInfo.GetVersionInfo(x).FileDescription : null,
                filename);

        public static SI FromFile(string filename) =>
            _filecache.Call(
                x => new SI(
                    GetExtension(x)
                        .Equals(".msc", StringComparison.OrdinalIgnoreCase) ?
                            MscHelper.GetName(x) :
                            TryGetDescription(x) ?? x,
                    x,
                    ST.File),
                filename);

        public static SI FromDirectory(string dirName) =>
            _dirCache.Call(x => new SI(GetFileName(x), x, ST.Directory), dirName);

        public static SI FromShortcut(string filename) =>
            _shortcutCache.Call(
                x => new SI(GetFileNameWithoutExtension(x), x, ST.StartMenu),
                filename);

        public static SI FromCommand(string filename) =>
            _commandCache.Call(
                x => 
                    FileExists(x) ?
                        new SI(x, ST.File) :
                    DirectoryExists(x) ?
                        new SI(x, ST.Directory) :
                        new SI(x, null, ST.Command),
                filename);

        public static SI[] ManyFromCommand(string command) =>
            _manyCommandCache.Call(
                x => FileExists(x) ?
                    new[] { FromFile(x), FromCommand(x) } :
                    new[] { FromCommand(x) },
                command);

        
    }
}
