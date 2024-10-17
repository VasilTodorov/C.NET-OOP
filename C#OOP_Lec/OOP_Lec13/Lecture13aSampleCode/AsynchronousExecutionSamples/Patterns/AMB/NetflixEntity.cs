using System;
using System.Xml.Linq;

namespace Patterns.AMB
{
    public abstract class NetflixEntity
    {
        public string Title { get; set; }

        public virtual void LoadFromXML(XElement entry)
        {
            Title = entry.Element(ODataXML.Name("title")).Value;
        }
    }
}
