using Components.PInvoke;
using Damselfly.Components;
using System;
using System.Windows;
using System.Windows.Input;

namespace Damselfly
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public WindowsHookCallback _hookProc = null;

        private bool _isCtrlDown = false, _isWinDown = false, _isWinUnmodified = false;

        private IntPtr _hookId;

        private static bool _hasLoaded = false;

        private SearchWindow _searchWindow;

        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
        }

        private void ShowSearchWindow()
        {
            if (_searchWindow == null)
            {
                _searchWindow = new SearchWindow();

                //if (!Debugger.IsAttached)
                //{
                    _searchWindow.Deactivated += (o, e) =>
                    {
                        try
                        {
                            _searchWindow.Hide();
                        }
                        catch { }
                    };
                //}

                _searchWindow.Closed += (o, e) => _searchWindow = null;
                _searchWindow.Show();
                _searchWindow.Focus();
            }
            else
            {
                _searchWindow.Focus();
                _searchWindow.QueryTextBox.Focus();
            }
        }

        private void ToggleSearchWindow()
        {
            if (_searchWindow == null)
            {
                ShowSearchWindow();
            }
            else
            {
                if (_searchWindow.IsVisible)
                {
                    _searchWindow.Hide();
                }
                else
                {
                    _searchWindow.Show();
                }
            }
        }

        private IntPtr WindowsHookCallback(int code, IntPtr wParam, ref KeyboardHook lParam)
        {
            if (code < 0 || (lParam.flags & User32.LLKHF_INJECTED) == User32.LLKHF_INJECTED)
            {
                return User32.CallNextHookEx(_hookId, code, wParam, ref lParam);
            }

            bool isDir(int dir) => (wParam.ToInt32() & dir) == dir;
            bool isDown() => isDir(User32.WM_KEYDOWN);
            bool isUp() => isDir(User32.WM_KEYUP);

            var keyPressed = KeyInterop.KeyFromVirtualKey(lParam.vkCode);

            if (keyPressed == Key.LeftCtrl || keyPressed == Key.RightCtrl)
            {
                _isCtrlDown = isDown();

                return User32.CallNextHookEx(_hookId, code, wParam, ref lParam);
            }
            else if (keyPressed == Key.LWin || keyPressed == Key.RWin)
            {
                var i = wParam.ToInt32();

                if (!_isWinDown)
                {
                    if ((i & User32.WM_KEYDOWN) == User32.WM_KEYDOWN)
                    {
                        _isWinUnmodified = true;
                        _isWinDown = true;
                    }

                    return new IntPtr(1);
                }
                else
                {
                    if ((i & User32.WM_KEYUP) == User32.WM_KEYUP)
                    {
                        _isWinDown = false;

                        if (_isWinUnmodified)
                        {
                            ToggleSearchWindow();
                            //Dispatcher.Invoke(() => ToggleSearchWindow());

                            return new IntPtr(1);
                        }
                        else
                        {
                            return User32.CallNextHookEx(_hookId, code, wParam, ref lParam);
                        }
                    }
                    else
                    {
                        return new IntPtr(1);
                    }
                }
            }
            else if (_isCtrlDown &&
                _isWinDown &&
                isUp() &&
                Key.D0 <= keyPressed && keyPressed <= Key.D9)
            {
                _searchWindow.SearchViewModel.HandleGlobalHotkey(keyPressed);
                _isWinDown = false;
                return new IntPtr(1);
            }
            else
            {
                if (_isWinDown)
                {
                    KeyboardController.SendKeyDown(Key.LWin);
                    _isWinUnmodified = false;

                    if (keyPressed == Key.L)
                    {
                        _isWinDown = false;
                    }
                }
            }

            return User32.CallNextHookEx(_hookId, code, wParam, ref lParam);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Visibility = System.Windows.Visibility.Hidden;
            
            if (!_hasLoaded)
            {
                Scripts.Init();
                _hookProc = WindowsHookCallback;
                _hookId = User32.SetWindowsHookEx(HookType.WH_KEYBOARD_LL, _hookProc, IntPtr.Zero, 0);
                _hasLoaded = true;
                ShowSearchWindow();
                _searchWindow.Hide();
            }
        }
    }
}
