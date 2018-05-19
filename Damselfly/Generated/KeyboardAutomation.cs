namespace Damselfly.Components {
    
    
    public partial class KeyboardAutomation {
        
        private static TypeDelegate _Type;
        
        public static TypeDelegate Type {
            get {
                return KeyboardAutomation._Type;
            }
            set {
                KeyboardAutomation._Type = value;
            }
        }
        
        public delegate void TypeDelegate(string text);
    }
}
