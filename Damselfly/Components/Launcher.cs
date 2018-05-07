using System.ComponentModel;
using System.Threading;

namespace Damselfly.Components
{
    public static class Launcher
    {
        private static string _run = PathHelper.GetExecutingPath("Run.exe");

        public static void Launch(string command, bool asAdmin)
        {
            var args = string.Format(
                "{0}{1}",
                asAdmin ? "-admin " : "",
                WindowsPath.PrepareFilename(command));

            using (var p = StandardUserProcess.Start(_run, args))
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
