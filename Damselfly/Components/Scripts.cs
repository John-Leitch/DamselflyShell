using Components.Aphid.Interpreter;
using Components.Aphid.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
