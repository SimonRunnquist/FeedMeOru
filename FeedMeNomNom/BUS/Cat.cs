using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedMeNomNom.VO;


namespace FeedMeNomNom.BUS
{
    class Cat
    {
        List<categoryVO> cat = new List<categoryVO>();

        public static Cat Load()
        {
            Cat ret;
            if (System.IO.File.Exists("category.XML"))
            {

                var xml = new System.Xml.Serialization.XmlSerializer(typeof(Cat));
                using (var s = System.IO.File.Open("category.XML", System.IO.FileMode.Open))
                {
                    ret = xml.Deserialize(s) as Cat;
                    s.Flush();
                    s.Close();
                }
                return ret;
            }
            else
                return new Cat();
        }

        public void Save()
        {
            var xml = new System.Xml.Serialization.XmlSerializer(typeof(Cat));
            using (var s = System.IO.File.Open(@"C:\Temp\save.xml", System.IO.FileMode.Create))
            {
                xml.Serialize(s, this);
                s.Flush();
                s.Close();
            }
        }

    }




}
