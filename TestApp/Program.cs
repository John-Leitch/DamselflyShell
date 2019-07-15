using Components.Aphid.Interpreter;
using Components.Aphid.TypeSystem;
using Components.IO;
using Components.PInvoke;
using Damselfly.Components;
using Damselfly.Components.Naming;
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

    internal class Program
    {
        //private static void IconTest(string path)
        //{
        //    var png = PathHelper.GetExecutingPath(
        //        path
        //            .Replace(':', '$')
        //            .Replace('\\', '$') +
        //        ".png");

        //    var handle = IconLoader.LoadSource(path);
        //    var source = IconLoader.LoadSource(handle);
        //    var encoder = new PngBitmapEncoder();
        //    encoder.Frames.Add(BitmapFrame.Create(source));

        //    using (var f = File.Create(png))
        //    {
        //        encoder.Save(f);
        //    }

        //    var p = Process.Start(png);
        //}

        private static void Main(string[] args)
        {
            var strat = new FrequencyStrategy();

            var results = Directory.EnumerateFiles(@"c:\source", "*", SearchOption.AllDirectories)
                .SelectMany(x => strat.Call(x))
                .OrderByDescending(x => x.Weight)
                .ToArray();

            //var cli = TestNs.AphidCompilerResources.Library_Cli();
            var shares = NetworkShares.GetShares("Node2");


            Scripts.Init();
            var commands = new[]
            {
                @"c:\Program Files\Notepad++\notepad++.exe c:\Program Files\Notepad++\contextMenu.xml",
                "test.txt",
                "",
                @"c:\source",
                @"c:\source\test.cmd",
                @"c:\Program Files (x86)\Atmel",
                @"c:\Program Files (x86)\Deluge\_ctypes.pyd"
            }.Select(x => WindowsPath.PrepareFilename(x)).ToArray();
            var p2 = Process.Start(new ProcessStartInfo("cmd.exe", @"/k cd c:\source") { Verb = "runas" });
            //var proc = StandardUserProcess.Start(@"c:\windows\system32\cmd.exe", @"/k cd c:\source");
            //return;


            //Kernel32.CloseHandle(proc);

            //Kernel32.OpenProcess(ProcessAccessFlags.DuplicateHandle

            //IconTest(@"c:\windows\system32\cmd.exe");
            //IconTest(@"c:\users\john\Documents");
            //IconTest(@"C:\Users\John\Downloads");

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
            //var icon1 = IconLoader.GetHandle(@"c:\temp\test");
            //var icon2 = IconLoader.GetHandle(@"c:\temp\test2");

        }
    }
}
