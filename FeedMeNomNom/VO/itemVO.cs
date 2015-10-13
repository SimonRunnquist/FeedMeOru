using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedMeNomNom.VO
{
    class itemVO
    {
        private int _id;
        private string _feedName;
        private string _url;

        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string feedName
        {
            get
            {
                return _feedName;
            }

            set
            {
                _feedName = value;
            }
        }

        public string url
        {
            get
            {
                return _url;
            }

            set
            {
                _url = value;
            }
        }

        public string
    }
}
