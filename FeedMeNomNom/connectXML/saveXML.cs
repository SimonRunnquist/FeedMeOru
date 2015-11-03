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
            try
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

                doc.Save("Tushar.xml");
            }
            catch (Exception er)
            {
                string error = er.Message;
                Console.WriteLine(error);
            }

        }

        //Skapar 
        public void createTitleFeed(string name, string interval, string url, string category) {
            try
            {
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

            catch (Exception er)
            {
                string error = er.Message;
                Console.WriteLine(error);
            }
        }

        //Redigerar check för en specifik pod
        public void editChecked(string url)
        {
            try
            {
                XElement doc = XElement.Load("Tushar.xml");
                IEnumerable<XElement> getChildName =
                    from el in doc.Descendants("item")
                    where (string)el.Element("url").Value == url
                    select el;
                getChildName.First().Element("checked").SetValue("1");
                doc.Save("Tushar.xml");
            }

            catch (Exception er)
            {
                string error = er.Message;
                Console.WriteLine(error);
            }

        }

        public void editUrl(string name, string newURL)
        {
            try
            {
                XElement doc = XElement.Load("Tushar.xml");
                IEnumerable<XElement> getChildName =
                    from el in doc.Descendants("item")
                    where (string)el.Element("name").Value == name
                    select el;
                getChildName.First().Element("url").SetValue(newURL);
                doc.Save("Tushar.xml");
            }

            catch (Exception er)
            {
                string error = er.Message;
                Console.WriteLine(error);
            }

        }

        public void editName(string name, string newName)
        {
            try
            {
                XElement doc = XElement.Load("Tushar.xml");
                IEnumerable<XElement> getChildName =
                    from el in doc.Descendants("item")
                    where (string)el.Element("name").Value == name
                    select el;
                getChildName.First().Element("name").SetValue(newName);
                doc.Save("Tushar.xml");
            }

            catch (Exception er)
            {
                string error = er.Message;
                Console.WriteLine(error);
            }

        }

    }
}
