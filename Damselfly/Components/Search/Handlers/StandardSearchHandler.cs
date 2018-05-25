using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damselfly.Components.Search.Handlers
{
    public class StandardSearchHandler : SearchHandler
    {
        public override bool IsHandled(string query)
        {
            return true;
        }

        public override IEnumerable<SearchItem> Search(string query)
        {
            return _context.AllItems.Where(x => x.Name.ToUpper().Contains(query.ToUpper()));
        }
    }
}
