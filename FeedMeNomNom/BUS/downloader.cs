using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FeedMeNomNom.VO;
using FeedMeNomNom;

namespace FeedMeNomNom.BUS
{
    class downloader
    {
        //string url;
        private double _getPercentage;

        
        public void getURLandDownload(string podName) {

            try
            {
                itemVO dest = new itemVO();
                //string url = dest.downloadUrl;
                //string podName = dest.downloadPodName;
                //string file = dest.downloadFilename;
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(progressChanged);

                Console.WriteLine("Downloading...");
                client.DownloadFileAsync(new Uri(podName), "160.mp3");
                Console.WriteLine("Done!");

                //client.DownloadFile(podName, "192.mp3"); 

            }

            catch (Exception e) {
                var skrivutfel = e.Message;
                Console.WriteLine(skrivutfel);
            }
                
            
        }

        public void progressChanged(object sender, DownloadProgressChangedEventArgs e) {

            try
            {
                double bytesInc = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesInc / totalBytes * 100;

                percentage = int.Parse(Math.Truncate(percentage).ToString());

                getPercentage = percentage;

                Console.WriteLine(_getPercentage);
            }

            catch (Exception i) {
                Console.WriteLine(i.Message);
            }
            
            
            
            
            
        }

        

        public double getPercentage {

            get {
                return _getPercentage;
            }

            set {
                _getPercentage = value;
            }

        }

       
        

        
    }
}
