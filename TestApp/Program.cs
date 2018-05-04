using Components.PInvoke;
using Damselfly.Components;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;

namespace TestApp
{
    public static class WindowHelper
    {
        public static IntPtr FindWindow(params string[] path)
        {
            if (path == null || path.Length == 0)
            {
                throw new ArgumentException();
            }

            var p = User32.FindWindow(path[0], null);

            if (p == IntPtr.Zero)
            {
                return p;
            }

            for (var i = 1; i < path.Length; i++)
            {
                p = User32.FindWindowEx(p, IntPtr.Zero, path[i], null);
            }

            return p;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var handle2 = IconLoader.GetHandle(@"c:\windows\system32\cmd.exe");
            var source2 = IconLoader.GetSource(handle2);
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(source2));
            var png = @"c:\temp\test.png";
            using (var f = File.Create(png))
            {
                encoder.Save(f);
            }

            var mscName = MscHelper.GetName(@"c:\windows\system32\services.msc");


            //.Select(x => new
            //{
            //    x.Name,
            //    x.Value
            //}).Where(x => x.Value.Length > 0 && x.Value.Length < 100).ToArray();
            var specialFolders = (Environment.SpecialFolder[])Enum.GetValues(typeof(Environment.SpecialFolder));
            specialFolders = new Environment.SpecialFolder[]
            {
                  Environment.SpecialFolder.Desktop,
                  Environment.SpecialFolder.Favorites,
                  Environment.SpecialFolder.MyComputer,
                  Environment.SpecialFolder.MyDocuments,
                  Environment.SpecialFolder.MyMusic,
                  Environment.SpecialFolder.MyPictures,
                  Environment.SpecialFolder.MyVideos,
                  Environment.SpecialFolder.NetworkShortcuts,
                  Environment.SpecialFolder.Personal,
            };
            var sf = specialFolders
                .Select(Environment.GetFolderPath)
                .ToArray();

            var cplFile = Directory.GetFiles(@"c:\windows\system32", "*.cpl").First();
            var version = FileVersionInfo.GetVersionInfo(cplFile);
            var p = Process.GetProcesses().FirstOrDefault(x => x.ProcessName.Contains("easy"));

            var handle = WindowHelper.FindWindow(
                "Shell_TrayWnd",
                "TrayNotifyWnd",
                "SysPager",
                "ToolbarWindow32");
            var hWnd = User32.FindWindow("Shell_TrayWnd", null);
            hWnd = User32.FindWindowEx(hWnd, IntPtr.Zero, "TrayNotifyWnd", null);
            var icon1 = IconLoader.GetHandle(@"c:\temp\test");
            var icon2 = IconLoader.GetHandle(@"c:\temp\test2");

        }
    }
}
