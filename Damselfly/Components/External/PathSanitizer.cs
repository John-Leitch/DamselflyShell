using System.IO;

namespace Components
{
    public class PathSanitizer
    {
        public static string SanitizePath(string name, char c)
        {
            Path.GetInvalidPathChars().Iter(x => name = name.Replace(x, c));

            return name.Replace(':', c).Replace('\\', c).Replace('/', c);
        }

        public static string SanitizeName(string name, char c)
        {
            Path.GetInvalidFileNameChars().Iter(x => name = name.Replace(x, c));

            return name;
        }

        public static string SanitizeName(string name)
        {
            return SanitizeName(name, '_');
        }

        public static string SanitizePath(string name)
        {
            return SanitizePath(name, '_');
        }
    }
}
