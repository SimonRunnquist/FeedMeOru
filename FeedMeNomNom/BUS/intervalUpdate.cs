using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using FeedMeNomNom.VO;

namespace FeedMeNomNom.BUS
{
    class intervalUpdate
    {
        public int interval { get; set; }

        getItems checkItems = new getItems();
        List<itemVO> items = new List<itemVO>();
        
        public void createTimer(int ival) {

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(Update);
            dispatcherTimer.Interval = new TimeSpan(0, ival, 0);
            dispatcherTimer.Start();
        }

        public void Update(object sender, EventArgs e){
            try
            {
                //items = checkItems.createFeed("");
                //if(items.Count > ){


                //}
            }
            catch (Exception exc) { 
            
            }
        }

        public void saveNewToXML(string name, string url){ 
        
        }


    }
}
