using System.Collections.Generic;
using System.Diagnostics;

namespace Damselfly.Components.Search
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public abstract class SearchSource
    {
        private List<SearchItem> _items;

        private readonly object _itemsLock = new object();

        public virtual bool IsCommandRepository => false;

        public bool IsLoaded { get; private set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        public virtual void Save()
        {
        }

        protected abstract List<SearchItem> LoadItems();

        public List<SearchItem> GetItems()
        {
            lock (_itemsLock)
            {
                if (!IsLoaded)
                {
                    _items = LoadItems();
                }

                IsLoaded = true;
            }

            return _items;
        }
    }
}
