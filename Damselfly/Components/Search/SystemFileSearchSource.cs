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
        protected override List<SearchItem> LoadItems()
        {
            return GetSystem32Files("cpl")
                .Concat(GetSystem32Files("msc"))
                .Select(SearchItem.FromFile)
                .ToList();
        }

        private IEnumerable<string> GetSystem32Files(string extension)
        {
            var sysDir = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32");

            return Directory
                .GetFiles(sysDir)
                .Where(x => x.EndsWith(
                    "." + extension,
                    StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
