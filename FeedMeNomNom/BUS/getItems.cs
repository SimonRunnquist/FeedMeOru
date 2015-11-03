using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedMeNomNom.VO;
using System.Xml;
using System.ServiceModel.Syndication;
using FeedMeNomNom.connectXML;

namespace FeedMeNomNom.BUS

{
    class getItems
    {
        
        List<itemVO> podList = new List<itemVO>();
        saveXML savexml = new saveXML();


        public List<itemVO> createFeed(string url) 
        {
            podList.Clear();
            if (Validate.validate.useInternal(url) && Validate.validate.checkEmpty(url))
            {
                try
                {
                    using (XmlReader reader = XmlReader.Create(url)) //If null måste fixas, blir fel vid tomt eller felaktigt fält
                    {
                        var i = 0;
                        SyndicationFeed feed = SyndicationFeed.Load(reader);
                        


                        foreach (SyndicationItem item in feed.Items)
                        {
                            itemVO singlePod = new itemVO();
                            singlePod.feedName = item.Title.Text;
                            singlePod.id = i;

                            foreach (var link in item.Links)
                            {
                                singlePod.url = link.Uri.ToString();
                            }
                            podList.Add(singlePod);
                            i++;
                            
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

        public void updateExistingFeed(string title, int count) {
            for (var i = 0; i < count; i++ )
            {
                Console.WriteLine(podList[i].feedName + " " + podList[i].url);
                savexml.XMLupdate(0, podList[i].feedName, podList[i].url, title);
            }
        }
    }
}
