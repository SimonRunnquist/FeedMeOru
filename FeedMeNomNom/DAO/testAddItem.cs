using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedMeNomNom.VO;
using System.Xml;
using System.ServiceModel.Syndication;

namespace FeedMeNomNom.DAO
{
    class testAddItem
    {
        List<itemVO> podList = new List<itemVO>();
        itemVO singlePod = new itemVO();

        public List<itemVO> createFeed(string url) {

            using (XmlReader reader = XmlReader.Create(url)) //If null måste fixas, blir fel vid tomt eller felaktigt fält
            {
                var i = 0;


                SyndicationFeed feed = SyndicationFeed.Load(reader);
                //Console.WriteLine(feed.Title.Text);
                //Console.WriteLine(feed.Links[0].Uri); 


                foreach (SyndicationItem item in feed.Items)
                {

                    singlePod.feedName = item.Title.Text;
                    singlePod.id = i;

                    foreach (var link in item.Links)
                    {
                        singlePod.url = link.Uri.ToString();
                    }
                    

                    
                    podList.Add(singlePod);
                    Console.WriteLine(podList[i].feedName + " " + podList[i].url);
                    i++;
                    /* foreach (var link in item.Links) {
                         Console.WriteLine(link.Uri);
                     }*/
                }
                Console.WriteLine(podList[60].feedName + " " + podList[45].url);
                return podList;

            }

        
        }
    }
}
