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
        protected override List<SearchItem> LoadItems()
        {
            return Directory
                .GetFiles(
                    Environment.ExpandEnvironmentVariables(@"%ProgramData%\microsoft\windows\Start Menu\Programs"),
                    "*",
                    SearchOption.AllDirectories)
                .Where(x => x.EndsWith(".lnk", StringComparison.InvariantCultureIgnoreCase))
                .Select(SearchItem.FromShortcut)
                .ToList();
        }
    }
}
