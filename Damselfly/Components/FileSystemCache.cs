using System.IO;
using BoolCache = Components.ArgLockingMemoizer<string, bool>;

namespace Damselfly.Components
{

    public class FileSystemCache
    {
        private static readonly BoolCache
            _fileExistsCache = PathCache.Create<bool>(),
            _dirExistsCache = PathCache.Create<bool>();

        public static bool FileExists(string filename) =>
            _fileExistsCache.Call(File.Exists, filename);

        public static bool DirectoryExists(string filename) =>
            _dirExistsCache.Call(Directory.Exists, filename);
    }
}
