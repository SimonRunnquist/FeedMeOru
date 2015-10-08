using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;

namespace FeedMeNomNom.data
{
    class getFeed
    {

        public void googleGet() {
            string url = "http://news.google.fr/nwshp?hl=fr&tab=wn&output=rss";
            using (XmlReader reader = XmlReader.Create(url))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                Console.WriteLine(feed.Title.Text);
                Console.WriteLine(feed.Links[0].Uri);
                foreach (SyndicationItem item in feed.Items)
                {
                    Console.WriteLine(item.Title.Text);
                }
            }
        }
    }
}
