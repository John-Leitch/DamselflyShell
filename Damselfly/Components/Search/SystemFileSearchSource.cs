using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damselfly.Components.Search
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class SystemFileSearchSource : SearchSource
    {
        private readonly string[] _directories = new[]
        {
            @"%SystemRoot%",
            @"%SystemRoot%\system32",
        };

        private readonly string[] _extensions = new[]
        {
            "cpl",
            "msc",
            "exe",
            "cmd",
            "bat",
        };

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        protected override List<SearchItem> LoadItems() =>
            _directories
                .SelectMany(x => _extensions.SelectMany(y => GetDirectoryFiles(x, y)))
                .SelectMany(x => new[]
                {
                    SearchItem.FromFile(x),
                    SearchItem.FromCommand(x)
                })
                .ToList();

        private static IEnumerable<string> GetDirectoryFiles(string directory, string extension) =>
            Directory
                .GetFiles(Environment.ExpandEnvironmentVariables(directory))
                .Where(x => x.EndsWith(
                    "." + extension,
                    StringComparison.InvariantCultureIgnoreCase));
    }
}
