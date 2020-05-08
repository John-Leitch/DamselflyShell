using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using Damselfly.ViewModels;

namespace Damselfly.Components.Search
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public abstract class SearchSource
    {
        private ConcurrentBag<SearchItem> _items;

        private readonly object _itemsLock = new object();

        public virtual bool IsCommandRepository => false;

        public bool IsLoaded { get; private set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        public virtual void Save()
        {
        }

        protected abstract ConcurrentBag<SearchItem> LoadItems();

        public ConcurrentBag<SearchItem> GetItems()
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
