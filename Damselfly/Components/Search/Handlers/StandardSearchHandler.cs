using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damselfly.Components.Search.Handlers
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class StandardSearchHandler : SearchHandler
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        public override bool IsHandled(string query) => true;

        public override IEnumerable<SearchItem> Search(string query) =>
            _context.AllItems.Where(x => x.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0);
    }
}
