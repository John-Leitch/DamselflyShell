using System;

namespace Damselfly.Components
{
    public class SearchStrategy
    {
        public SearchItemType Type { get; set; }

        public Func<string, string[]> GetItems { get; set; }

        public SearchStrategy(SearchItemType type, Func<string, string[]> getItems)
        {
            Type = type;
            GetItems = getItems;
        }
    }
}
