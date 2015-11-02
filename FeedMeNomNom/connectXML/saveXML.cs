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

        public void XMLupdate(int _check, string _name, string _url, string _title)
        {

            XElement doc = XElement.Load("Tushar.xml");

            XElement element = new XElement(("item"),
                new XElement("name", _name),
                new XElement("url", _url),
                new XElement("checked", _check));

            IEnumerable<XElement> items =
                     from ele in doc.Descendants("titleFeed")
                     where (string)ele.Attribute("name") == _title
                     select ele;

            items.First().Add(element);

            Console.WriteLine("Update successful");

            doc.Save("Tushar.xml");

            Console.WriteLine("Saved new information to XML");

            //Kanske lägga till en extra XML fil som läser pod och Activated? eller?
        }


        public void createTitleFeed(string name, string interval, string url, string category) {

            XElement doc = XElement.Load("Tushar.xml");

            XElement element = new XElement(("titleFeed"),
                new XAttribute("name", name),
                new XAttribute("url", url),
                new XAttribute("interval", interval));

            IEnumerable<XElement> items =
                from ele in doc.Elements("category")
                where (string)ele.Attribute("name") == category
                select ele;

            items.First().Add(element);

            Console.WriteLine("Updated XML!");

            doc.Save("Tushar.xml");
        
        }

    }
}
