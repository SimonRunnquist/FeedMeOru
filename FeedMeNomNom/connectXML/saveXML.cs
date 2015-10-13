using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using FeedMeNomNom.VO;
using System.Xml.Linq;

namespace FeedMeNomNom.connectXML
{
    class saveXML
    {
        public void XMLsave() {
            itemVO xmlInfo = new itemVO();

            int id = xmlInfo.id; 
            string name = xmlInfo.feedName;
            //string pod = xmlInfo.podcast;
            //string category = xmlInfo.category;
            //int interval = xmlInfo.interval;
            string url = xmlInfo.url;
            //bool activated = xmlInfo.activated;

            XDocument addFeed = XDocument.Load("feedXml.xml");
            XElement root = addFeed.Element("RSSfeed");
            IEnumerable<XElement> rows = root.Descendants("feeds");
            XElement firstRow = rows.First();
            firstRow.AddBeforeSelf(
                new XElement("feed"),
                new XAttribute("ID", id),
                new XElement("feedname", name),
                new XElement("url", url)); 
            
            addFeed.Save("feedXml.xml");

            //Kanske lägga till en extra XML fil som läser pod och Activated? eller?

            
        }

        public void createBaseXml() {
            XmlWriter feedWriter = XmlWriter.Create("feedXml.xml");

            feedWriter.WriteStartDocument();
            feedWriter.WriteStartElement("RSSfeed");
            feedWriter.WriteStartElement("feeds");

            feedWriter.WriteEndElement();
            feedWriter.WriteEndDocument();
            feedWriter.Close();

        }


    }
}
