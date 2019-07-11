using Components;
using Components.PInvoke;
using System;
using System.Linq;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using static Components.PInvoke.Shell32;
using FA = System.IO.FileAttributes;
using HandleCache = Components.ArgLockingMemoizer<string, System.IntPtr>;
using static Damselfly.Components.FileSystemCache;
using ST = Damselfly.Components.Search.SearchItemType;
using Img = System.Windows.Media.ImageSource;

namespace Damselfly.Components
{
    public static class IconLoader
    {
        private static readonly IntPtr[] _systemIconHandles =
            typeof(SystemIcons)
                .GetProperties()
                .Select(x => x.GetValue(null))
                .Cast<Icon>()
                .Select(x => x.Handle)
                .ToArray();

        private static readonly HandleCache
            _pathMemoizer = PathCache.Create<IntPtr>(),
            _fileMemoizer = PathCache.Create<IntPtr>(),
            _dirMemoizer = PathCache.Create<IntPtr>();

        private static readonly ArgLockingMemoizer<IntPtr, BitmapSource> _sourceMemoizer = new ArgLockingMemoizer<IntPtr, BitmapSource>();

        private static readonly ArgLockingMemoizer<(string, string, ST), Img> _imageSourceMemoizer =
            new ArgLockingMemoizer<(string, string, ST), Img>(
                new SelectorComparer<(string, string, ST), (string, string)>(x => (x.Item1, x.Item2)));

        private static IntPtr GetHandle(string path) => _pathMemoizer.Call(GetHandleCore, path);

        private static IntPtr GetHandleCore(string path)
        {
            var fullPath =
                FileExists(path) ||
                DirectoryExists(path) ||
                path.StartsWith(@"\\") ?
                    path :
                    WindowsPath.Search(path);

            if (FileExists(fullPath))
            {
                Console.WriteLine("File Full Path Icon");
                var ptr = GetFileIcon(fullPath);

                if (_systemIconHandles.Contains(ptr))
                {
                    Icon.ExtractAssociatedIcon(fullPath);
                }

                return GetFileIcon(fullPath);
                //return Icon.ExtractAssociatedIcon(fullPath).Handle;
            }
            else if (DirectoryExists(fullPath))
            {
                Console.WriteLine("Dir Full Path Icon");
                return GetDirectoryIcon(fullPath);                
            }
            else
            {
                Console.WriteLine("Error Icon");
                return SystemIcons.Error.Handle;

            }
        }

        private static IntPtr GetFileIconCore(string path)
        {
            var ptr = GetShellInfo(path, FA.Normal);

            if (IsSystemIcon(ptr))
            {
                try
                {
                    var icon = Icon.ExtractAssociatedIcon(path);

                    if (icon != null && icon.Handle != IntPtr.Zero && !IsSystemIcon(icon.Handle))
                    {
                        return icon.Handle;
                    }

                }
                catch
                {
                    Trace.WriteLine($"Icon.ExtractAssociatedIcon failed with {path}");
                }
            }

            return ptr;
        }

        private static IntPtr GetFileIcon(string path) => _fileMemoizer.Call(GetFileIconCore, path);
        
        private static IntPtr GetDirectoryIcon(string path) => _dirMemoizer.Call(x => GetShellInfo(x, FA.Directory), path);

        private static IntPtr GetShellInfo(string path, FA attributes)
        {
            var shinfo = new SHFILEINFO();

            return SHGetFileInfo(
                path,
                (uint)attributes,
                ref shinfo,
                (uint) Marshal.SizeOf(shinfo),
                SHGFI_ICON |
                    SHGFI_SMALLICON |
                    //SHGFI_LARGEICON |
                    SHGFI_USEFILEATTRIBUTES |
                    SHGFI_ADDOVERLAYS) != IntPtr.Zero ?
                    shinfo.hIcon :
                    SystemIcons.Application.Handle;
        }

        private static IntPtr FindIcon((string, string, ST) tupleInner)
        {
            var (itemPath, name, type) = tupleInner;

            if (type == ST.Command)
            {
                itemPath = name;
            }

            if (itemPath != null)
            {
                var p = itemPath.TrimEnd('\\');
                int count;

                if (p.StartsWith("\\\\") && ((count = p.Count(x => x == '\\')) == 2 || count == 3))
                {
                    return GetHandle(".\\");
                }
            }

            IntPtr h;

            if (itemPath != null && FileExists(itemPath))
            {
                h = GetFileIcon(itemPath);
            }
            else if (type != ST.Command)
            {
                h = GetHandle(itemPath);
            }
            else
            {
                var tokens = ArgLexer.Tokenize(name);

                if (tokens.Length == 0)
                {
                    h = SystemIcons.Error.Handle;
                }
                else if (FileExists(tokens[0]))
                {
                    h = GetFileIcon(tokens[0]);
                }
                else
                {
                    var exe = tokens[0];

                    if (exe.StartsWith("\"") && exe.EndsWith("\""))
                    {
                        exe = exe.Substring(1, exe.Length - 2);
                    }

                    var fullpath = WindowsPath.Search(exe);

                    if (fullpath != null && FileExists(fullpath))
                    {
                        h = GetFileIcon(fullpath);
                    }
                    else if (exe != null && FileExists(exe))
                    {
                        h = GetFileIcon(exe);
                    }
                    else
                    {
                        h = SystemIcons.Error.Handle;
                    }
                }
            }

            return h;
        }

        public static Img LoadSource((string, string, ST) tuple) =>
            _imageSourceMemoizer.Call(x => LoadSource(FindIcon(x)), tuple);

        public static Img LoadSource(IntPtr icon) => _sourceMemoizer.Call(
            x => Imaging
                .CreateBitmapSourceFromHIcon(
                    x == IntPtr.Zero ? SystemIcons.Error.Handle : icon,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromWidthAndHeight(16, 16))
                .Do(y => y.Freeze()),
            icon);

        public static bool IsSystemIcon(IntPtr handle) => _systemIconHandles.Contains(handle);
    }
}
