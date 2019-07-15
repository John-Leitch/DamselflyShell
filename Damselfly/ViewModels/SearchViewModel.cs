using System.Reflection;

using Components;
using Components.PInvoke;
using Damselfly.Components;
using Damselfly.Components.Input;
using Damselfly.Components.Search;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using static System.Console;
using static Components.PInvoke.User32;
using static Components.PInvoke.Win32;
using System.Threading;
using Damselfly.Components.Input.Routing;

namespace Damselfly.ViewModels
{

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public partial class SearchViewModel //: IPreviewKeyDownSource, IInputSink<IConfirmationSource>, IInputSink<IWinKeySource>
    {
        public InputHub InputHub { get; }

        //public event KeyEventHandler PreviewKeyDown
        //{
        //    add { QueryTextBox.PreviewKeyDown += value; }
        //    remove { QueryTextBox.PreviewKeyDown -= value; }
        //}

        public static SearchViewModel Current;

        private readonly ListBox _queryListBox;

        private readonly ScrollViewer _queryScrollViewer;

        private readonly double _widthDelta, _minWidth, _maxWidth;

        private readonly object _nextQuerySync = new object();
        
        private double _lastWidth = -1;

        private Thread st = null;

        public KeyboardController Keyboard { get; } = new KeyboardController();

        public KeyboardHookController Hooks { get; } = new KeyboardHookController();

        public GlobalHotkeyController Hotkeys { get; } = new GlobalHotkeyController();

        public SearchViewModel(
            SearchWindow window,
            TextBox queryTextBox,
            ListBox queryListBox,
            ScrollViewer queryScrollViewer)
        {
            //InputHub = new InputHub();
            //InputHub.Register(this);
            //new IInputSource[]
            //{
            //    this,
            //    HookController,
            //    HotkeyController,
            //    HotkeyController
            //}
            //    .Iter(InputHub.Register);


            
            Current = this;
            Search = new StartSearch();
            Window = window;
            QueryTextBox = queryTextBox;            
            _queryListBox = queryListBox;
            _queryScrollViewer = queryScrollViewer;            
            _maxWidth = SystemParameters.PrimaryScreenWidth;
            _minWidth = window.ActualWidth;
            _widthDelta = window.ActualWidth - _queryScrollViewer.ActualWidth;

            _queryScrollViewer.ScrollChanged += QueryScrollViewer_ScrollChanged;
            //QueryTextBox.PreviewKeyDown += Control_PreviewKeyDown;
            Hooks.GlobalHotkeyPressed += (o, e) => Hotkeys.HandleGlobalHotkey(e.Key); ;
            Hooks.WinKeyPressed += (o, e) => SearchOpen = !SearchOpen;            
            Hooks.Init();
            
            Hotkeys.OverwritingKeyBinding += OverwritingKeyBinding;
            
        }

        private void QueryScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e) => UpdateWindowSize();

        public void Init()
        {
            if (Matches  == null)
            {
                Matches = new ObservableCollection<SearchItem>();
            }

            Query = "";
            SelectedMatch = Matches.FirstOrDefault();
            
        }        

        partial void OnStatusChanged() => StatusVisibility = _Status == null ? Visibility.Collapsed : Visibility.Visible;

        private string FormatStatusQuery(string query) =>
            (query == null || query.Trim().Length == 0) ? "" :
            !query.Contains("'") ? string.Format("'{0}'", query) :
            !query.Contains('"') ? string.Format("\"{0}\"", query) :
            query;

        partial void OnQueryChanged()
        {
            QueryError = "";

            lock (_nextQuerySync)
            {
                if (st != null)
                {
                    st.Abort();
                    st = null;
                }
            }
            
            Status = $"Executing query {FormatStatusQuery(Query)}";
            StatusFadeIn.Begin();

            try
            {
                void queryHandler(string query, IEnumerable<SearchItem> x)
                {
                    try
                    {
                        var x2 = x.ToArray();

                        Window.Dispatcher.Invoke(() =>
                        {
                            
                            Matches.Clear();
                            var firstSet = false;
                            SelectedMatch = null;

                            foreach (var m in x2)
                            {
                                if (!firstSet)
                                {
                                    SelectedMatch = m;
                                    firstSet = true;
                                }

                                Matches.Add(m);
                            }

                            Status = $"Done executing query {FormatStatusQuery(query)}";
                            StatusFadeOut.Begin();

                        });
                    }
                    finally
                    {
                        lock (_nextQuerySync)
                        {
                            st = null;
                        }
                    }
                }

                lock (_nextQuerySync)
                {
                    st = Search.SearchAsync(Query, queryHandler);
                }


            }
            catch (UnauthorizedAccessException e)
            {
                QueryError = e.Message;
            }
        }

        private void MoveMatch(Func<int, bool> check, Func<int, SearchItem> getOther)
        {
            if (_SelectedMatch == null)
            {
                if (Matches.Any())
                {
                    SelectedMatch = Matches.First();
                }
                else
                {
                    return;
                }
            }
            else
            {
                var i = Matches.IndexOf(_SelectedMatch);

                if (check(i))
                {
                    SelectedMatch = getOther(i);
                }
            }

            FocusSelectedItem();
        }

