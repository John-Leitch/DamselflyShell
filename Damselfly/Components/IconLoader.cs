using Components;
using Components.PInvoke;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using static Components.PInvoke.Shell32;
using FA = System.IO.FileAttributes;
using HandleCache = Components.ArgLockingMemoizer<string, System.IntPtr>;

namespace Damselfly.Components
{
    public static class IconLoader
    {
        private static readonly ArgLockingMemoizer<IntPtr, BitmapSource> _sourceMemoizer = new ArgLockingMemoizer<IntPtr, BitmapSource>();

        private static readonly ArgLockingMemoizer<string, IntPtr> _pathMemoizer = new ArgLockingMemoizer<string, IntPtr>();

        public static BitmapSource GetSource(IntPtr icon) => _sourceMemoizer.Call(GetSourceCore, icon);

        public static IntPtr GetHandle(string path) => _pathMemoizer.Call(GetHandleCore, path);

        private static BitmapSource GetSourceCore(IntPtr icon)
        {
            if (icon == IntPtr.Zero)
            {
                icon = SystemIcons.Error.Handle;
            }

            var bmp = Imaging.CreateBitmapSourceFromHIcon(
                icon,
                Int32Rect.Empty,
                BitmapSizeOptions.FromWidthAndHeight(16, 16));

            bmp.Freeze();

            return bmp;
        }

        //BitmapSizeOptions.FromWidthAndHeight(32, 32));

        private static IntPtr GetHandleCore(string path)
        {
            var fullPath = File.Exists(path) || Directory.Exists(path) || path.StartsWith(@"\\") ?
                path :
                WindowsPath.Search(path);

            if (File.Exists(fullPath))
            {
                Console.WriteLine("File Full Path Icon");
                return GetFileIcon(fullPath);
                //return Icon.ExtractAssociatedIcon(fullPath).Handle;
            }
            else if (Directory.Exists(fullPath))
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

        private static HandleCache _fileMemoizer = new HandleCache(), _dirMemoizer = new HandleCache();

        public static IntPtr GetFileIcon(string path) => _fileMemoizer.Call(x => GetShellInfo(x, FA.Normal), path);

        public static IntPtr GetDirectoryIcon(string path) => _dirMemoizer.Call(x => GetShellInfo(x, FA.Directory), path);

        public static IntPtr GetShellInfo(string path, FA attributes)
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

    }
}
