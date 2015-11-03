using System;
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
using FeedMeNomNom.BUS.welcome;
using Validate;

namespace FeedMeNomNom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       //Skapar nödvändiga fält
        getItems getItemList = new getItems();
        saveXML savexml = new saveXML();
        readXML readxml = new readXML();
        List<itemVO> podcast = new List<itemVO>();
        downloader downloadURL = new downloader();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        category Category = new category();
        altWelcomeText welcText = new altWelcomeText();
        string podURL;
        
        //Initierar programmet
        public MainWindow()
        {
            InitializeComponent();
            visibilityFeedSetting(true);
            visibilitySavePodSetting(true);
            visibilityAddCategorySetting(true);
            visibilityEditCategorySetting(true);
            visibilityEditPodSetting(true);
            readxml.readXMLDoc();
            player.LoadedBehavior = MediaState.Manual;
            loadCategoryList();
            lblWelcomeText.Content = welcText.text;

            //checkIntervals();
        }

      
        //Visar och stänger ner podlistan och dess tillhörigheter
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

        //visar och stänger Spara pod popup
        internal void visibilitySavePodSetting(bool setting) {
            if (setting){
                saveGridPopup.Visibility = System.Windows.Visibility.Hidden;
            }
            else{
                saveGridPopup.Visibility = System.Windows.Visibility.Visible;
            }
        }

        //visar och stänger ner lägg till kategori popup
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

        //visar och stänger ner redigera kategori popup
        internal void visibilityEditCategorySetting(bool setting)
        {
            if (setting)
            {
                categoryGridPopupEdit.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                categoryGridPopupEdit.Visibility = System.Windows.Visibility.Visible;
            }
        }

        //visar och stänger ner redigera pod popup
        internal void visibilityEditPodSetting(bool setting) {
            if (setting)
            {
                editPodPopup.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                editPodPopup.Visibility = System.Windows.Visibility.Visible;
            }
        }

        //Laddar kategori och fyller på listor
        private void loadCategoryList() {
            try
            {
                List<string> category = new List<string>();
                categoryListBox.Items.Clear();
                cbCategory.Items.Clear();

                category = readxml.readXMLDoc();

                foreach (string item in category)
                {
                    categoryListBox.Items.Add(item);
                    cbCategory.Items.Add(item);
                }

                category.Clear();
            }
            catch (Exception er)
            {
                string error = er.Message;
                Console.WriteLine(error);
            }

        }

        //kollar interval
        //Fungerar, används ej
        private void checkIntervals() {
            try
            {
                readxml.getAllFeeds();
            }
            catch (Exception er) {
                string error = er.Message;
                Console.WriteLine(error);
            }
        }
        
        //Hämtar data från url och läser in detta i en lista
        private void getFeed_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                podcast.Clear();
                listBox_Feed.Items.Clear();

                string url = tbURL.Text;

                if (Validate.validate.useInternal(url))
                {
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
            }

            catch (Exception er) {
                string error = er.Message;
                Console.WriteLine(error);
            }
        }

        //Stänger ner feed popup
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

        // Vid knapptryck ändras vyn i MainWindow
        // med hjälp av att ändra margin på ett element
        private void viewFeeds_Click(object sender, RoutedEventArgs e)
        {
            double top = gridPage.Margin.Top;
            double left = gridPage.Margin.Left;
            gridPage.Margin = new Thickness(-1618, top, 0, 0);
        }

        // Vid knapptryck ändras vyn i MainWindow
        // med hjälp av att ändra margin på ett element
        private void viewMain_Click(object sender, RoutedEventArgs e)
        {
            double top = gridPage.Margin.Top;
            double left = gridPage.Margin.Left;
            gridPage.Margin = new Thickness(-800, top, -800, 0);
        }

        
        //Hämtar podens mp3länk och sparar ner denna
        private void listBox_Feed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string selectedItem = listBox_Feed.SelectedItem.ToString();
                string url = getItemList.getInfo(selectedItem);
                podURL = url;
            }

            catch (Exception hej)
            {
                var x = hej.Message;
                Console.WriteLine(x);
            }
        }

        //Laddar ner pod
        private void downloadSelectedPod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedItem = listBox_Feed.SelectedItem.ToString();
                string url = getItemList.getInfo(selectedItem);

                downloadURL.getURLandDownload(url);
                podURL = url;
                createTimer();
            }
            catch (Exception er)
            {
                string error = er.Message;
                Console.WriteLine(error);
            }
        }

        //Skapar timer för hantering av progressbar
        private void createTimer() {
            try
            {
                dispatcherTimer.Tick += dispatcherTimer_Tick;
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Start();

                double percentage = downloadURL.getPercentage;
            }
            catch (Exception er)
            {
                string error = er.Message;
                Console.WriteLine(error);
            }

        }
        
        //Kontrollerar hur många procent nedladdningen har
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                controlDownloadBar(downloadURL.getPercentage);
            }
            catch (Exception er)
            {
                string error = er.Message;
                Console.WriteLine(error);
            }
        }

        //Notifierar användaren via en progressBar
        public void controlDownloadBar(double percentage)
        {
            try
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
            catch (Exception er)
            {
                string error = er.Message;
                Console.WriteLine(error);
            }
         }

        
        //Lägger till kategori
        private void addCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<String> Hejsan = new List<string>();
                Hejsan = readxml.readXMLDoc();
                categoryListBox.ItemsSource = readxml.readXMLDoc();
            }
            catch (Exception er)
            {
                string error = er.Message;
                Console.WriteLine(error);
            }
        }

        //Spelar upp pod och sparar ner informationen i XML
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                savexml.editChecked(podURL);
                player.Source = new Uri(podURL);
                player.Play();
            }
            catch (Exception er)
            {
                string error = er.Message;
                Console.WriteLine(error);
            }
        }

        //Stoppar spelaren
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            player.Stop();
        }

        //Visar popup för att spara Pod
        private void savePodFeed_Click(object sender, RoutedEventArgs e)
        {
            visibilitySavePodSetting(false);
        }

        //Stänger popup för att spara Pod
        private void closePodFeedPopup_Click(object sender, RoutedEventArgs e)
        {
            visibilitySavePodSetting(true);
        }

        //Testmetod för att starta interval
        //Fungerar men enbart för en viss pod
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                intervalUpdate inter = new intervalUpdate();
                inter.url = tbURL.Text;
                inter.title = "Alex och Sigge";
                inter.createTimer(10);
            }
            catch (Exception er)
            {
                string error = er.Message;
                Console.WriteLine(error);
            }
        }

        //Tar bort en kategori
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                string category = categoryListBox.SelectedItem.ToString();
                Category.deleteCategory(category);
                loadCategoryList();
            }
            catch (Exception er)
            {
                string error = er.Message;
                Console.WriteLine(error);
            }
        }

        //Visar popup för att lägga till kategori
        //Stänger popup för redigera kategori
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            visibilityAddCategorySetting(false);
            visibilityEditCategorySetting(true);
        }

        //Skapar ny kategori
        //Laddar om kategorilistan
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = categoryNewName.Text;

                if (Validate.validate.checkEmpty(name))
                {
                    Category.createNewCategory(name);
                    visibilityAddCategorySetting(true);
                    loadCategoryList();
                }
            }
            catch (Exception er)
            {
                string error = er.Message;
                Console.WriteLine(error);
            }
        }

        //Sparar feed tillsammans podcasts i XML
        private void savePodFeedPopup_Click(object sender, RoutedEventArgs e)
        {
            try
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
                    }
                }
            }
            catch (Exception er)
            {
                string error = er.Message;
                Console.WriteLine(error);
            }
        }

        //Ändrar kategori
        //Laddar om och stänger ner popup för redigering
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedItem = categoryListBox.SelectedItem.ToString();
                string newName = categoryEditText.Text;
                Category.editCategory(selectedItem, newName);
                loadCategoryList();
                visibilityEditCategorySetting(true);
            }
            catch (Exception er)
            {
                string error = er.Message;
                Console.WriteLine(error);
            }
        }

        //Stänger ner popup för att lägga till kategori
        //Visar popup för att redigera kategori
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            visibilityEditCategorySetting(false);
            visibilityAddCategorySetting(true);
        }

        //Stänger ner popup för att lägga till kategori
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            visibilityAddCategorySetting(true);
        }

        //Stänger ner popup för att redigera kategori
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            visibilityEditCategorySetting(true);
        }

        //Rensar listor i kategorivyn
        //Hämtar feeds och lägger till dessa i en lista
        private void categoryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ListCategoryFeeds.Items.Clear();
                listCategoryFeedPods.Items.Clear();

                List<string> feedList = new List<string>();

                string selectedItem = categoryListBox.SelectedItem.ToString();
                feedList = readxml.getCategoryFeeds(selectedItem);

                foreach (string feed in feedList)
                {
                    ListCategoryFeeds.Items.Add(feed);
                }
            }

            catch (Exception er)
            {
                string error = er.Message;
                Console.WriteLine(error);
            }
        }

        //Rensar lista i kategori vyn
        //Hämtar pods och lägger tills dessa i en lista
        private void ListCategoryFeeds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                listCategoryFeedPods.Items.Clear();

                List<string> feedPodList = new List<string>();

                string selecteditem = ListCategoryFeeds.SelectedItem.ToString();

                feedPodList = readxml.getCategoryPodName(selecteditem);

                
                for (var i = 0; i < feedPodList.Count; i++)
                {
                    listCategoryFeedPods.Items.Add(feedPodList[i]);
                }
            }
            catch (Exception er) {
                string error = er.Message;
                Console.WriteLine(error);
            }
        }

        //Hämtar information om Pods och skriver ut dessa i ett par labels
        //Ändrar även podURL så användaren kan lyssna direkt från listorna
        private void listCategoryFeedPods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            List<String> podInfos = new List<string>();

            try
            {
                string selectedPod = listCategoryFeedPods.SelectedItem.ToString();
                Console.WriteLine(selectedPod);
              
              string podName = readxml.getCategoryPodName(selectedPod, "name");
              string podurl = readxml.getCategoryPodName(selectedPod, "url");
              string podCheck = readxml.getCategoryPodName(selectedPod, "checked");

              if (podCheck.Equals("0"))
              {
                  podCheck = "You haven't heard this one";
              }
              else {
                  podCheck = "You've heard this one";
              }

               lblNamePod.Content = podName;
               lblURLPod.Content = podurl;
               lblCheckedPod.Content = podCheck;
               podURL = podurl;

            }
            catch (Exception er)
            {
                string error = er.Message;
                Console.WriteLine(error);
            }
        }

        //visar redigera pod popup
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            visibilityEditPodSetting(false);
        }

        //stänger ner redigera pod popup
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            visibilityEditPodSetting(true);
        }

        //Ändrar en pods Namn och URL
        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            try
            {
                string newName = editPodNewName.Text;
                string newUrl = editPodNewURL.Text;
                string name = listCategoryFeedPods.SelectedItem.ToString();

                savexml.editUrl(name, newUrl);
                savexml.editName(name, newName);

                visibilityEditPodSetting(true);
            }
            catch (Exception er)
            {
                string error = er.Message;
                Console.WriteLine(error);
            }
        }

       
    }
}
