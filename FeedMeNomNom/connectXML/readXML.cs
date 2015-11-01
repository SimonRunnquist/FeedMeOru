using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using FeedMeNomNom.VO;

namespace FeedMeNomNom.connectXML
{
    class readXML
    {
        List<String> getNames = new List<string>();
        List<String> getChilds = new List<string>();
        public List<String> readXMLDoc()
        {
            try
            {
                XElement po = XElement.Load("Tushar.xml");
                IEnumerable<XElement> childElements =
                    from el in po.Elements()
                    select el;

                foreach (XElement el in childElements)
                {
                    getNames.Add(el.FirstAttribute.Value);

                }
                for (var i = 0; i < getNames.Count; i++) {
                    if (getNames[i] == null) 
                    {
                        break;
                    }
                    else
                    {
                    Console.WriteLine(getNames[i]);
                    }
                }

                    Console.WriteLine(getNames);
            }

            catch (Exception e) {
                var hej = e.Message;
                Console.WriteLine(hej);
               
            }

            return getNames;
        }

        public int getFeedCount(string podname) { 
            

            XElement doc = XElement.Load("Tushar.xml");

            IEnumerable<XElement> items =
                     from ele in doc.Descendants("titleFeed")
                     where (string)ele.Attribute("name") == podname
                     select ele;

            Console.WriteLine(items.Elements("item").Count());
            return items.Elements("item").Count();
        }

        
    }
}
