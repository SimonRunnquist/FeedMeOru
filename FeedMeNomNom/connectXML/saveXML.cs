﻿using System;
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
        public void XMLsave(int _id, string _name, string _url, string _category) {
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
                new XElement("feed"),
                new XAttribute("ID", _id),
                new XElement("feedname", _name),
                new XElement("url", _url)); 
            
            addFeed.Save("feedXml.xml");

            //Kanske lägga till en extra XML fil som läser pod och Activated? eller?

            
        }

        public void createBaseXml() {
            XmlWriter feedWriter = XmlWriter.Create("MackanXml.xml");

            feedWriter.WriteStartDocument();
            feedWriter.WriteStartElement("RSSfeed");
            feedWriter.WriteStartElement("feeds");

            feedWriter.WriteEndElement();
            feedWriter.WriteEndDocument();
            feedWriter.Close();

        }


    }
}
