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

namespace Damselfly.Components
{
    public static class IconLoader
    {
        private static readonly ArgLockingMemoizer<IntPtr, BitmapSource> _sourceMemoizer = new ArgLockingMemoizer<IntPtr, BitmapSource>();

        private static readonly ArgLockingMemoizer<string, IntPtr> _pathMemoizer = new ArgLockingMemoizer<string, IntPtr>();

        public static BitmapSource GetSource(IntPtr icon) => _sourceMemoizer.Call(GetSourceCore, icon);

        public static IntPtr GetHandle(string path) => _pathMemoizer.Call(GetHandleCore, path);

        private static BitmapSource GetSourceCore(IntPtr icon) =>
            Imaging.CreateBitmapSourceFromHIcon(
                icon,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

        private static IntPtr GetHandleCore(string path)
        {
            IntPtr handle;

            var fullPath = File.Exists(path) || Directory.Exists(path) || path.StartsWith(@"\\") ?
                path :
                WindowsPath.Search(path);

            if (!Directory.Exists(fullPath) && !File.Exists(fullPath))
            {
                return SystemIcons.Error.Handle;
            }

            try
            {

                return Icon.ExtractAssociatedIcon(fullPath).Handle;
            }
            catch (Exception e)
            {
                Trace.TraceError($"Error extracting associated icon:\r\n{e}\r\n");
                var shinfo = new SHFILEINFO();

#pragma warning disable ERP022 // Catching everything considered harmful.
                return Shell32.SHGetFileInfo(
                    fullPath,
                    0,
                    ref shinfo,
                    (uint)Marshal.SizeOf(shinfo),
                    Shell32.SHGFI_ICON | Shell32.SHGFI_SMALLICON) != IntPtr.Zero ?
                        shinfo.hIcon :
                        SystemIcons.Application.Handle;
#pragma warning restore ERP022 // Catching everything considered harmful.
            }
        }
    }
}
