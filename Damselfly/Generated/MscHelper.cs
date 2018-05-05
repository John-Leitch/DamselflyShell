namespace Damselfly.Components {
    
    
    public partial class MscHelper {
        
        private static GetNameDelegate _GetName;
        
        public static GetNameDelegate GetName {
            get {
                return MscHelper._GetName;
            }
            set {
                MscHelper._GetName = value;
            }
        }
        
        public delegate string GetNameDelegate(string file);
    }
}
