using Components;
using Components.PInvoke;
using Damselfly.Components;
using Damselfly.ViewModels;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using static System.Windows.Input.Key;
using static Components.PInvoke.User32;

namespace Damselfly
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public partial class SearchWindow : Window, IAutoSingleton<SearchWindow>
    {
        public WindowsHookCallback _hookProc;

        private bool
            _hasLoaded,
            _isCtrlDown,
            _isWinDown,
            _isRightWin,
            _isWinUnmodified;

        private IntPtr _hookId;

        private bool _searchInitialized;

        public SearchViewModel SearchViewModel { get; private set; }

        public SearchWindow()
        {
            this.Init();
            InitializeComponent();
            
        }

        private void SearchItemListBox_Loaded(object sender, RoutedEventArgs e)
        {
            SearchViewModel = new SearchViewModel(
                this,
                QueryTextBox,
                SearchItemListBox,
                (ScrollViewer)VisualTreeHelper.GetChild(
                    VisualTreeHelper.GetChild(SearchItemListBox, 0),
                    0))
                {
                    StatusFadeIn = ((Storyboard)FindResource("StatusFadeIn")),
                    StatusFadeOut = ((Storyboard)FindResource("StatusFadeOut"))
                };

            SearchViewModel.Init();
            PreviewKeyDown += SearchViewModel.Control_PreviewKeyDown;
            IsVisibleChanged += SearchViewModel.Control_IsVisibleChanged;
            DataContext = SearchViewModel;
        }

        private void SetPosition()
        {
            Top = SystemParameters.PrimaryScreenHeight - Height - 30;
            Left = 0;
        }

        private void Window_GotFocus(object sender, RoutedEventArgs e) => SetPosition();

        private void ShowSearchWindow()
        {
            if (!_hasLoaded)
            {
                Deactivated += (o, e) => Hide();
                SetPosition();
                Show();
                Focus();
            }
            else
            {
                Focus();
                QueryTextBox.Focus();
            }
        }

        private void ToggleSearchWindow()
        {
            if (IsVisible)
            {
                Hide();
            }
            else
            {
                SetPosition();
                Show();
            }
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
                SearchViewModel.HandleGlobalHotkey(keyPressed);

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
                    ToggleSearchWindow();

                    return new IntPtr(1);
                }

                return CallNextHookEx(_hookId, code, wParam, ref lParam);
            }
            else
            {
                return new IntPtr(1);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;

            if (!_hasLoaded)
            {
                Scripts.Init();
                
                _hookProc = WindowsHookCallback;
                _hookId = SetWindowsHookEx(HookType.WH_KEYBOARD_LL, _hookProc, IntPtr.Zero, 0);                
                ShowSearchWindow();
                Hide();
                _hasLoaded = true;
            }
        }
    }
}
