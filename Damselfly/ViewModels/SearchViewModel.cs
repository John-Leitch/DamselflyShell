using Components;
using Components.PInvoke;
using Damselfly.Components;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;

namespace Damselfly.ViewModels
{
    public class SearchViewModel : ViewModel
    {
        private SearchWindow _window;

        private TextBox _queryTextBox;

        private ListBox _queryListBox;

        private string _query;

        public string Query
        {
            get { return _query; }
            set
            {
                SetProperty(ref _query, value);
                QueryChanged();
            }
        }

        private StartSearch _search = new StartSearch();

        public StartSearch Search
        {
            get { return _search; }
        }

        private ObservableCollection<SearchItem> _matches = new ObservableCollection<SearchItem>();

        public ObservableCollection<SearchItem> Matches
        {
            get { return _matches; }
        }

        private SearchItem _selectedMatch = null;

        public SearchItem SelectedMatch
        {
            get { return _selectedMatch; }
            set { SetProperty(ref _selectedMatch, value); }
        }

        private string _queryError;

        public string QueryError
        {
            get { return _queryError; }
            set { SetProperty(ref _queryError, value); }
        }

        public SearchViewModel(SearchWindow window, TextBox queryTextBox, ListBox queryListBox)
        {
            _window = window;
            _queryTextBox = queryTextBox;
            _queryListBox = queryListBox;
        }

        public void Init()
        {
            Query = "";
            SelectedMatch = _matches.FirstOrDefault();

            //Query = "Aphid";
            //Query = "c:\\source\\fuzzing";
        }

        private void QueryChanged()
        {
            
            QueryError = "";

            try
            {
                _search.SearchAsync(Query, x =>
                {
                    _window.Dispatcher.Invoke(() =>
                    {
                        _matches.Clear();

                        foreach (var m in x)
                        {
                            //m.ParentElement = _queryListBox;
                            _matches.Add(m);
                        }

                        SelectedMatch = _matches.FirstOrDefault();
                    });
                });
            }
            catch (UnauthorizedAccessException e)
            {
                QueryError = e.Message;
            }

            //try
            //{
            //    var queryMatches = _search.Search(Query);

            //    foreach (var m in queryMatches)
            //    {
            //        _matches.Add(m);
            //    }
            //}
            //catch (UnauthorizedAccessException e)
            //{
            //    QueryError = e.Message;
            //}

            //SelectedMatch = _matches.FirstOrDefault();
        }

        private void MoveMatch(Func<int, bool> check, Func<int, SearchItem> getOther)
        {
            if (_selectedMatch == null)
            {
                if (_matches.Any())
                {
                    SelectedMatch = _matches.First();
                }
                else
                {
                    return;
                }
            }
            else
            {
                var i = _matches.IndexOf(_selectedMatch);

                if (check(i))
                {
                    SelectedMatch = getOther(i);
                }
            }

            FocusSelectedItem();
        }

        private void FocusSelectedItem()
        {
            DependencyObject c;

            if (_selectedMatch == null ||
                (c = _queryListBox.ItemContainerGenerator.ContainerFromItem(_selectedMatch)) == null)
            {
                return;
            }

            ((ListBoxItem)c).Focus();
        }

        private void PreviousMatch()
        {
            MoveMatch(x => x > 0, x => _matches[x - 1]);
        }

        private void NextMatch()
        {
            MoveMatch(x => x < _matches.Count - 1, x => _matches[x + 1]);
        }

        private void CompleteQuery()
        {
            if (_selectedMatch != null)
            {
                Query = _selectedMatch.Name +
                    (_selectedMatch.Type == SearchItemType.Directory ?
                    System.IO.Path.DirectorySeparatorChar.ToString() : "");
            }
        }

        private void FocusQuery()
        {
            _queryTextBox.Focus();
            _queryTextBox.CaretIndex = _queryTextBox.Text.Length;
            _queryTextBox.ScrollToEnd();
        }

        public void Control_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Tab:
                    e.Handled = true;

                    if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                    {
                        var q = Query;

                        if (q.Length == 0)
                        {
                            break;
                        }

                        if (q[q.Length - 1] == Path.DirectorySeparatorChar)
                        {
                            q = q.Remove(q.Length - 1);
                        }

                        if (q.Any(x => x == Path.DirectorySeparatorChar))
                        {
                            Query = q.Remove(q.Length - Path.GetFileName(q).Length);
                        }

                        FocusQuery();
                    }
                    else
                    {
                        CompleteQuery();
                        FocusQuery();
                    }
                    break;

                case Key.Up:
                    e.Handled = true;
                    PreviousMatch();

                    break;

                case Key.Down:
                    e.Handled = true;
                    NextMatch();
                    break;

                case Key.Escape:
                    Query = "";
                    _window.Hide();
                    break;

                case Key.Enter:

