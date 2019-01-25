using Components;
using Components.PInvoke;
using Damselfly.Components.Search;
using Damselfly.ViewModels;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace Damselfly.Components
{
    public static class KeyboardController
    {
        private static void SendKey(Key key, int flags) =>
            User32.keybd_event((byte)KeyInterop.VirtualKeyFromKey(key), 0, flags, IntPtr.Zero);

        public static void SendKeyDown(Key key) =>
            SendKey(key, User32.KEYEVENTF_EXTENDEDKEY);

        public static void SendKeyUp(Key key) =>
            SendKey(key, User32.KEYEVENTF_EXTENDEDKEY | User32.KEYEVENTF_KEYUP);

        public static void HandleKey(SearchViewModel viewModel, Key key)
        {
            viewModel.IsHandled = false;

            var controlShift =
                (Keyboard.Modifiers & ModifierKeys.Control) != 0 &&
                (Keyboard.Modifiers & ModifierKeys.Shift) != 0;

            var controlAlt =
                (Keyboard.Modifiers & ModifierKeys.Control) != 0 &&
                (Keyboard.Modifiers & ModifierKeys.Alt) != 0;

            switch (key)
            {
                case Key.T:
                {
                    if (controlShift)
                    {
                        var buffer = viewModel.Query;

                        if (buffer.Length == 0)
                        {
                            return;
                        }

                        viewModel.IsHandled = true;
                        viewModel.Query = "";

                        ThreadPool.QueueUserWorkItem(x =>
                        {
                            Thread.Sleep(100);

                            if (!User32.GetCursorPos(out var point))
                            {
                                throw Win32.CreateWin32Exception();
                            }

                            //User32.mouse_event(MouseEventFlags.LEFTDOWN, point.x, point.y,
                            foreach (var f in new[] { MouseEventFlags.LEFTDOWN, MouseEventFlags.LEFTUP })
                            {
                                User32.mouse_event(f, point.x, point.y, 0, UIntPtr.Zero);
                                Thread.Sleep(10);
                            }

                            KeyboardAutomation.Type(buffer);

                        });
                    }
                    break;
                }

                case Key.Tab:
                {
                    viewModel.IsHandled = true;

                    if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                    {
                        var q = viewModel.Query;

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
                            viewModel.Query = q.Remove(q.Length - Path.GetFileName(q).Length);
                        }

                        viewModel.FocusQuery();
                    }
                    else
                    {
                        viewModel.CompleteQuery();
                        viewModel.FocusQuery();
                    }
                    break;
                }

                case Key.Up:
                {
                    viewModel.IsHandled = true;
                    viewModel.PreviousMatch();

                    break;
                }

                case Key.Down:
                {
                    viewModel.IsHandled = true;
                    viewModel.NextMatch();
                    break;
                }

                case Key.Escape:
                {
                    viewModel.Query = "";
                    viewModel.Window.Hide();
                    break;
                }

                case Key.Enter:
                {
                    string command = null;
                    var match = viewModel.SelectedMatch;

                    if (viewModel.Query == "!forceCrash")
                    {
                        var x = 0;
                        var y = 1 / x;
                    }

                    if (viewModel.SelectedMatch != null &&
                        viewModel.SelectedMatch.Type != SearchItemType.Command)
                    {
                        switch (viewModel.SelectedMatch.Type)
                        {
                            case SearchItemType.File:
                            case SearchItemType.StartMenu:
                            case SearchItemType.Directory:
                            {
                                command = viewModel.SelectedMatch.ItemPath;
                                viewModel.Query = "";
                                viewModel.Window.Hide();

                                ThreadPool.QueueUserWorkItem(x =>
                                {
                                    try
                                    {
                                        Launcher.Launch(command, controlShift);

                                        bool predicate(SearchItem y) =>
                                            y.Name == match.Name && y.ItemPath == match.ItemPath;

                                        if (!viewModel.Search.StartMenuItems.Any(predicate) &&
                                            !viewModel.Search.SpecialFolders.Any(predicate) &&
                                            !viewModel.Search.Commands.Any(predicate) &&
                                            !viewModel.Search.SystemFiles.Any(predicate))
                                        {
                                            viewModel.Search.Commands.Add(match);
                                        }

                                        match.Usage.HitCount++;
                                        viewModel.Search.Save();
                                    }
                                    catch (Win32Exception ex)
                                    {
                                        ShowError(command, ex);
                                    }
                                });

                                break;
                            }
                        }
                    }
                    else
                    {

                        command =
                            viewModel.SelectedMatch != null ?
                            viewModel.SelectedMatch.Name :
                            viewModel.Query;

                        viewModel.Query = "";
                        viewModel.Window.Hide();

                        ThreadPool.QueueUserWorkItem(x =>
                        {
                            try
                            {
                                Launcher.Launch(command, controlShift);

                                if (match == null)
                                {
                                    var item = new SearchItem
                                    {
                                        Type = SearchItemType.Command,
                                        Name = command,
                                    };

                                    if (!viewModel.Search.Commands.Any(y => y.Name == item.Name))
                                    {
                                        viewModel.Search.Commands.Add(item);
                                    }

                                    var records = viewModel.Search.UsageDb.GetOrAdd(
                                        SearchItemType.Command);

                                    if (!records.TryGetValue(command, out var usage))
                                    {
                                        usage = new UsageRecord { HitCount = 1 };
                                        records.Add(command, usage);
                                    }
                                    else
                                    {
                                        usage.HitCount++;
                                    }

                                    item.Usage = usage;
                                }
                                else
                                {
                                    match.Usage.HitCount++;
                                }

                                viewModel.Search.Save();
                            }
                            catch (Win32Exception ex)
                            {
                                ShowError(command, ex);
                            }
                        });
                    }

                    break;
                }

                case Key.D:
                {
                    if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                    {
                        viewModel.DeleteSelectedMatch();
                    }
                    else
                    {
                        viewModel.QueryTextBox.Focus();
                    }

                    break;
                }

                case Key.PageUp:
                case Key.PageDown:
                {
                    viewModel.FocusSelectedItem();
                    break;
                }

                case Key.Home:
                case Key.End:
                    break;

                case Key.D0:
                case Key.D1:
                case Key.D2:
                case Key.D3:
                case Key.D4:
                case Key.D5:
                case Key.D6:
                case Key.D7:
                case Key.D8:
                case Key.D9:
                {
                    if (controlAlt)
                    {
                        viewModel.SetGlobalHotkey(key);
                    }

                    break;
                }

                default:
                {
                    viewModel.QueryTextBox.Focus();
                    break;
                }
            }
        }

        public static void ShowError(string command, Exception exception)
        {
            MessageBox.Show(
                //command != null ? 
                //    string.Format(
                //        "Error running command {0}:\r\n{1}",
                //        command,
                //        exception.Message) :
                //    string.Format(
                //        "Error running command: {0}",
                //        exception.Message),
                command != null ?
                    string.Format("Error running command:\r\n\r\n{0}", command) :
                    "Error running command",
                "Error running command",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }
}
