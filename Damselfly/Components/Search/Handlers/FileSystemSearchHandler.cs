using Components;
using Components.IO;
using Damselfly.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Threading;
using static System.IO.Path;

namespace Damselfly.Components.Search.Handlers
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class FileSystemSearchHandler : SearchHandler
    {
        private readonly string _doubleSeparator = new string(DirectorySeparatorChar, 2);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        public override bool IsHandled(string query) =>
            query.Contains(DirectorySeparatorChar); //&&//!query.StartsWith(@"\\");

        public override IEnumerable<SearchItem> Search(string query)
        {
            var separator = DirectorySeparatorChar;
            string[] parts;

            if (!query.StartsWith(_doubleSeparator))
            {
                parts = query.Split(separator);
            }
            else
            {
                parts = query.Substring(2).Split(separator);
                parts[0] = _doubleSeparator + parts[0];
            }

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

            return potentialPathQueries
                .ForceUnbufferedPerProcessorParallelism(1)
                .FirstOrDefault(x =>
                    (x[0][x[0].Length - 1] == DirectorySeparatorChar &&
                    FileSystemCache.DirectoryExists(x[0])) ||
                    IsHost(x[0]))
                .Then(x => x != null ? SearchFileSystem(x[0], x[1]) : Array.Empty<SearchItem>());

            var m = new List<SearchItem>();

            foreach (var p in potentialPathQueries)
            {
                var dir = p[0][p[0].Length - 1] == separator ?
                    p[0] :
                    p[0] + separator.ToString();

                dir = p[0];

                if ((dir.Last() == DirectorySeparatorChar && Directory.Exists(dir)) ||
                    IsHost(dir))
                {
                    m.AddRange(SearchFileSystem(dir, p[1]));

                    break;
                }
            }

            return m;
        }

        private SearchItem[] RecursiveSearch(string path, string query, int max, Func<string, string, IEnumerable<string>> searchFiles, Func<string, string, IEnumerable<string>> searchDirs)
        {
            var search = new Queue<string>();
            search.Enqueue(path);
            var nm = max;
            var all = new SearchItem[0];
            
            DateTime lastUpdate = default;

            while (search.Count > 0)
            {
                var curPath = search.Dequeue();

                if (DateTime.Now - lastUpdate > TimeSpan.FromMilliseconds(10))
                {
                    Dispatcher.CurrentDispatcher.Invoke(() => SearchViewModel.Current.Status = $"{all.Length} matches, searching \"{curPath.Substring(path.Length).TrimStart('\\')}\"");
                    lastUpdate = DateTime.Now;
                }

                Console.WriteLine("Searching {0} -> {1}", query, curPath);
                var isDir = false;
                var isFirst = true;

                foreach (var f in new Func<(SearchItemType, string[])>[]
                {
                    () => (SearchItemType.File, searchFiles(curPath, query).Take(max).ToArray()),
                    () => (SearchItemType.Directory, searchDirs(curPath, query).Take(max).ToArray()),
                })
                {
                    (SearchItemType, string[]) cur = default;
                    var success = false;
                    try
                    {
                        cur = f();
                        success = true;
                    }
                    catch
                    {
                        
                    }

                    if (!success)
                    {
                        continue;
                    }

                    max -= cur.Item2.Length;
                    
                    all = all
                        .Concat(cur.Item2
                            .Select(x => new SearchItem
                            {
                                Name = x,
                                ItemPath = x,
                                Type = cur.Item1,
                                Usage = _context.UsageDb.GetRecord(cur.Item1, x)
                            }))
                        .ToArray();

                    if (max == 0)
                    {
                        return all;
                    }

                    if (isDir)
                    {
                        try
                        {
                            foreach (var p in Directory.EnumerateDirectories(curPath))
                            {
                                search.Enqueue(p);
                            }
                        }
                        catch
                        {

                        }
                    }

                    isDir = true;
                }
            }

            return all;
        }

        private IEnumerable<SearchItem> SearchFileSystem(string path, string query)
        {
            path = CleanPath(path);

            if (query != null && (query.Contains("*") || (query.StartsWith(":") && query.Length > 1)))
            {
                try
                {
                    if (!FileSystemCache.DirectoryExists(path))
                    {
                        return Array.Empty<SearchItem>();
                    }

                    if (query.StartsWith("*"))
                    {
                        return RecursiveSearch(
                            path,
                            query,
                            20,
                            Directory.EnumerateFiles,
                            Directory.EnumerateDirectories);
                    }
                    else
                    {
                        return RecursiveSearch(
                            path,
                            query,
                            20,
                            (p, q) => Directory.EnumerateFiles(p).Where(x => Regex.IsMatch(x, q.Substring(1), RegexOptions.Compiled)),
                            (p, q) => Directory.EnumerateDirectories(p).Where(x => Regex.IsMatch(x, q.Substring(1), RegexOptions.Compiled)));
                    }

                    //return (query.StartsWith("*") ?


                    //(new[]{
                    //    (SearchItemType.File, Directory.EnumerateFiles(path, query, SearchOption.AllDirectories)),
                    //    (SearchItemType.Directory, Directory.EnumerateDirectories(path, query, SearchOption.AllDirectories)),

                    //}) :
                    //:
                    //return new[]{
                    //    (SearchItemType.File, Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories)),
                    //    (SearchItemType.Directory, Directory.EnumerateDirectories(path, "*", SearchOption.AllDirectories)),

                    //}
                    //    .SelectMany(y => y.Item2
                    //    .Where(x => Regex.IsMatch(x, query.Substring(1), RegexOptions.Compiled))
                    //    .Take(20)
                    //    .Select(x => new SearchItem
                    //    {
                    //        Name = x,
                    //        ItemPath = x,
                    //        Type = y.Item1,
                    //        Usage = _context.UsageDb.GetRecord(y.Item1, x)
                    //    }))
                    //    .ToArray();
                }
                catch (Exception e)
                {
                    Trace.TraceError(e.ToString());

                    return Array.Empty<SearchItem>();
                }
            }

            bool pred(string x) =>
                query == null || GetFileName(x).IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0;

            var fsoFuncs = new[]
            {
                new SearchStrategy(SearchItemType.Directory, Directory.GetDirectories),
                new SearchStrategy(SearchItemType.File, Directory.GetFiles),
                new SearchStrategy(SearchItemType.Directory, GetSharePaths)
            };

            return fsoFuncs
                .SelectMany(f =>
                {
                    try
                    {
                        return f
                            .GetItems(path)
                            .Where(pred)
                            .Select(x => new SearchItem
                            {
                                Name = x,
                                ItemPath = x,
                                Type = f.Type,
                                Usage = _context.UsageDb.GetRecord(f.Type, x)
                            });
                    }
                    catch (Exception e)
                    {
                        Trace.TraceError(e.ToString());

                        return Array.Empty<SearchItem>();
                    }
                })
                .ToArray();
        }

        private string CleanPath(string path)
        {
            int index;

            while ((index = path.IndexOf(_doubleSeparator, 1)) != -1)
            {
                path = path.Remove(index, 1);
            }

            return path;
        }

        private string[] GetSharePaths(string path)
        {
            if (!IsHost(path))
            {
                return new string[0];
            }

            var p = path.Substring(2).TrimEnd('\\');
            var shares = NetworkShares.GetShares(p);

            return shares.Select(x => Combine(path, x)).ToArray();
        }

        private bool IsHost(string path)
        {
            var p = path.TrimEnd('\\');

            return p.StartsWith(_doubleSeparator) && p.Count(x => x == '\\') == 2;
        }
    }
}
