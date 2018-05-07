namespace Damselfly.Components {
    
    
    public partial class WindowsPath {
        
        private static SearchDelegate _Search;
        
        public static SearchDelegate Search {
            get {
                return WindowsPath._Search;
            }
            set {
                WindowsPath._Search = value;
            }
        }
        
        public delegate string SearchDelegate(string path);
    }
}


namespace Damselfly.Components {
    
    
    public partial class WindowsPath {
        
        private static PrepareFilenameDelegate _PrepareFilename;
        
        public static PrepareFilenameDelegate PrepareFilename {
            get {
                return WindowsPath._PrepareFilename;
            }
            set {
                WindowsPath._PrepareFilename = value;
            }
        }
        
        public delegate string PrepareFilenameDelegate(string cmd);
    }
}
