using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using FeedMeNomNom.VO;
using FeedMeNomNom.BUS;

namespace FeedMeNomNom.connectXML
{
    class readXML
    {
        List<String> getNames = new List<string>();
        List<String> getChilds = new List<string>();

        public List<String> readXMLDoc()
        {
            getNames.Clear();
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
                }

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

        public void getAllFeeds()
        {

            intervalUpdate inter = new intervalUpdate();

            string name;
            string url;
            string interval;

            XElement doc = XElement.Load("Tushar.xml");

            IEnumerable<XElement> feeds =
                from ele in doc.Descendants("titleFeed")
                select ele;


            foreach (XElement el in feeds)
            {
                name = el.Attributes("name").Single().Value.ToString();
                url = el.Attributes("url").Single().Value.ToString();
                interval = el.Attributes("interval").Single().Value.ToString();

                inter.url = url;
                inter.title = name;
                inter.createTimer(Int32.Parse(interval));


            }
        }

        public List<String> getCategoryFeeds(string category)
        {
            List<string> listFeed = new List<string>();

            try
            {
                XElement po = XElement.Load("Tushar.xml");
                IEnumerable<XElement> childElements =
                    from el in po.Elements("category")
                    where (string)el.Attribute("name") == category
                    select el;
                
                foreach (XElement ele in childElements.Nodes())
                {
                    listFeed.Add(ele.Attribute("name").Value);

                }
                for (var i = 0; i < listFeed.Count; i++)
                {
                    if (listFeed[i] == null)
                    {
                        Console.WriteLine("The list equals null");
                        break;
                    }
                }

            }

            catch (Exception e)
            {
                var hej = e.Message;
                Console.WriteLine(hej);

            }

            return listFeed;
        }


        public List<String> getCategoryPodName(string feed)
        {
            List<string> listFeed = new List<string>();
            Console.WriteLine(feed);

            try
            {
                XElement po = XElement.Load("Tushar.xml");
                IEnumerable<XElement> childElements =
                    from el in po.Descendants("titleFeed")
                    where (string)el.Attribute("name") == feed
                    select el;
                foreach (XElement ele in childElements.Nodes())
                {
                    listFeed.Add(ele.Element("name").Value);
                }
                for (var i = 0; i < listFeed.Count; i++)
                {
                    if (listFeed[i] == null)
                    {
                        Console.WriteLine("The list equals null");
                        break;
                    }
                 }
                
            }

            catch (Exception e)
            {
                var hej = e.Message;
                Console.WriteLine(hej);

            }
            return listFeed;
        }

            
        //Hämtar den enskilda poddens information
        //Namn, URL och checked

        public string getCategoryPodName(string pod, string type)
        {
            
            List<string> podInfo = new List<string>();
            string name = "";
            try
            {
                XElement doc = XElement.Load("Tushar.xml");
                IEnumerable<XElement> getChildName =
                    from el in doc.Descendants("item")
                    where (string)el.Element("name").Value == pod
                    select el;
                    name = getChildName.First().Element(type).Value;
             }

            catch (Exception er) {
                string error = er.Message;
                Console.WriteLine(error);
            }

            return name;
        }

        
            

            
        

        
    }
}
