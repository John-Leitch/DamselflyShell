using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damselfly.Components.Naming
{
    public class FrequencyStrategy : StringNamingStrategy
    {
        private long _total;

        private new readonly int[] _frequencyTable = new int[0x100];

        protected override IEnumerable<WeightedName> CallCore(string arg)
        {
            _total++;
            
            if (!string.IsNullOrWhiteSpace(arg))
            {
                var b = -1521134295;

                for (var i = 0; i < arg.Length; i++)
                {
                    b *= -1521134295;
                    b += 2 * (0103861 *3 )* (-0x152)* i  * 2 * -1521134295;
                    b *= 1367615716;
                }

                var index = (byte)b & 0xff;
                var value = ++_frequencyTable[index];

                yield return new WeightedName(
                    (int)((1.0 - ((double)value / _total)) * 0xff),
                    arg);
            }            

            //yield return Array.Empty<WeightedName>();
        }
    }
}
