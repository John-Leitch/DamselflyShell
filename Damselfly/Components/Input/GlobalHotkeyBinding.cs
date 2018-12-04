using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Damselfly.Components.Input
{
    [Serializable]
    public class GlobalHotkeyBinding
    {
        public string Command { get; set; }

        public Key BoundChar { get; set; }

        public GlobalHotkeyBinding()
        {
        }

        public GlobalHotkeyBinding(Key boundChar)
        {
            BoundChar = boundChar;
        }

        public GlobalHotkeyBinding(string command, Key boundChar)
        {
            Command = command;
            BoundChar = boundChar;
        }
    }
}
