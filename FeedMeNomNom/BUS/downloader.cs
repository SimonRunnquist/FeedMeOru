using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FeedMeNomNom.VO;

namespace FeedMeNomNom.BUS
{
    class downloader
    {
        string url;
        string podName;
        string filename;

        public void userDownload() {

            itemVO dest = new itemVO();
            //string url = dest.downloadUrl;
            //string podName = dest.downloadPodName;
            //string file = dest.downloadFilename;

            using (var client = new WebClient())
            {
                Console.WriteLine("Downloading...");
                //client.DownloadFile("http://traffic.libsyn.com/alexosigge/aosavsnitt175.mp3", "190.mp3");

                client.DownloadFile(url,@"..\..\RSS\" + podName + @"\"+ file);
                Console.WriteLine("Done!");
            }
        }

        
    }
}
