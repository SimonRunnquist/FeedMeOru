using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.ServiceModel.Syndication;
using System.Net;
using System.IO;
using FeedMeNomNom.VO;

namespace FeedMeNomNom.DAO
{
    class getFeed
    {
        UserVO listObjectVO = new UserVO();
        private string name;
        string[] feedArray = new string[200];
        string[] unfilteredURL = new string[400];
        string[] filteredURL = new string[200];
        
        public string[] getPod(string userURL) {
            //string url = "http://news.google.fr/nwshp?hl=fr&tab=wn&output=rss";
            //http://alexosigge.libsyn.com//rss
            //http://hannahoamanda.libsyn.com/rss


            

            string getURL = userURL;
            using (XmlReader reader = XmlReader.Create(getURL)) //If null måste fixas, blir fel vid tomt eller felaktigt fält
            {
                var i = 0;
                    

                SyndicationFeed feed = SyndicationFeed.Load(reader);
                //Console.WriteLine(feed.Title.Text);
                //Console.WriteLine(feed.Links[0].Uri);

                
                foreach (SyndicationItem item in feed.Items)
                {
                        
                        feedArray[i] = item.Title.Text;

                         foreach (var link in item.Links)
                            {
                                unfilteredURL[i] = link.Uri.ToString();
                            }
                        i++;

                   /* foreach (var link in item.Links) {
                        Console.WriteLine(link.Uri);
                    }*/
                }

                return feedArray;

            }
        }

        public string[] getDownloadURL() {

            for (var i = 0; i < unfilteredURL.Length; i++) {
                string getArrayURL = unfilteredURL[i];
                Console.WriteLine(getArrayURL);

                if (getArrayURL == null) {
                    break;
                }

                else if (getArrayURL.Contains("mp3"))
                {
                    filteredURL[i] = getArrayURL;
                }
            }
                return filteredURL;
        
        }

        public void downloadMP3() {
            
            
            using (var client = new WebClient())
            {
                Console.WriteLine("Downloading...");
                client.DownloadFile("http://traffic.libsyn.com/alexosigge/aosavsnitt175.mp3", "190.mp3");
                Console.WriteLine("Done!");
            }
        }

        public string Name {

            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public void wipeCollectedData() {
            wipeFilteredData();
            wipeFeedData();
            wipeUnfilteredData();
        }

        public void wipeFeedData() {
            for (var i = 0; i < 200; i++)
                feedArray[i] = null;
        }

        public void wipeUnfilteredData()
        {
            for (var i = 0; i < 400; i++)
                unfilteredURL[i] = null;
        }
        public void wipeFilteredData()
        {
            for (var i = 0; i < 200; i++)
                filteredURL[i] = null;
        }
    }
}
