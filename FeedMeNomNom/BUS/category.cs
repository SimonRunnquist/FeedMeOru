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
        
        

       

        public void createNewCategory(string categoryName) //Skall testas med validate
        {
            XElement doc = XElement.Load("Tushar.xml");
            doc.Add(new XElement("category",
                new XAttribute("name", categoryName)));
            Console.WriteLine(doc);
            doc.Save("Tushar.xml");
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

            
        }

        public void deleteCategory(string name) {

            XElement doc = XElement.Load("Tushar.xml");

            IEnumerable<XElement> categoryDelete =
                from el in doc.Elements("category")
                where (string)el.Attribute("name") == name
                select el;
            foreach (XElement ele in categoryDelete)
            {
                categoryDelete.FirstOrDefault().Remove();
            }
            doc.Save("Tushar.xml");
        }

        public void editCategory(string name, string newName) {
            XElement doc = XElement.Load("Tushar.xml");

            IEnumerable<XElement> categoryEdit =
                 from el in doc.Elements("category")
                 where (string)el.Attribute("name") == name
                 select el;
            //foreach (XElement ele in categoryEdit) {
                categoryEdit.FirstOrDefault().SetAttributeValue("name", newName);
                
                
            //}

            doc.Save("Tushar.xml");
            
            Console.WriteLine(categoryEdit.Count());
            Console.WriteLine("Changed name from " + name + " to " + newName);
        
        }
            

    }




}
