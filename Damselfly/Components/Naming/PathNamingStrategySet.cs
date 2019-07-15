using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Damselfly.Components.Naming
{
    public class PathNamingStrategySet : StringNamingStrategy
    {
        public MscStrategy MscStrategy { get; private set; } = new MscStrategy();

        public FileVersionInfoStrategy FileVersionInfoStrategy { get; private set; } = new FileVersionInfoStrategy();

        public FrequencyStrategy FrequencyStrategy { get; private set; } = new FrequencyStrategy();

        protected override IEnumerable<WeightedName> CallCore(string arg)
        {
            var strategies = WindowsPath.IsValidPath(arg) ?
                new StringNamingStrategy[] { MscStrategy, FileVersionInfoStrategy, FrequencyStrategy, } :
                new StringNamingStrategy[] { FrequencyStrategy, };

            var names = new WeightedName[0];

            foreach (var s in new StringNamingStrategy[]
            {
                MscStrategy,
                FileVersionInfoStrategy,
                FrequencyStrategy,
            })
            {
                try
                {
                    names = names.Concat(s.Call(arg)).ToArray();
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e);
                }
            }
            return names.OrderByDescending(x => x.Weight);
        }

        public string[] GetNames(string name) => Call(name).Select(x => x.Name).ToArray();
            
                //.GroupBy(x => x.Name, StringComparer.OrdinalIgnoreCase)
                //.Select(x => x.First())
                //.Take(names.Count() / 2)
                
            //names.Count();
            //return CallCore(name).OrderByDescending(x => x.Weight).Take(count / 2).Select(x => x.Name).ToArray();
    }
}

