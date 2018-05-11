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
            var interpreter = new AphidInterpreter();
            interpreter.Loader.SearchPaths.Add(PathHelper.GetExecutingPath("Components"));
            var file = PathHelper.GetExecutingPath(@"Components\Scripts.alx");
            var code = File.ReadAllText(file);
            var aphid = PathHelper.GetExecutingPath("Aphid.exe");

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

            if (!Debugger.IsAttached)
            {
                AphidCli.TryAction(
                    interpreter,
                    code,
                    () => interpreter.InterpretFile(file));
            }
            else
            {
                interpreter.InterpretFile(file);
            }
        }
    }
}
