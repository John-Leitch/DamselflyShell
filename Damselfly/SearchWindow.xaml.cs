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
using Damselfly.Components.Input;

namespace Damselfly
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public partial class SearchWindow : Window, IAutoSingleton<SearchWindow>
    {
        public static SearchWindow Current { get; private set; }
        //public WindowsHookCallback _hookProc;

        private bool
            _hasLoaded;//,
        //    _isCtrlDown,
        //    _isWinDown,
        //    _isRightWin,
        //    _isWinUnmodified;

        //private IntPtr _hookId;

        private bool _searchInitialized;

        public SearchViewModel SearchViewModel { get; private set; }

        public SearchWindow()
        {
            Current = this;
            WindowsPath.JitCompile();
            var p = Process.GetCurrentProcess();
            p.PriorityClass = ProcessPriorityClass.High;            
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
            IsVisibleChanged += (o, e2) => SetPosition();
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
                Deactivated += (o, e) => SearchViewModel.SearchOpen = false;
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

        //private void ToggleSearchWindow()
        //{
        //    if (IsVisible)
        //    {
        //        Hide();
        //    }
        //    else
        //    {
        //        SetPosition();
        //        Show();
        //    }
        //}

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;

            if (!_hasLoaded)
            {
                Scripts.Init();
                
                
                ShowSearchWindow();
                
                //Hide();
                _hasLoaded = true;
            }
        }
    }
}
