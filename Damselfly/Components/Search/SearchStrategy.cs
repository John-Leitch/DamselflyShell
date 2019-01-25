using System;
using System.Diagnostics;

namespace Damselfly.Components.Search
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class SearchStrategy
    {
        public SearchItemType Type { get; set; }

        public Func<string, string[]> GetItems { get; set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        public SearchStrategy(SearchItemType type, Func<string, string[]> getItems)
        {
            Type = type;
            GetItems = getItems;
        }
    }
}
