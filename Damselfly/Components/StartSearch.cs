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
            var specialFolders = (Environment.SpecialFolder[])Enum.GetValues(typeof(Environment.SpecialFolder));

            specialFolders = new Environment.SpecialFolder[]
            {

                  Environment.SpecialFolder.Desktop,
                  Environment.SpecialFolder.Favorites,
                  Environment.SpecialFolder.MyComputer,
                  Environment.SpecialFolder.MyDocuments,
                  Environment.SpecialFolder.MyMusic,
                  Environment.SpecialFolder.MyPictures,
                  Environment.SpecialFolder.MyVideos,
                  Environment.SpecialFolder.NetworkShortcuts,
                  Environment.SpecialFolder.Personal,
            };

            var downloads = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "Downloads");

            _specialFolders = specialFolders
                .Select(Environment.GetFolderPath)
                .Concat(new[] { downloads })
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => new SearchItem()
                {
                    Name = Path.GetFileName(x),
                    Path = x,
                    Type = SearchItemType.Directory,
                    Usage = _usageDb.GetRecord(SearchItemType.Directory, x),
                })
                .ToList();

            _systemFiles = GetSystem32Files("cpl")
                .Select(x => new SearchItem()
                {
                    Name = FileVersionInfo.GetVersionInfo(x).FileDescription ?? x,
                    Path = x,
                    Type = SearchItemType.File,
                    Usage = _usageDb.GetRecord(SearchItemType.File, x),
                })
                .ToList();

            _systemFiles = _systemFiles.Concat(GetSystem32Files("msc")
                .Select(x => new SearchItem()
                {
                    Name = MscHelper.GetName(x) ?? x,
                    Path = x,
                    Type = SearchItemType.File,
                    Usage = _usageDb.GetRecord(SearchItemType.File, x),
                }))
                .ToList();

            _startMenuItems = Directory
                .GetFiles(
                    Environment.ExpandEnvironmentVariables(@"%ProgramData%\microsoft\windows\Start Menu\Programs"),
                    "*",
                    SearchOption.AllDirectories)
                .Where(x => x.EndsWith(".lnk", StringComparison.InvariantCultureIgnoreCase))
                .Select(x =>
                {
                    var n = Path.GetFileNameWithoutExtension(x);

                    return new SearchItem()
                    {
                        Name = n,
                        Path = x,
                        Type = SearchItemType.StartMenu,
                        Usage = _usageDb.GetRecord(SearchItemType.StartMenu, n),
                    };
                })
                .ToList();

            if (File.Exists(_cmdFile))
            {
                _commands.AddRange(
                    JsonSerializer
                        .DeserializeFile<string[]>(_cmdFile)
                        .Distinct()
                        .Select(x => new SearchItem()
                        {
                            Name = x,
                            Type = SearchItemType.Command,
                            Usage = _usageDb.GetRecord(SearchItemType.Command, x),
                        }));
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
                                Path = x,
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
            var m = new List<SearchItem>();

            IEnumerable<SearchItem> pathMatches = null;

            var separator = System.IO.Path.DirectorySeparatorChar;
            var parts = query.Split(separator);

            string[][] potentialPathQueries;

            if (parts.Length > 1)
            {
                potentialPathQueries = new[]
                    {
                        new [] { query, null },
                        new [] 
                        { 
                            string.Join(separator.ToString(), parts.Take(parts.Length - 1)) + separator.ToString(), 
                            parts.Last() 
                        }
                    };
            }
            else
            {
                potentialPathQueries = new[] { new[] { query, null } };
            }

            foreach (var p in potentialPathQueries)
            {
                string dir = p[0][p[0].Length - 1] == separator ? p[0] : p[0] + separator;
                dir = p[0];

                if (dir.Last() == System.IO.Path.DirectorySeparatorChar && Directory.Exists(dir))
                {
                    pathMatches = SearchFileSystem(dir, p[1]);

                    m.AddRange(pathMatches);

                    break;
                }
            }

            return m;
        }

        public IEnumerable<SearchItem> Search(string query)
        {
            IEnumerable<SearchItem> matches;

            if (string.IsNullOrEmpty(query))
            {
                matches = GetAllItems();
            }
            else if (!IsPathLocalPath(query))
            {
                matches = GetAllItems()
                    .Where(x => x.Name.ToUpper().Contains(query.ToUpper()));
            }
            else
            {
                matches = SearchFileSystem(query);
            }

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
