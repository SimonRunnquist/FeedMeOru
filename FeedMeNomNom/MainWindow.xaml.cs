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
using FeedMeNomNom.connectXML;
using System.Drawing;
using FeedMeNomNom.VO;
using FeedMeNomNom.BUS;
using Validate;

namespace FeedMeNomNom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        getItems getItemList = new getItems();
        saveXML savexml = new saveXML();
        readXML readxml = new readXML();
        List<itemVO> podcast = new List<itemVO>();
        downloader downloadURL = new downloader();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        category Category = new category();
        string podURL;
        

        public MainWindow()
        {
            InitializeComponent();
            visibilityFeedSetting(true);
            visibilitySavePodSetting(true);
            visibilityAddCategorySetting(true);
            readxml.readXMLDoc();
            player.LoadedBehavior = MediaState.Manual;
            loadCategoryList();
            //checkIntervals();
        }

      
        internal void visibilityFeedSetting(bool setting) {
            if (setting)
            {
                downloadSelectedPod.Visibility = System.Windows.Visibility.Hidden;
                savePodFeed.Visibility = System.Windows.Visibility.Hidden;
                closeFeed.Visibility = System.Windows.Visibility.Hidden;
                listBox_Feed.Visibility = System.Windows.Visibility.Hidden;
                rectListboxFeed.Visibility = System.Windows.Visibility.Hidden;
            }

            else 
            {
                downloadSelectedPod.Visibility = System.Windows.Visibility.Visible;
                savePodFeed.Visibility = System.Windows.Visibility.Visible;
                closeFeed.Visibility = System.Windows.Visibility.Visible;
                listBox_Feed.Visibility = System.Windows.Visibility.Visible;
                rectListboxFeed.Visibility = System.Windows.Visibility.Visible;
            }

        }

        internal void visibilitySavePodSetting(bool setting) {
            if (setting){
                saveGridPopup.Visibility = System.Windows.Visibility.Hidden;
            }
            else{
                saveGridPopup.Visibility = System.Windows.Visibility.Visible;
            }
        }

        internal void visibilityAddCategorySetting(bool setting)
        {
            if (setting)
            {
                categoryGridPopup.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                categoryGridPopup.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void loadCategoryList() {
            List<string> category = new List<string>();
            categoryListBox.Items.Clear();
            cbCategory.Items.Clear();
            
            category = readxml.readXMLDoc();

            foreach (string item in category) {
                categoryListBox.Items.Add(item);
                cbCategory.Items.Add(item);
            }

            category.Clear();

        }

        private void checkIntervals() {
            readxml.getAllFeeds();
        }





        private void getFeed_button_Click(object sender, RoutedEventArgs e)
        {
            podcast.Clear();
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

        
        
        private void listBox_Feed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selectedItem = listBox_Feed.SelectedItem.ToString();
                string info = getItemList.getInfo(selectedItem);
                podURL = info;

                Console.WriteLine(info);
            }

            catch (Exception hej)
            {
                var x = hej.Message;
                Console.WriteLine(x);
            }

            
            

        }

        private void downloadSelectedPod_Click(object sender, RoutedEventArgs e)
        {
            
            string selectedItem = listBox_Feed.SelectedItem.ToString();
            string url = getItemList.getInfo(selectedItem);
            
            downloadURL.getURLandDownload(url);
            podURL = url;
            createTimer();
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
            List<String> Hejsan = new List<string>();
            Hejsan = readxml.readXMLDoc();
            categoryListBox.ItemsSource = readxml.readXMLDoc();
            
            Console.WriteLine(Hejsan);
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            player.Source = new Uri(podURL);
            player.Play();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            player.Stop();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            player.Pause();
        }

        private void savePodFeed_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("false");
            visibilitySavePodSetting(false);
        }

        private void closePodFeedPopup_Click(object sender, RoutedEventArgs e)
        {
            visibilitySavePodSetting(true);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            intervalUpdate inter = new intervalUpdate();
            inter.url = tbURL.Text;
            inter.title = "Alex och Sigge";
            //readxml.getFeedCount("Alex och Sigge");
            inter.createTimer(10);

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string category = categoryListBox.SelectedItem.ToString();
            Category.deleteCategory(category);
            loadCategoryList();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            visibilityAddCategorySetting(false);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            string name = categoryNewName.Text;
            Category.createNewCategory(name);
            visibilityAddCategorySetting(true);
            loadCategoryList();
        }

        private void savePodFeedPopup_Click(object sender, RoutedEventArgs e)
        {
            string interval = intervalTextBox.Text;
            string name = addFeedName.Text;
            string category = cbCategory.SelectedItem.ToString();
            int podcastCount = podcast.Count();


            if (Validate.validate.checkEmpty(name))
            {
                if (Validate.validate.checkEmpty(category))
                {
                    if (Validate.validate.checkEmpty(interval) && Validate.validate.checkNumber(interval))
                    {
                        savexml.createTitleFeed(name, interval, tbURL.Text, category);
                        getItemList.updateExistingFeed(name, podcastCount);
                        visibilitySavePodSetting(true);
                    }
                    else
                    {
                        Console.WriteLine("Not numbers");
                    }
                }

                else
                {
                    Console.WriteLine("Choose Something");
                }
            }
            else {
                Console.WriteLine("Add a name to feed!");
            }

            
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
