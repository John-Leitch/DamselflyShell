using System.Diagnostics;
using Components;

namespace Damselfly.Components.Naming
{
    public class CachedFileVersionInfo : PathCachingWrapper<FileVersionInfo>
    {
        public static CachedFileVersionInfo Default = new CachedFileVersionInfo();

        protected override FileVersionInfo CallCore(string arg) =>
            FileVersionInfo.GetVersionInfo(arg);
    }
}