        public void FocusSelectedItem()
        {
            DependencyObject c;

            if (_SelectedMatch == null ||
                (c = _queryListBox.ItemContainerGenerator.ContainerFromItem(_SelectedMatch)) == null)
            {
                return;
            }

            ((ListBoxItem)c).Focus();
        }

        public void PreviousMatch() => MoveMatch(x => x > 0, x => Matches[x - 1]);

        public void NextMatch() => MoveMatch(x => x < Matches.Count - 1, x => Matches[x + 1]);

        public void CompleteQuery()
        {
            if (_SelectedMatch != null)
            {
                Query = _SelectedMatch.Type != SearchItemType.Directory ?
                    _SelectedMatch.Name :
                    _SelectedMatch.ItemPath + Path.DirectorySeparatorChar.ToString();
            }
        }

        public void FocusQuery()
        {
            QueryTextBox.Focus();
            QueryTextBox.CaretIndex = QueryTextBox.Text.Length;
            QueryTextBox.ScrollToEnd();
        }

        public void Control_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            KeyboardController.HandleKey(this, e.Key);
            e.Handled = IsHandled;
        }

        public void DeleteSelectedMatch()
        {
            if (_SelectedMatch == null)
            {
                return;
            }

            var actions = new List<Action>();

            if (Search.Commands.Contains(_SelectedMatch))
            {
                actions.Add(() => Search.Commands.Remove(_SelectedMatch));
            }

            if (!Search.UsageDb.TryGetValue(_SelectedMatch.Type, out var records))
            {
                return;
            }

            foreach (var n in new[] { _SelectedMatch.Name, _SelectedMatch.ItemPath })
            {
                if (n != null &&
                    records.ContainsKey(n) &&
                    records[n] != null &&
                    records[n].HitCount != 0)
                {
                    actions.Add(() => records.Remove(n));
                }
            }

            if (actions.None())
            {
                return;
            }

            var result = MessageBox.Show(
                string.Format("Are you sure you want to delete \"{0}\"?", _SelectedMatch.Name),
                "Confirm",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No)
            {
                Window.Show();
                return;
            }

            foreach (var a in actions)
            {
                a();
            }

            Query = "";
            Search.Save();
            Window.Show();
        }

        public void Control_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Window.IsVisible)
            {
                var h = ((HwndSource)PresentationSource.FromVisual(Window)).Handle;

                if (h == IntPtr.Zero)
                {
                    throw new InvalidOperationException();
                }

                var foreThread = GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero);
                var appThread = Kernel32.GetCurrentThreadId();

                if (foreThread != appThread)
                {
                    //WriteLine("Using AttachThreadInput()");
                    var attached = AttachThreadInput(foreThread, appThread, true);
                    BringWindowToTop(h);
                    ShowWindow(h, ShowWindowCommands.SW_SHOW);

                    if (attached)
                    {
                        AttachThreadInput(foreThread, appThread, false);
                    }
                }
                else
                {
                    ThrowLastErrorIf(!BringWindowToTop(h));
                    ShowWindow(h, ShowWindowCommands.SW_SHOW);
                }

                if (!SetForegroundWindow(h))
                {
                    //WriteLine("SetForegroundWindow() failed");
                }

                if (SetActiveWindow(h) == IntPtr.Zero)
                {
                    //WriteLine("SetActiveWindow() failed");
                }

                if (SetFocus(h) == IntPtr.Zero)
                {
                    //WriteLine("SetFocus() failed");
                }

                Window.Focus();
                QueryTextBox.Focus();
                QueryTextBox.CaretIndex = QueryTextBox.Text.Length;
                QueryTextBox.ScrollToEnd();
            }
        }

        public void UpdateWindowSize()
        {
            if (_queryScrollViewer == null)
            {
                return;
            }

            var padding = _queryScrollViewer.ComputedVerticalScrollBarVisibility == Visibility.Visible ?
                20 :
                5;

            var itemWidth = _queryScrollViewer.ExtentWidth + _widthDelta + padding;
            var width = Math.Min(Math.Max(_minWidth, itemWidth), _maxWidth);

            //WriteLine(JsonSerializer.Serialize(new
            //{
            //    Frame = new StackTrace().GetFrame(1).ToString(),
            //    _queryScrollViewer.ActualWidth,
            //    _queryScrollViewer.ScrollableWidth,
            //    _queryScrollViewer.ExtentWidth,
            //    _queryScrollViewer.Width,
            //    _queryScrollViewer.ViewportWidth
            //}));

            if (width != _lastWidth)
            {
                Window.Width = width;
                _lastWidth = width;
            }
        }

        private void WinKeyPressed(object sender, EventArgs e) => SearchOpen = !SearchOpen;

        private void OverwritingKeyBinding(object sender, HotkeyBindingEventAgs e)
        {
            if (MessageBox.Show(
                $"Are you sure you want to overwrite '{e.Key.ToString()}' binding?\r\n\r\n{e.Binding}",
                "Confirm",
                MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                return;
            }
        }

        public void Listen(IConfirmationSource inputSource) => throw new NotImplementedException();

        public void Listen(IWinKeySource inputSource) => throw new NotImplementedException();
    }
}
