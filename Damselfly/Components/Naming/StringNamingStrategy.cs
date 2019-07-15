using System;
using System.Collections.Generic;
using System.Diagnostics;
using Components;

namespace Damselfly.Components.Naming
{
    public abstract class StringNamingStrategy : ArgLockingMemoizationWrapper<string, IEnumerable<WeightedName>>
    {
        public IEnumerable<WeightedName> Name(string entity)
        {
            //try
            //{
                return CallCore(entity);
            //}
            //catch(Exception e)
            //{
            //    Trace.WriteLine(e);
            //}

            return Array.Empty<WeightedName>();
        }

        //protected virtual IEqualityComparer<T> GetComparer() => StringComparer.OrdinalIgnoreCase;

        protected override IEqualityComparer<string> GetComparer() => StringComparer.OrdinalIgnoreCase;
    }
}

