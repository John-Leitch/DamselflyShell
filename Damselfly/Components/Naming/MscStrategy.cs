using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damselfly.Components.Naming
{
    public class MscStrategy : StringNamingStrategy
    {
        protected override IEnumerable<WeightedName> CallCore(string arg)
        {
            
            if (WindowsPath.IsValidPath(arg) &&
                Path.GetExtension(arg).Equals(".msc", StringComparison.OrdinalIgnoreCase) &&
                FileSystemCache.FileExists(arg))
            {
                var name = MscHelper.GetName(arg);

                if (!string.IsNullOrWhiteSpace(name))
                {
                    yield return new WeightedName(200, name);
                }
            }           
        }
    }
}
