using System;
using System.Xml.Linq;

namespace Patterns.AMB
{
    public class Movie : NetflixEntity
    {
        public string Url { get; set; }

        public string BoxArtSmallUrl { get; set; }

        public override void LoadFromXML(XElement entry)
        {
            base.LoadFromXML(entry);

            var properties = entry
                .Element(ODataXML.mName("properties"));
            Url = properties
                .Element(ODataXML.dName("Url")).Value;
            BoxArtSmallUrl = properties
                .Element(ODataXML.dName("BoxArt"))
                .Element(ODataXML.dName("SmallUrl"))
                .Value;
        }
    }
}
