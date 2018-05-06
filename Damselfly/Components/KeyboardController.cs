using Components;
using Components.PInvoke;
using Damselfly.ViewModels;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

        public static void HandleKey(SearchViewModel viewModel, Key key)
        {
            viewModel.IsHandled = false;

            switch (key)
            {
                case Key.Tab:
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

                case Key.Up:
                    viewModel.IsHandled = true;
                    viewModel.PreviousMatch();

                    break;

                case Key.Down:
                    viewModel.IsHandled = true;
                    viewModel.NextMatch();
                    break;

                case Key.Escape:
                    viewModel.Query = "";
                    viewModel.Window.Hide();
                    break;

                case Key.Enter:

                    var asAdmin =
                        (Keyboard.Modifiers & ModifierKeys.Control) != 0 &&
                        (Keyboard.Modifiers & ModifierKeys.Shift) != 0;

                    if (viewModel.SelectedMatch != null &&
                        viewModel.SelectedMatch.Type != SearchItemType.Command)
                    {
                        switch (viewModel.SelectedMatch.Type)
                        {
                            case SearchItemType.File:
                            case SearchItemType.StartMenu:
                            case SearchItemType.Directory:
                                try
                                {
                                    var si = new ProcessStartInfo(viewModel.SelectedMatch.ItemPath);

                                    if (asAdmin)
                                    {
                                        si.Verb = "runas";
                                    }

                                    Process.Start(si);

                                    Func<SearchItem, bool> predicate = x =>
                                        x.Name == viewModel.SelectedMatch.Name &&
                                            x.ItemPath == viewModel.SelectedMatch.ItemPath;

                                    if (!viewModel.Search.StartMenuItems.Any(predicate) &&
                                        !viewModel.Search.SpecialFolders.Any(predicate) &&
                                        !viewModel.Search.Commands.Any(predicate) &&
                                        !viewModel.Search.SystemFiles.Any(predicate))
                                    {
                                        viewModel.Search.Commands.Add(viewModel.SelectedMatch);
                                    }

                                    viewModel.SelectedMatch.Usage.HitCount++;
                                    viewModel.Search.Save();

                                    viewModel.Query = "";
                                    viewModel.Window.Hide();

                                }
                                catch (Win32Exception ex)
                                {
                                    viewModel.QueryError = ex.Message;
                                }

                                break;
                        }
                    }
                    else
                    {
                        try
                        {
                            var cmd =
                                viewModel.SelectedMatch != null ?
                                viewModel.SelectedMatch.Name :
                                viewModel.Query;

                            var i = cmd.IndexOf(' ');

                            var si = i != -1 ?
                                new ProcessStartInfo(cmd.Remove(i), cmd.Substring(i + 1)) :
                                new ProcessStartInfo(cmd);

                            if (asAdmin)
                            {
                                si.Verb = "runas";
                            }

                            Process.Start(si);

                            if (viewModel.SelectedMatch == null)
                            {
                                var item = new SearchItem()
                                {
                                    Type = SearchItemType.Command,
                                    Name = cmd,
                                };

                                if (!viewModel.Search.Commands.Any(x => x.Name == item.Name))
                                {
                                    viewModel.Search.Commands.Add(item);
                                }

                                var records = viewModel.Search.UsageDb.GetOrCreate(
                                    SearchItemType.Command);

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

                                item.Usage = usage;
                            }
                            else
                            {
                                viewModel.SelectedMatch.Usage.HitCount++;
                            }

                            viewModel.Search.Save();

                            viewModel.Query = "";
                            viewModel.Window.Hide();
                        }
                        catch (Win32Exception ex)
                        {
                            viewModel.QueryError = ex.Message;
                        }
                    }

                    break;

                case Key.D:
                    if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                    {
                        viewModel.DeleteSelectedMatch();
                    }
                    else
                    {
                        viewModel.QueryTextBox.Focus();
                    }

                    break;

                case Key.PageUp:
                case Key.PageDown:
                    viewModel.FocusSelectedItem();
                    break;

                case Key.Home:
                case Key.End:
                    break;

                default:
                    viewModel.QueryTextBox.Focus();
                    break;


            }
        }
    }
}
