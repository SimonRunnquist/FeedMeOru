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

namespace FeedMeNomNom.DAO
{
    class getFeed
    {
        private string name;
        
        public void googleGet(string userURL) {
            //string url = "http://news.google.fr/nwshp?hl=fr&tab=wn&output=rss";
            //http://alexosigge.libsyn.com//rss
            //http://hannahoamanda.libsyn.com/rss

            string getURL = userURL;
            using (XmlReader reader = XmlReader.Create(getURL))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                //Console.WriteLine(feed.Title.Text);
                //Console.WriteLine(feed.Links[0].Uri);

                
                foreach (SyndicationItem item in feed.Items)
                {
                    Console.WriteLine(item.Title.Text);
                    foreach (var link in item.Links) {
                        Console.WriteLine(link.Uri);
                    }
                }

            }
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

    }
}
