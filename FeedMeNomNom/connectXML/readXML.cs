using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FeedMeNomNom.connectXML
{
    class readXML
    {
        List<String> getNames = new List<string>();
        public void värdelös()
        {
            var sträng = "tjena";
            Console.WriteLine(sträng);
        }
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
                    //Console.WriteLine(el.FirstAttribute.Value);

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

        
    }
}
