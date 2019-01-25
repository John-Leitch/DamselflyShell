using System.Diagnostics;

namespace Damselfly.Components
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class UsageRecord
    {
        public int HitCount { get; set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();
    }
}
