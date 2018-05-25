using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damselfly.Components.Search.Handlers
{
    public class FileSystemSearchHandler : SearchHandler
    {
        private string _doubleSeparator = new string(Path.DirectorySeparatorChar, 2);

        public override bool IsHandled(string query)
        {
            return query.Contains(Path.DirectorySeparatorChar) &&
                !query.StartsWith(@"\\");
        }

        public override IEnumerable<SearchItem> Search(string query)
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

        private IEnumerable<SearchItem> SearchFileSystem(string path, string query)
        {
            path = CleanPath(path);

            Func<string, bool> pred = x =>
                    query == null || Path.GetFileName(x).ToUpper().Contains(query.ToUpper());

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
                                Usage = _context.UsageDb.GetRecord(f.Type, x),
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

        private string CleanPath(string path)
        {
            while (path.Contains(_doubleSeparator))
            {
                path = path.Replace(_doubleSeparator, Path.DirectorySeparatorChar.ToString());
            }

            return path;
        }
    }
}
