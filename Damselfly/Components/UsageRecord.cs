using System.Diagnostics;
using System.Threading;

namespace Damselfly.Components
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class UsageRecord
    {
        private int _hitCount;

        public int HitCount { get => _hitCount; set => _hitCount = value; }

        public UsageRecord()
        {
        }

        public UsageRecord(int hitCount) => _hitCount = hitCount;        

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        public void IncrementHitCount() => Interlocked.Increment(ref _hitCount);
    }
}
