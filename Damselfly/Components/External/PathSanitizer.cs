using System.IO;
using System.Linq;

namespace Components
{
    public static class PathSanitizer
    {
        public static string SanitizePath(string name, char c) => Path
            .GetInvalidPathChars()
            .Aggregate(name, (a, x) => a.Replace(x, c))
            .Replace(':', c)
            .Replace('\\', c)
            .Replace('/', c);

        public static string SanitizeName(string name, char c) => Path
            .GetInvalidFileNameChars()
            .Aggregate(name, (a, x) => a.Replace(x, c));

        public static string SanitizeName(string name) => SanitizeName(name, '_');

        public static string SanitizePath(string name) => SanitizePath(name, '_');
    }
}
