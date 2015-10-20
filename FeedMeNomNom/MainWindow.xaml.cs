﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
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
using FeedMeNomNom.VO;

namespace FeedMeNomNom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        //getFeed test = new getFeed();
        testAddItem getItemList = new testAddItem();
        saveXML createXml = new saveXML();
        //string[] podcast;
        List<itemVO> podcast = new List<itemVO>();
        downloader downloadURL = new downloader();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        category cate = new category();
        

        public MainWindow()
        {
            InitializeComponent();
            createXml.createBaseXml();
            visibilityFeedSetting(true);
            //createXml.createBaseXml();
        }

      

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //test.downloadMP3();
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
            podcast = getItemList.createFeed(tbURL.Text);
            for (var i = 0; i < podcast.Count; i++)
            {
                if (podcast[i] == null)
                {
                    break;
                }
                else
                {
                    listBox_Feed.Items.Add(podcast[i].feedName);
                }
            }
            visibilityFeedSetting(false);
        }

        private void closeFeed_Click(object sender, RoutedEventArgs e)
        {
            visibilityFeedSetting(true);
        }

        

        // Vid knapptryck ändras vyn i MainWindow
        // med hjälp av att ändra margin på ett element

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

        
        //testFunktion för 
        private void listBox_Feed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = listBox_Feed.SelectedItem.ToString();

            string hej = getItemList.getInfo(selectedItem);
            Console.WriteLine(hej);
        }

        private void downloadSelectedPod_Click(object sender, RoutedEventArgs e)
        {
            
            string selectedItem = listBox_Feed.SelectedItem.ToString();
            string url = getItemList.getInfo(selectedItem);

            downloadURL.getURLandDownload(url);
            createTimer();
            



            //do
            //{ 
            //        Thread.Sleep(500);
            //   controlDownloadBar();

            //} while (downloadURL.getPercentage < 100);
            
        }

        private void createTimer() {

            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            double percentage = downloadURL.getPercentage;

        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            
                controlDownloadBar(downloadURL.getPercentage);
           
            
        }
        public void controlDownloadBar(double percentage)
        {
            if (percentage < 100)
            {
                downloadBar.Value = percentage;

            }

            else
            {
                MessageBox.Show("Pod Downloaded!");
                downloadBar.Value = 0;
                dispatcherTimer.Stop();

            }
                
            

            
        }

        

        private void addCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            cate.writeAttr();
            //cate.createNewCategory("Relation"); //Ska finnas
            //cate.readXML(); //Ska finnas
        }
    }
}
