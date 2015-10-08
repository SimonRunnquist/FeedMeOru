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
        saveXML createXml = new saveXML();

        public MainWindow()
        {
            InitializeComponent();
            createXml.createBaseXml();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            test.googleGet(tbURL.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            test.downloadMP3();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            tbURL.Text = test.Name;
            test.Name = "Mac!";
        }

        

       


    }
}
