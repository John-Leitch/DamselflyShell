using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damselfly.Components.Search
{
    public class StartMenuSearchSource : SearchSource
    {
        private string[] _directories = new[]
        {
            Environment.GetFolderPath(Environment.SpecialFolder.StartMenu),
            Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu),
        };

        private string[] _extensions = new[]
        {
            "lnk",
            "url",
            "appref-ms",
        };

        protected override List<SearchItem> LoadItems()
        {

            return _directories
                .SelectMany(x => Directory.GetFiles(x, "*", SearchOption.AllDirectories))
                .Where(x => _extensions
                    .Any(y => x.EndsWith("." + y, StringComparison.InvariantCultureIgnoreCase)))
                .Select(SearchItem.FromShortcut)
                .ToList();
        }
    }
}
