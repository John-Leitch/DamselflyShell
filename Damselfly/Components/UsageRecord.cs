using System.Diagnostics;
using System.Runtime.Serialization;
using System.Threading;

namespace Damselfly.Components
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [DataContract]
    public class UsageRecord
    {
        private int _hitCount;

        [DataMember]
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
