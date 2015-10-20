using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedMeNomNom.VO
{
    class categoryVO
    {
        private int _podID;
        private string _podName;
        private string _podURL;
        private string _category;

        public int podID
        {
            get
            {
                return _podID;
            }

            set
            {
                _podID = value;
            }
        }

        public string podName
        {
            get
            {
                return _podName;
            }

            set
            {
                _podName = value;
            }
        }

        public string podURL
        {
            get
            {
                return _podURL;
            }

            set
            {
                _podURL = value;
            }
        }

        public string category
        {
            get
            {
                return _category;
            }

            set
            {
                _category = value;
            }
        }
    }

    
}
