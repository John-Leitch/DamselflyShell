using System;
using System.Linq;
using System.Diagnostics;
using System.IO;

namespace Damselfly.Components
{
    public static class Scripts
    {
        public static void Init()
        {
            return;
#if !DEBUG
            
            var aphid = PathHelper.GetExecutingPath(
                    Environment.Is64BitProcess ?
                        "Aphid64.exe" :
                        "Aphid.exe");

            if (!File.Exists(aphid))
            {
                aphid = PathHelper.GetExecutingPath("Aphid.exe");                
            }


            foreach (var p in new[] { "*.exe", "*.dll" }
                .SelectMany(x => Directory.GetFiles(Path.GetDirectoryName(aphid), x))
                .Select(x =>
                    Process.Start(
                        new ProcessStartInfo(
                            PathHelper.GetExecutingPath("Ngen.exe"),
                            x)
                            {
                                UseShellExecute = false,
                                //WindowStyle = ProcessWindowStyle.Hidden,
                                //CreateNoWindow = true
                                WindowStyle = ProcessWindowStyle.Normal,
                                CreateNoWindow = false,
                            }))
                .ToArray())
            {
                //p.WaitForExit();
            }
#endif
        }
    }
}
