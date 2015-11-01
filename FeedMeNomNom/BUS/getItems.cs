using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedMeNomNom.VO;
using System.Xml;
using System.ServiceModel.Syndication;

namespace FeedMeNomNom.BUS

{
    class getItems
    {
        
        List<itemVO> podList = new List<itemVO>();

        public List<itemVO> createFeed(string url) 
        {
            if (Validate.validate.useInternal(url) && Validate.validate.checkEmpty(url))
            {
                try
                {
                    using (XmlReader reader = XmlReader.Create(url)) //If null måste fixas, blir fel vid tomt eller felaktigt fält
                    {
                        var i = 0;
                        SyndicationFeed feed = SyndicationFeed.Load(reader);
                        //Console.WriteLine(feed.Title.Text);
                        //Console.WriteLine(feed.Links[0].Uri); 


                        foreach (SyndicationItem item in feed.Items)
                        {
                            itemVO singlePod = new itemVO();
                            singlePod.feedName = item.Title.Text;
                            singlePod.id = i;

                            foreach (var link in item.Links)
                            {
                                singlePod.url = link.Uri.ToString();
                                Console.WriteLine(singlePod.url);
                            }



                            podList.Add(singlePod);
                            Console.WriteLine(podList[i].feedName + " " + podList[i].id);
                            i++;
                            /* foreach (var link in item.Links) {
                                 Console.WriteLine(link.Uri);
                             }*/
                        }
                    }

                }
                catch (Exception e)
                {
                    var checkProblem = e.Message;
                    Console.WriteLine(checkProblem);
                }
            }

            
            return podList;
        }

        public string getInfo(string name) {
            string downloadURL = "";
            for (var i = 0; i < podList.Count; i++) {
                if (podList[i].feedName.Equals(name))
                {
                    downloadURL = podList[i].url;
                }
            }
            return downloadURL;
        }
    }
}