                    if (_selectedMatch != null &&
                        _selectedMatch.Type != SearchItemType.Command)
                    {
                        switch (_selectedMatch.Type)
                        {
                            case SearchItemType.File:
                            case SearchItemType.StartMenu:
                            case SearchItemType.Directory:
                                try
                                {

                                    Process.Start(_selectedMatch.Path);

                                    Func<SearchItem, bool> predicate = x =>
                                        x.Name == _selectedMatch.Name && x.Path == _selectedMatch.Path;

                                    if (!_search.StartMenuItems.Any(predicate) && 
                                        !_search.SpecialFolders.Any(predicate) &&
                                        !_search.Commands.Any(predicate) &&
                                        !_search.SystemFiles.Any(predicate))
                                    {
                                        _search.Commands.Add(_selectedMatch);
                                    }

                                    _selectedMatch.Usage.HitCount++;
                                    _search.Save();

                                    Query = "";
                                    _window.Hide();

                                }
                                catch (Win32Exception ex)
                                {
                                    QueryError = ex.Message;
                                }

                                break;
                        }
                    }
                    else
                    {
                        try
                        {
                            string cmd = _selectedMatch != null ?
                                _selectedMatch.Name :
                                Query;

                            var i = cmd.IndexOf(' ');

                            if (i != -1)
                            {
                                Process.Start(cmd.Remove(i), cmd.Substring(i + 1));
                            }
                            else
                            {
                                Process.Start(cmd);
                            }

                            if (_selectedMatch == null)
                            {
                                var si = new SearchItem()
                                {
                                    Type = SearchItemType.Command,
                                    Name = cmd,
                                };

                                if (!_search.Commands.Any(x => x.Name == si.Name))
                                {
                                    _search.Commands.Add(si);
                                }

                                var records = _search.UsageDb.GetOrCreate(SearchItemType.Command);

                                UsageRecord usage;

                                if (!records.TryGetValue(cmd, out usage))
                                {
                                    usage = new UsageRecord() { HitCount = 1 };
                                    records.Add(cmd, usage);
                                }
                                else
                                {
                                    usage.HitCount++;
                                }

                                si.Usage = usage;
                            }
                            else
                            {
                                _selectedMatch.Usage.HitCount++;
                            }

                            _search.Save();

                            Query = "";
                            _window.Hide();
                        }
                        catch (Win32Exception ex)
                        {
                            QueryError = ex.Message;
                        }
                    }

                    break;

                case Key.D:
                    if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                    {
                        DeleteSelectedMatch();
                    }
                    else
                    {
                        _queryTextBox.Focus();
                    }

                    break;

                //case Key.Delete:
                //    DeleteSelectedMatch();

                //    break;

                case Key.PageUp:
                case Key.PageDown:
                    FocusSelectedItem();
                    break;

                case Key.Home:
                case Key.End:
                    break;

                default:
                    _queryTextBox.Focus();
                    break;


            }
        }

        private void DeleteSelectedMatch()
        {
            if (_selectedMatch == null)
            {
                return;
            }

            var result = MessageBox.Show(
                string.Format("Are you sure you want to delete \"{0}\"?", _selectedMatch.Name),
                "Confirm",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No)
            {
                _window.Show();
                return;
            }

            switch (_selectedMatch.Type)
            {
                case SearchItemType.Command:
                    _search.Commands.Remove(_selectedMatch);
                    _search.UsageDb[SearchItemType.Command].Remove(_selectedMatch.Name);
                    break;

                default:
                    throw new InvalidOperationException();
            }

            Query = "";
            _search.Save();
            _window.Show();
        }

        public void Control_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //if (_window.Handle != IntPtr.Zero && _window.IsVisible)
            if (_window.IsVisible)
            {
                var h = ((HwndSource)PresentationSource.FromVisual(_window)).Handle;

                if (h == IntPtr.Zero)
                {
                    throw new InvalidOperationException();
                }

                //if (User32.SetWindowPos(h, User32.HWND_TOPMOST, 0, 0, 0, 0, User32.SetWindowPosFlags.IgnoreMove | User32.SetWindowPosFlags.IgnoreResize))
                //{
                //    Console.WriteLine("SetWindowPos() failed");
                //}

                //User32.AttachThreadInput((uint)Process.GetCurrentProcess().Id, GetCurrentThreadId(), true);

                //h = Process.GetCurrentProcess().MainWindowHandle;

                //if (h == IntPtr.Zero)
                //{
                //    Console.WriteLine("No window handle");
                //    return;
                //}

                //if (!User32.BringWindowToTop(h))
                //{
                //    Console.WriteLine("BringWindowToTop() failed");
                //}

                uint foreThread = User32.GetWindowThreadProcessId(User32.GetForegroundWindow(), IntPtr.Zero);
                uint appThread = Kernel32.GetCurrentThreadId();
                const uint SW_SHOW = 5;
                if (foreThread != appThread)
                {
                    Console.WriteLine("Using AttachThreadInput()");
                    User32.AttachThreadInput(foreThread, appThread, true);
                    User32.BringWindowToTop(h);
                    User32.ShowWindow(h, SW_SHOW);
                    User32.AttachThreadInput(foreThread, appThread, false);
                }
                else
                {
                    User32.BringWindowToTop(h);
                    User32.ShowWindow(h, SW_SHOW);
                }

                if (!User32.SetForegroundWindow(h))
                {
                    Console.WriteLine("SetForegroundWindow() failed");
                }

                if (User32.SetActiveWindow(h) == IntPtr.Zero)
                {
                    Console.WriteLine("SetActiveWindow() failed");
                }

                if (User32.SetFocus(h) == IntPtr.Zero)
                {
                    Console.WriteLine("SetFocus() failed");
                }

                _window.Focus();
                _queryTextBox.Focus();
                _queryTextBox.CaretIndex = _queryTextBox.Text.Length;
                _queryTextBox.ScrollToEnd();

                return;

                if (!User32.SetForegroundWindow(h))
                {
                    Console.WriteLine("SetForegroundWindow() failed");
                }

                if (User32.SetActiveWindow(h) == IntPtr.Zero)
                {
                    Console.WriteLine("SetActiveWindow() failed");
                }

                if (User32.SetFocus(h) == IntPtr.Zero)
                {
                    Console.WriteLine("SetFocus() failed");
                }

                //try
                //{
                _window.Focus();
                _queryTextBox.Focus();
                _queryTextBox.CaretIndex = _queryTextBox.Text.Length;
                _queryTextBox.ScrollToEnd();
                //}
                //catch
                //{
                //}
            }
        }
    }
}
