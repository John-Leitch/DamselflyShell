﻿using System.Collections.Generic;
using System.Diagnostics;

namespace Damselfly.Components.Search.Handlers
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public abstract class SearchHandler
    {
        protected StartSearch _context;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        public void Init(StartSearch context) => _context = context;

        public abstract bool IsHandled(string query);

        public abstract IEnumerable<SearchItem> Search(string query);
    }
}
