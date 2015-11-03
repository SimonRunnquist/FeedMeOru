using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedMeNomNom.BUS.welcome
{
    abstract class welcomeText
    {
        //Ger ett strängvärde
        public virtual string text
        {
            get{ return "Hello Dear User!"; }
        }
     }
}
