using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

using Components;
using Components.PInvoke;

using static System.Drawing.SystemIcons;
using static Components.PInvoke.Shell32;
using static Damselfly.Components.FileSystemCache;

using FA = System.IO.FileAttributes;
using HandleCache = Components.ArgLockingMemoizer<string, System.IntPtr>;
using Img = System.Windows.Media.ImageSource;
using Rect = System.Windows.Int32Rect;
using ST = Damselfly.Components.Search.SearchItemType;

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
                new SelectorComparer<(string, string, ST), (string, string, ST)>(x => (x.Item1, x.Item2, x.Item3)));

        public static Lazy<Img>
            DefaultImage = new Lazy<Img>(() => LoadSource(Application.Handle)),
            ErrorImage = new Lazy<Img>(() => LoadSource(Error.Handle));

        private static IntPtr GetHandle(string path) => _pathMemoizer.Call(GetHandleCore, path);

        private static IntPtr GetHandleCore(string path)
        {
            var fullPath =
                FileExists(path) ||
                DirectoryExists(path) ||
                path.StartsWith(@"\\") ?
                    path :
                    WindowsPath.Search(path) ?? path;

            if (FileExists(fullPath))
            {
                //Console.WriteLine("File Full Path Icon");
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
                //Console.WriteLine("Dir Full Path Icon");
                return GetDirectoryIcon(fullPath);                
            }
            else
            {
                //Console.WriteLine("Error Icon");
                return Error.Handle;

            }
        }

        private static IntPtr GetFileIconCore(string path)
        {
            var ptr = GetShellInfo(path, FA.Normal);

            if (IsSystemIconHandle(ptr))
            {
                try
                {
                    var icon = Icon.ExtractAssociatedIcon(path);

                    if (icon != null && icon.Handle != IntPtr.Zero &&
                        ((!IsSystemIconHandle(icon.Handle) ||
                        (ptr == Error.Handle && icon.Handle != ptr))))
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
                    Application.Handle;
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

            if (itemPath != null && WindowsPath.IsValidPath(itemPath) && FileExists(itemPath))
            {
                h = GetFileIcon(itemPath);
            }
            //else if ()
            else if (WindowsPath.IsValidPath(itemPath) && type != ST.Command)
            //else if (itemPath.Contains(Path.))
            {
                h = GetHandle(itemPath);
            }
            else
            {
                var tokens = ArgLexer.Tokenize(name);

                if (tokens.Length == 0)
                {
                    h = Error.Handle;
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
                        h = Error.Handle;
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
                    x == IntPtr.Zero ? Error.Handle : icon,
                    Rect.Empty,
                    BitmapSizeOptions.FromWidthAndHeight(16, 16))
                .Do(y => y.Freeze()),
            icon);

        public static bool IsSystemIconHandle(IntPtr handle) => _systemIconHandles.Contains(handle);

        public static bool IsDefaultOrError(Img icon) =>
            icon != null &&
            ((DefaultImage.IsValueCreated && icon == DefaultImage.Value) ||
                (ErrorImage.IsValueCreated && icon == ErrorImage.Value));
    }
}
