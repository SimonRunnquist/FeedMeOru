using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedMeNomNom.VO;


namespace FeedMeNomNom.BUS
{
    class catetogry
    {
        List<categoryVO> cat = new List<categoryVO>();

        public static catetogry Load()
        {
            catetogry ret;
            if (System.IO.File.Exists("category.XML"))
            {

                var xml = new System.Xml.Serialization.XmlSerializer(typeof(catetogry));
                using (var s = System.IO.File.Open("category.XML", System.IO.FileMode.Open))
                {
                    ret = xml.Deserialize(s) as catetogry;
                    s.Flush();
                    s.Close();
                }
                return ret;
            }
            else
                return new catetogry();
        }

        public void Save()
        {
            var xml = new System.Xml.Serialization.XmlSerializer(typeof(catetogry));
            using (var s = System.IO.File.Open("hej.xml", System.IO.FileMode.Create))
            {
                xml.Serialize(s, this);
                s.Flush();
                s.Close();
            }
        }

    }




}
