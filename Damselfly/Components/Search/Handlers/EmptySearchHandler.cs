using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damselfly.Components.Search.Handlers
{
    public class EmptySearchHandler : SearchHandler
    {
        public override bool IsHandled(string query)
        {
            return string.IsNullOrEmpty(query);
        }

        public override IEnumerable<SearchItem> Search(string query)
        {
            return _context.AllItems;
        }
    }
}
