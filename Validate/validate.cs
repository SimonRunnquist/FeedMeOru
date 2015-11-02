using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;

namespace Validate
{
    public static class validate
    {
        internal static bool checkURL(string url) {
            bool URLcheck;

            try {
                
                XmlReader reader = XmlReader.Create(url);
                Rss20FeedFormatter formatter = new Rss20FeedFormatter();
                formatter.ReadFrom(reader);
                reader.Close();
                URLcheck = true;
            }
            catch{
                Console.WriteLine("URL är felaktig");
                URLcheck = false;
            }
            
            return URLcheck;
        }

        public static bool checkNumber(string numbers) {
            bool numberCheck;
            Regex stringCheck = new Regex(@"(?:\d*)?\d+");
            
            if(stringCheck.IsMatch(numbers)){
                
                numberCheck = true;
            }

            else{

                numberCheck = false;
                Console.WriteLine("Numret innehåller inte bara nummer");
            }

            return numberCheck;
        
        }
        public static bool checkLetters(string letters) {
            bool letterCheck;
            Regex regex = new Regex("[A-Za-z]");
            if (regex.IsMatch(letters))
            {
                letterCheck = true;
            }
            else
            {
                letterCheck = false;
                Console.WriteLine("Bokstäver stämmer inte");

            }
            return letterCheck;
        }
        public static bool checkEmpty(string ifEmpty) {

            bool checkifEmpty;

            if (!(ifEmpty.Length == 0 || ifEmpty == null))
            {
                checkifEmpty = true;

                
            }
            else
            {
                checkifEmpty = false;
                Console.WriteLine("tom");

            }
            return checkifEmpty;
        }

        public static bool useInternal(string url) {
            bool urlConfirm = checkURL(url);
            return urlConfirm;
        }

        


    }
}
