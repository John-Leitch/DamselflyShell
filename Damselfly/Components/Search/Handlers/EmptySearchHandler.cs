using System.Collections.Generic;
using System.Diagnostics;

namespace Damselfly.Components.Search.Handlers
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class EmptySearchHandler : SearchHandler
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        public override bool IsHandled(string query) => string.IsNullOrEmpty(query);
        public override IEnumerable<SearchItem> Search(string query) => _context.AllItems;
    }
}
