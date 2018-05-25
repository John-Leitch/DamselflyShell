using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damselfly.Components.Search
{
    public class SystemFileSearchSource : SearchSource
    {
        private string[] _directories = new[]
        {
            @"%SystemRoot%",
            @"%SystemRoot%\system32",
        };

        private string[] _extensions = new[]
        {
            "cpl",
            "msc",
            "exe",
            "cmd",
            "bat",
        };

        protected override List<SearchItem> LoadItems()
        {
            return _directories
                .SelectMany(x => _extensions.SelectMany(y => GetDirectoryFiles(x, y)))
                .SelectMany(x => new[]
                {
                    SearchItem.FromFile(x),
                    SearchItem.FromCommand(x)
                })
                .ToList();
        }

        private IEnumerable<string> GetDirectoryFiles(string directory, string extension)
        {
            var expanded = Environment.ExpandEnvironmentVariables(directory);

            return Directory
                .GetFiles(expanded)
                .Where(x => x.EndsWith(
                    "." + extension,
                    StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
