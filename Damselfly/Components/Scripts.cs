using Components.Aphid.Interpreter;
using Components.Aphid.UI;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Damselfly.Components
{
    public static class Scripts
    {
        public static void Init()
        {
#if !DEBUG
            var aphid = PathHelper.GetExecutingPath("Aphid64.exe");

            if (!Debugger.IsAttached)
            {
                var si = new ProcessStartInfo(
                    aphid,
                    string.Format(
                        "tools\\ngen.alx {0}",
                        PathHelper.GetExecutingPath("Run.exe")))
                        {
                            UseShellExecute = false,
                            WindowStyle = ProcessWindowStyle.Hidden,
                            CreateNoWindow = true,
                        };

                var p = Process.Start(si);
                p.WaitForExit();
            }
#endif
        }
    }
}
