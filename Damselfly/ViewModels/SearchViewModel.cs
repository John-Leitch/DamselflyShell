﻿using Components;
using Components.PInvoke;
using Damselfly.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public SearchWindow Window { get; private set; }

        public TextBox QueryTextBox { get; private set; }

        public StartSearch Search { get; private set; }

        public ObservableCollection<SearchItem> Matches { get; private set; }

        public bool IsHandled { get; set; }

        public SearchViewModel(SearchWindow window, TextBox queryTextBox, ListBox queryListBox)
        {
            Search = new StartSearch();
            Window = window;
            Matches = new ObservableCollection<SearchItem>();
            QueryTextBox = queryTextBox;
            _queryListBox = queryListBox;
        }

        public void Init()
        {
            Query = "";
            SelectedMatch = Matches.FirstOrDefault();
        }

        private void QueryChanged()
        {
            
            QueryError = "";

            try
            {
                Search.SearchAsync(Query, x =>
                {
                    Window.Dispatcher.Invoke(() =>
                    {
                        Matches.Clear();

                        foreach (var m in x)
                        {
                            //m.ParentElement = _queryListBox;
                            Matches.Add(m);
                        }

                        SelectedMatch = Matches.FirstOrDefault();
                    });
                });
            }
            catch (UnauthorizedAccessException e)
            {
                QueryError = e.Message;
            }
        }

        private void MoveMatch(Func<int, bool> check, Func<int, SearchItem> getOther)
        {
            if (_selectedMatch == null)
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
                var i = Matches.IndexOf(_selectedMatch);

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

            if (_selectedMatch == null ||
                (c = _queryListBox.ItemContainerGenerator.ContainerFromItem(_selectedMatch)) == null)
            {
                return;
            }

            ((ListBoxItem)c).Focus();
        }

        public void PreviousMatch()
        {
            MoveMatch(x => x > 0, x => Matches[x - 1]);
        }

        public void NextMatch()
        {
            MoveMatch(x => x < Matches.Count - 1, x => Matches[x + 1]);
        }

        public void CompleteQuery()
        {
            if (_selectedMatch != null)
            {
                Query = _selectedMatch.Type != SearchItemType.Directory ?
                    _selectedMatch.Name :
                    _selectedMatch.ItemPath + Path.DirectorySeparatorChar.ToString();
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
            if (_selectedMatch == null)
            {
                return;
            }

            var actions = new List<Action>();

            if (Search.Commands.Contains(_selectedMatch))
            {
                actions.Add(() => Search.Commands.Remove(_selectedMatch));
            }

            Dictionary<string, UsageRecord> records;

            if (!Search.UsageDb.TryGetValue(_selectedMatch.Type, out records))
            {
                return;
            }

            foreach (var n in new[] { _selectedMatch.Name, _selectedMatch.ItemPath })
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
                string.Format("Are you sure you want to delete \"{0}\"?", _selectedMatch.Name),
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
            Search.LoadItems();
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

                Window.Focus();
                QueryTextBox.Focus();
                QueryTextBox.CaretIndex = QueryTextBox.Text.Length;
                QueryTextBox.ScrollToEnd();
            }
        }
    }
}
