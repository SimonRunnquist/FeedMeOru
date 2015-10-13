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
using System.Drawing;
using System.Collections.Generic;

namespace FeedMeNomNom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        getFeed test = new getFeed();
        saveXML createXml = new saveXML();
        string[] podcast;
        string[] downloadURL;
        

        public MainWindow()
        {
            InitializeComponent();
            createXml.createBaseXml();
            visibilityFeedSetting(true);
        }

      

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            test.downloadMP3();
        }

        private void visibilityFeedSetting(bool setting) {
            if (setting)
            {
                downloadSelectedPod.Visibility = System.Windows.Visibility.Hidden;
                savePodFeed.Visibility = System.Windows.Visibility.Hidden;
                closeFeed.Visibility = System.Windows.Visibility.Hidden;
                listBox_Feed.Visibility = System.Windows.Visibility.Hidden;
                rectListboxFeed.Visibility = System.Windows.Visibility.Hidden;
            }

            else {
                downloadSelectedPod.Visibility = System.Windows.Visibility.Visible;
                savePodFeed.Visibility = System.Windows.Visibility.Visible;
                closeFeed.Visibility = System.Windows.Visibility.Visible;
                listBox_Feed.Visibility = System.Windows.Visibility.Visible;
                rectListboxFeed.Visibility = System.Windows.Visibility.Visible;
            }

        }





        private void getFeed_button_Click(object sender, RoutedEventArgs e)
        {

            listBox_Feed.Items.Clear();
            podcast = test.getPod(tbURL.Text);
            downloadURL = test.getDownloadURL();

            for (var i = 0; i < podcast.Length; i++)
            {
                if (podcast[i] == null)
                {
                    break;
                }
                else
                {
                    listBox_Feed.Items.Add(Environment.NewLine + podcast[i] + Environment.NewLine + downloadURL[i]);
                }
            }


            visibilityFeedSetting(false);
            test.wipeCollectedData();
        }

        private void closeFeed_Click(object sender, RoutedEventArgs e)
        {
            visibilityFeedSetting(true);
        }

        

         

        private void viewCategory_Click(object sender, RoutedEventArgs e)
        {
            double top = gridPage.Margin.Top;
            double left = gridPage.Margin.Left;
            gridPage.Margin = new Thickness(0, top, -788, 0);
        }

        private void viewFeeds_Click(object sender, RoutedEventArgs e)
        {
            double top = gridPage.Margin.Top;
            double left = gridPage.Margin.Left;
            gridPage.Margin = new Thickness(-1618, top, 0, 0);
        }

        private void viewMain_Click(object sender, RoutedEventArgs e)
        {
            double top = gridPage.Margin.Top;
            double left = gridPage.Margin.Left;
            gridPage.Margin = new Thickness(-800, top, -800, 0);
        }

       


    }
}
