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
