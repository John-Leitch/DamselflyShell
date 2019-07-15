using System;
using System.Windows.Input;

using Components.PInvoke;

using Damselfly.Components.Input.Routing;

using static System.Windows.Input.Key;
using static Components.PInvoke.User32;

namespace Damselfly.Components.Input
{

    public class KeyboardHookController : ISetHotkeyBindingSource, IWinKeySource
    {
        public event EventHandler WinKeyPressed;

        public event EventHandler<GlobalHotkeyEventArgs> GlobalHotkeyPressed;

        public WindowsHookCallback _hookProc;

        private bool
            _isCtrlDown,
            _isWinDown,
            _isRightWin,
            _isWinUnmodified;

        private IntPtr _hookId;

        public void Init()
        {
            _hookProc = WindowsHookCallback;
            _hookId = SetWindowsHookEx(HookType.WH_KEYBOARD_LL, _hookProc, IntPtr.Zero, 0);
        }

        private IntPtr WindowsHookCallback(int code, IntPtr wParam, ref KeyboardHook lParam)
        {
            if (code < 0 || (lParam.flags & LLKHF_INJECTED) == LLKHF_INJECTED)
            {
                return CallNextHookEx(_hookId, code, wParam, ref lParam);
            }

            var keyPressed = KeyInterop.KeyFromVirtualKey(lParam.vkCode);

            if (keyPressed == LeftCtrl || keyPressed == RightCtrl)
            {
                _isCtrlDown = (wParam.ToInt32() & WM_KEYDOWN) == WM_KEYDOWN;

                return CallNextHookEx(_hookId, code, wParam, ref lParam);
            }
            else if (keyPressed == LWin)
            {
                return HandleWinKey(code, wParam, ref lParam, isRightWin: false);
            }
            else if (keyPressed == RWin)
            {
                return HandleWinKey(code, wParam, ref lParam, isRightWin: true);
            }
            else if (_isCtrlDown &&
                _isWinDown &&
                (wParam.ToInt32() & WM_KEYUP) == WM_KEYUP &&
                D0 <= keyPressed &&
                keyPressed <= D9)
            {
                GlobalHotkeyPressed?.Invoke(this, new GlobalHotkeyEventArgs(keyPressed, KeyboardAction.Pressed));                

                return new IntPtr(1);
            }
            else if (_isWinDown)
            {
                SendWinKey(keyPressed);
            }

            return CallNextHookEx(_hookId, code, wParam, ref lParam);
        }

        private void SendWinKey(Key keyPressed)
        {
            if (!_isRightWin)
            {
                KeyboardController.SendKeyDown(LWin);
            }
            else
            {
                KeyboardController.SendKeyDown(RWin);
            }

            _isWinUnmodified = false;

            if (keyPressed == L)
            {
                _isWinDown = false;
            }
        }

        private IntPtr HandleWinKey(int code, IntPtr wParam, ref KeyboardHook lParam, bool isRightWin)
        {
            var i = wParam.ToInt32();

            if (!_isWinDown)
            {
                if ((i & WM_KEYDOWN) == WM_KEYDOWN)
                {
                    _isWinUnmodified = true;
                    _isWinDown = true;
                    _isRightWin = isRightWin;
                }

                return new IntPtr(1);
            }
            else if ((i & WM_KEYUP) == WM_KEYUP)
            {
                _isWinDown = false;

                if (_isWinUnmodified)
                {
                    WinKeyPressed?.Invoke(this, EventArgs.Empty);
                    //ToggleSearchWindow();

                    return new IntPtr(1);
                }

                return CallNextHookEx(_hookId, code, wParam, ref lParam);
            }
            else
            {
                return new IntPtr(1);
            }
        }

        public void Broadcast(IInputSink inputSource) => throw new NotImplementedException();
    }
}
