using System.Linq;
using System.Xml.Linq;

namespace Damselfly.Components
{
    public static class MscHelper
    {
        public static string GetName(string mscFile)
        {
            var doc = XDocument.Load(mscFile);
            
            var names = doc
                .Descendants("String")
                .ToArray();

            var name = names.FirstOrDefault(x =>
                x.Attribute("Name") != null &&
                x.Attribute("Name").Value == "ApplicationTitle");

            if (name == null)
            {
                return null;
            }

            var value = names.FirstOrDefault(x =>
                x.Attribute("ID").Value == name.Attribute("ID").Value &&
                x.Attribute("Name") == null);

            if (value == null)
            {
                return null;
            }

            return value.Value;
        }
    }
}
