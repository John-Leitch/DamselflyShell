using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damselfly.Components.Search
{
    public abstract class SearchSource
    {
        private List<SearchItem> _items;

        public virtual bool IsCommandRepository => false;

        public bool IsLoaded { get; private set; }

        public virtual void Save()
        {
        }

        protected abstract List<SearchItem> LoadItems();

        public List<SearchItem> GetItems()
        {
            lock (this)
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
