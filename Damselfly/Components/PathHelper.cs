using System.IO;
using System.Reflection;

namespace Damselfly.Components
{
    public static class PathHelper
    {
        public static string GetExecutingPath(string file)
        {
            var l = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.Combine(l, file);
        }
    }
}
