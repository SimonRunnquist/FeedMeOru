using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedMeNomNom.VO;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Linq;


namespace FeedMeNomNom.BUS
{
    class category
    {
        List<categoryVO> cat = new List<categoryVO>();

        public static category Load()
        {
            category ret;
            if (System.IO.File.Exists("category.XML"))
            {

                var xml = new System.Xml.Serialization.XmlSerializer(typeof(category));
                using (var s = System.IO.File.Open("category.XML", System.IO.FileMode.Open))
                {
                    ret = xml.Deserialize(s) as category;
                    s.Flush();
                    s.Close();
                }
                return ret;
            }
            else
                return new category();
        }

        public void createNewCategory(string categoryName) //Skall testas med validate
        {
            

            //Console.WriteLine("Writing With Stream");

            //XmlSerializer serializer =
            //new XmlSerializer(typeof(categoryVO));
            //categoryVO categoryObject = new categoryVO();
            //categoryObject.category = categoryName;
            

            //// Create a FileStream to write with.
            //Stream writer = new FileStream("feedMe.xml", FileMode.Create);
            //// Serialize the object, and close the TextWriter
            //serializer.Serialize(writer, categoryObject);
            //writer.Close();


            /*
            var xmlNode =
            new XElement("category", new XAttribute("name", categoryName),
                         new XElement("titleFeed",
                             new XAttribute("interval", "500"),
                             new XAttribute("name", "Alex och Sigge"),
                             new XElement("item", 
                             new XElement("name", "brödrost"),
                             new XElement("url", "www.alexochsigge.com/brodrost"),
                             new XElement("checked", "0"))
                         )
            );
            */


            //XElement root = XElement.Load("Tushar.xml");
            //XElement newTree = new XElement("Category",
            //    new XAttribute("name", categoryName),
            //    root.Element("feed"),
            //    from att in root.Attributes()
            //        select new XElement(att.Name, (string)att)
            //);
            //root.Save("Tushar.xml");
            //Console.WriteLine(newTree);

            XElement doc = XElement.Load("Tushar.xml");
            doc.Add(new XElement("category",
                new XAttribute("name", categoryName)));
            Console.WriteLine(doc);
            doc.Save("Tushar.xml");


            //xmlNode.Save("Tushar.xml");
        }

        public void readXML() {
            XElement datXML = XElement.Load("Tushar.xml");
            Console.WriteLine(datXML.Name);
        }

        public void writeAttr() {
            XElement addFeedWithPod = new XElement("titleFeed",
                new XAttribute("interval", "500"),
                new XAttribute("name", "Amanda och hanna"),
                new XElement("item",
                    new XElement("name", "teparty"),
                    new XElement("url", "www.hannaochamanada.com"),
                    new XElement("checked", "0")
                    )
              );

            XElement doc = XElement.Load("Tushar.xml");
            IEnumerable<XElement> specificCategory =
                from el in doc.Elements("category")
                where (string)el.Attribute("name") == "hej"
                select el;

            specificCategory.Last().Add(addFeedWithPod);

            

            

            doc.Save("Tushar.xml");

            //XElement addfeed = new XElement(null,null);
        }

    }




}
