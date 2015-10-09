using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.ServiceModel.Syndication;
using FeedMeNomNom.DAO;
using FeedMeNomNom.BUS;
using FeedMeNomNom.connectXML;

namespace FeedMeNomNom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        getFeed test = new getFeed();
        addItem getItem = new addItem();
        saveXML createXml = new saveXML();
        string[] podcast;
        string[] downloadURL;

        public MainWindow()
        {
            InitializeComponent();
            createXml.createBaseXml();
        }

      

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            test.downloadMP3();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            test.Name = "Mac!";
            tbURL.Text = test.Name;
        }

        private void getFeed_button_Click(object sender, RoutedEventArgs e)
        {
            listBox_Feed.Items.Clear();
            podcast = test.getPod(tbURL.Text);
            downloadURL = test.getDownloadURL();

            //for (var i = 0; i < 20; i++) {
              //  listBox_Feed.Items.Add(test.getPod(tb);
            //}


            for (var i = 0; i < podcast.Length; i++)
            {
                if (podcast[i] == null)
                {
                    break;
                }
                else
                {
                    listBox_Feed.Items.Add(podcast[i]);
                    listBox_Feed.Items.Add(downloadURL[i]);
                    listBox_Feed.Items.Add(" ");
                }
            }

            test.wipeCollectedData();
        }

        

       


    }
}
