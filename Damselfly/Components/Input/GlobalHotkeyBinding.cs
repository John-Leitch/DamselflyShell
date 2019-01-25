using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Damselfly.Components.Input
{
    [Serializable]
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class GlobalHotkeyBinding
    {
        public string Command { get; set; }

        public Key BoundChar { get; set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => ToString();

        public GlobalHotkeyBinding()
        {
        }

        public GlobalHotkeyBinding(Key boundChar) => BoundChar = boundChar;

        public GlobalHotkeyBinding(string command, Key boundChar)
        {
            Command = command;
            BoundChar = boundChar;
        }
    }
}
