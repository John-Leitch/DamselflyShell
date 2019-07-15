using System;
using System.Collections.Generic;

namespace Damselfly.Components.Naming
{
    public class FileVersionInfoStrategy : StringNamingStrategy
    {
        protected override IEnumerable<WeightedName> CallCore(string arg)
        {
            if (FileSystemCache.FileExists(arg))
            {
                var info = CachedFileVersionInfo.Default.Call(arg);

                if (!string.IsNullOrWhiteSpace(info.FileDescription))
                {
                    yield return new WeightedName(100, info.FileDescription);
                }

                if (!string.IsNullOrEmpty(info.InternalName) &&
                    !string.IsNullOrEmpty(info.OriginalFilename))
                {
                    var diff = StringSimilarity.Calculate(info.InternalName, info.OriginalFilename);

                    if (diff > 8)
                    {
                        yield return new WeightedName(50, info.InternalName);
                    }
                }

                yield return new WeightedName(25, arg);
            }
        }
    }
}
