using System.Collections.Generic;
using System.Diagnostics;
using Damselfly.ViewModels;

namespace Damselfly.Components.Search.Handlers
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public abstract class SearchHandler
    {
        protected StartSearch _context;

        public void Init(StartSearch context) => _context = context;

        public abstract bool IsHandled(string query);

        public abstract IEnumerable<SearchItem> Search(string query);
    }
}
