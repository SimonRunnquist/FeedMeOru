using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using FeedMeNomNom.VO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FeedMeNomNom.connectXML
{
    class saveXML
    {
        
        public void XMLupdate(int _id, string _name, string _url, string _category) {
            //categoryVO xmlInfo = new categoryVO();
            //string pod = xmlInfo.podcast;
            //string category = xmlInfo.category;
            //int interval = xmlInfo.interval;
            //bool activated = xmlInfo.activated;

            XDocument addFeed = XDocument.Load("feedXml.xml");
            XElement root = addFeed.Element("RSSfeed");
            IEnumerable<XElement> rows = root.Descendants("feeds");
            XElement firstRow = rows.First();
            firstRow.AddBeforeSelf(
                new XElement("Feed"),
                new XAttribute("ID", _id),
                new XElement("feedname", _name),
                new XElement("url", _url)); 
            addFeed.Save("feedXml.xml");

            //Kanske lägga till en extra XML fil som läser pod och Activated? eller?

            
        }

        public void createBaseXml() {
            XmlWriter feedWriter = XmlWriter.Create("SupXml.xml");

            feedWriter.WriteStartDocument();
            feedWriter.WriteStartElement("RSSfeed");
            feedWriter.WriteStartElement("feeds", "Tjena");

            feedWriter.WriteEndElement();
            feedWriter.WriteEndDocument();
            feedWriter.Close();

           // XmlSerializer SerializerObj = new XmlSerializer(typeof(categoryVO));
        }

        //public void saveXML(string filename) {
        //    using (FileStream stream = new FileStream(filename, FileMode.Create)) {
        //        var XML = new XmlSerializer(typeof(itemVO));
        //        XML.Serialize(stream, this);
        //    }
        //}


    }
}
