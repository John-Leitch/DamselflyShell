using Components.PInvoke;
using System.Windows.Input;

namespace Damselfly.Components
{
    public static class KeyboardController
    {
        private static void SendKey(Key key, int flags)
        {
            User32.keybd_event(
                (byte)KeyInterop.VirtualKeyFromKey(key), 
                0,
                flags, 
                0);
        }

        public static void SendKeyDown(Key key)
        {
            SendKey(key, User32.KEYEVENTF_EXTENDEDKEY);
        }

        public static void SendKeyUp(Key key)
        {
            SendKey(key, User32.KEYEVENTF_EXTENDEDKEY | User32.KEYEVENTF_KEYUP);
        }
    }
}
