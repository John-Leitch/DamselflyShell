using Components;
using Components.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace Damselfly.Components
{
    public class StartSearch
    {
        private string _cmdFile = PathHelper.GetExecutingPath("commands.json");

        private string _doubleSeparator = new string(Path.DirectorySeparatorChar, 2);

        private UsageDatabase _usageDb = UsageDatabase.Load();

        public UsageDatabase UsageDb
        {
            get { return _usageDb; }
        }

        private List<SearchItem> _startMenuItems = new List<SearchItem>();

        public List<SearchItem> StartMenuItems
        {
            get { return _startMenuItems; }
        }

        private List<SearchItem> _commands = new List<SearchItem>();

        public List<SearchItem> Commands
        {
            get { return _commands; }
        }

        private List<SearchItem> _systemFiles = new List<SearchItem>();

        public List<SearchItem> SystemFiles
        {
            get { return _systemFiles; }
        }

        private List<SearchItem> _specialFolders = new List<SearchItem>();

        public List<SearchItem> SpecialFolders
        {
            get { return _specialFolders; }
        }

        private static IEnumerable<string> GetSystem32Files(string extension)
        {
            return Directory
                .GetFiles(
                    Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32"),
                    "*")
                .Where(x => x.EndsWith("." + extension, StringComparison.InvariantCultureIgnoreCase));
        }

        public void LoadItems()
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

            _specialFolders = specialFolders
                .Select(Environment.GetFolderPath)
                .Concat(new[] { downloads })
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(SearchItem.FromDirectory)
                .ToList();

            _systemFiles = GetSystem32Files("cpl")
                .Select(SearchItem.FromFile)
                .ToList();

            _systemFiles = _systemFiles.Concat(GetSystem32Files("msc")
                .Select(SearchItem.FromFile))
                .ToList();

            _startMenuItems = Directory
                .GetFiles(
                    Environment.ExpandEnvironmentVariables(@"%ProgramData%\microsoft\windows\Start Menu\Programs"),
                    "*",
                    SearchOption.AllDirectories)
                .Where(x => x.EndsWith(".lnk", StringComparison.InvariantCultureIgnoreCase))
                .Select(SearchItem.FromShortcut)
                .ToList();

            if (File.Exists(_cmdFile))
            {
                _commands.AddRange(
                    JsonSerializer
                        .DeserializeFile<string[]>(_cmdFile)
                        .Distinct()
                        .Select(SearchItem.FromCommand));
            }


        }

        private string CleanPath(string path)
        {
            while (path.Contains(_doubleSeparator))
            {
                path = path.Replace(_doubleSeparator, System.IO.Path.DirectorySeparatorChar.ToString());
            }

            return path;
        }

        private bool IsPathLocalPath(string query)
        {
            return query.Contains(System.IO.Path.DirectorySeparatorChar) && 
                !query.StartsWith(@"\\");
        }

        private IEnumerable<SearchItem> GetAllItems()
        {
            return _startMenuItems.Concat(_systemFiles).Concat(_commands).Concat(_specialFolders);
        }

        private IEnumerable<SearchItem> SearchFileSystem(string path, string query)
        {
            path = CleanPath(path);

            Func<string, bool> pred = x =>
                    query == null || System.IO.Path.GetFileName(x).ToUpper().Contains(query.ToUpper());

            var fsoFuncs = new[]
            {
                new SearchStrategy(SearchItemType.Directory, Directory.GetDirectories),
                new SearchStrategy(SearchItemType.File, Directory.GetFiles),
                
            };

            var items = fsoFuncs
                .SelectMany(f =>
                {
                    try
                    {
                        return f
                            .GetItems(path)
                            .Where(pred)
                            .Select(x => new SearchItem()
                            {
                                Name = x,
                                ItemPath = x,
                                Type = f.Type,
                                Usage = _usageDb.GetRecord(f.Type, x),
                            });
                    }
                    catch
                    {
                        return new SearchItem[0];
                    }
                })
                .ToArray();

            return items;
        }

        private IEnumerable<SearchItem> SearchFileSystem(string query)
        {
            var separator = Path.DirectorySeparatorChar;
            var parts = query.Split(separator);
            
            var potentialPathQueries = parts.Length > 1 ? 
                new[]
                {
                    new [] { query, null },
                    new [] 
                    { 
                        string.Join(
                            separator.ToString(),
                            parts.Take(parts.Length - 1)) +
                            separator.ToString(), 
                        parts.Last() 
                    }
                } :
                new[] { new[] { query, null } };

            var m = new List<SearchItem>();

            foreach (var p in potentialPathQueries)
            {
                var dir = p[0][p[0].Length - 1] == separator ?
                    p[0] :
                    p[0] + separator;

                dir = p[0];

                if (dir.Last() == Path.DirectorySeparatorChar &&
                    Directory.Exists(dir))
                {
                    m.AddRange(SearchFileSystem(dir, p[1]));

                    break;
                }
            }

            return m;
        }

        public IEnumerable<SearchItem> Search(string query)
        {
            var matches =
                string.IsNullOrEmpty(query) ?
                    GetAllItems() :
                !IsPathLocalPath(query) ?
                    GetAllItems()
                        .Where(x => x.Name.ToUpper().Contains(query.ToUpper())) :
                    SearchFileSystem(query);

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
            JsonSerializer.SerializeToFile(_cmdFile, _commands.Distinct().Select(x => x.Name));
        }

        public StartSearch()
        {
            LoadItems();
        }
    }
}
