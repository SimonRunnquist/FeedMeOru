using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedMeNomNom.VO
{
    class UserVO
    {
        private int _id;
        private string _feedName;
        private string _podcast;
        private string _category;
        private int _interval;
        private string _url;
        private bool _activated;
        private string _downloadPodName;
        private string _downloadFilename;
        private string _downloadUrl;

        public int id {
            get {
                return _id;
            }

            set {
                _id = value;
            }
        }

        public int interval
        {
            get
            {
                return _interval;
            }

            set
            {
                _interval = value;
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

        public string podcast
        {
            get
            {
                return _podcast;
            }

            set
            {
                _podcast = value;
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

        public bool activated
        {
            get
            {
                return _activated;
            }

            set
            {
                _activated = value;
            }
        }

        public string downloadPodName
        {
            get
            {
                return _downloadPodName;
            }

            set
            {
                _downloadPodName = value;
            }
        }

        public string downloadFilename
        {
            get
            {
                return _downloadFilename;
            }

            set
            {
                _downloadFilename = value;
            }
        }

        public string downloadUrl
        {
            get
            {
                return _downloadUrl;
            }

            set
            {
                _downloadUrl = value;
            }
        }
    }
}
