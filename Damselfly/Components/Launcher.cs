using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Damselfly.Components
{
    public static class Launcher
    {
        private static string
            _elevate = PathHelper.GetExecutingPath("Elevate.exe"),
            _run = PathHelper.GetExecutingPath("Run.exe");

        public static void Launch(string command, bool asAdmin)
        {
            var launcher = asAdmin ? _elevate : _run;
            var args = WindowsPath.PrepareFilename(command);

            using (var p = StandardUserProcess.Start(launcher, args))
            {
                p.WaitForExit();

                int exitCode;

                while ((exitCode = p.GetExitCode()) == 259)
                {
                    Thread.Sleep(1);
                }

                if (exitCode != 0)
                {
                    throw new Win32Exception(
                        string.Format(
                            "Error running command {0}, exit code: 0x{1:X8}",
                            args,
                            exitCode));
                }
            }
        }
    }
}
