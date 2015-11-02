using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using FeedMeNomNom.VO;
using FeedMeNomNom.connectXML;

namespace FeedMeNomNom.BUS
{
    class intervalUpdate
    {
        public string url { get; set; }
        public string title { get; set; }


        getItems checkItems = new getItems();
        List<itemVO> items = new List<itemVO>();
        readXML readxml = new readXML();
        
        public void createTimer(int ival) {

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(Update);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            Console.WriteLine("Timer started");
            dispatcherTimer.Start();
            Console.WriteLine("check Timer");
            
        }

        public void Update(object sender, EventArgs e){
            try
            {
                Console.WriteLine("Checking feed");
                items = checkItems.createFeed(url);
                int countXMLList = readxml.getFeedCount(title);
                int diff = items.Count - countXMLList;

                Console.WriteLine("diff: " + diff);

                if (items.Count > countXMLList)
                {
                    Console.WriteLine("Updating XML");
                    checkItems.updateExistingFeed(title, diff);
                    items.Clear();
                    countXMLList = 0;
                }

                else {
                    Console.WriteLine("finns inga nya feeds");
                }

            }
            catch (Exception exc) { 
            
            }
        }

        public void saveNewToXML(string name, string url){ 
        
        }


    }
}
