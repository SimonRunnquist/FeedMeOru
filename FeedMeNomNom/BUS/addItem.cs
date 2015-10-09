using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;

namespace FeedMeNomNom.BUS
{
    class addItem
    {
        private string _podcast;
        private int _length;
        private string _downloadLink;

        public void getFeeditem(string userURL)
        {

            //string url = "http://news.google.fr/nwshp?hl=fr&tab=wn&output=rss";
            //http://alexosigge.libsyn.com//rss
            //http://hannahoamanda.libsyn.com/rss


            string getURL = userURL;
            using (XmlReader reader = XmlReader.Create(getURL)) //If null måste fixas, blir fel vid tomt eller felaktigt fält
            {


                SyndicationFeed feed = SyndicationFeed.Load(reader);
                //Console.WriteLine(feed.Title.Text);
                //Console.WriteLine(feed.Links[0].Uri);


                foreach (SyndicationItem item in feed.Items)
                {

                    Console.WriteLine(item.Title.Text);
                    foreach (var link in item.Links)
                    {
                        Console.WriteLine(link.Uri);
                    }
                }

            }
        }

        public string podcast {
            get 
            { 
                return _podcast;
            }
            
            set 
            { 
                _podcast = value;
            }
        }

        public int length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
            }
        }

        public string downloadLink
        {
            get
            {
                return _downloadLink;
            }
            set
            {
                _downloadLink = value;
            }
        }


        public string getPod { get; set; }
    }
}
