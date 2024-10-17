using System;
using System.Xml.Linq;

namespace Patterns.AMB
{
    public static class ODataXML
    {
        public static XName Name(string x) 
        { 
            return XName.Get(x, "http://www.w3.org/2005/Atom");
        }

        public static XName dName(string x)
        {
            return XName.Get(x, "http://schemas.microsoft.com/ado/2007/08/dataservices"); 
        }

        public static XName mName(string x)
        {
            return XName.Get(x, "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata");
        }
    }
}
