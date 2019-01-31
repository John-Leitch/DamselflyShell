using Components;
using Components.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    (x[0][x[0].Length - 1] == DirectorySeparatorChar && Directory.Exists(x[0])) ||
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

        private IEnumerable<SearchItem> SearchFileSystem(string path, string query)
        {
            path = CleanPath(path);

            bool pred(string x) =>
                query == null || GetFileName(x).IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0;

            var fsoFuncs = new[]
            {
                new SearchStrategy(SearchItemType.Directory, Directory.GetDirectories),
                new SearchStrategy(SearchItemType.File, Directory.GetFiles),
                new SearchStrategy(SearchItemType.Directory, GetSharePaths),
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
                                Usage = _context.UsageDb.GetRecord(f.Type, x),
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
