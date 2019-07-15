using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Components;

namespace Damselfly.Components.Naming
{
    public class NamedEntity<T>
    {
        public T Entity { get; set; }

        public IEnumerable<WeightedName> Name(ArgLockingMemoizationWrapper<T, IEnumerable<WeightedName>> strategies)
        {
            var names = strategies.Call(Entity);
            return names.OrderBy(x => x.Weight).TakeLast(names.Count() / 2);
        }
    }
}
