using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using _2UG.model;
using System.Xml.Linq;
using Microsoft.Phone.Shell;
using _2UG.pages;
using _2UG.model.dangerousSpot;

namespace _2UG.pages
{
    public partial class Spot : PhoneApplicationPage
    {
        //string btnText;
        string value;
        private static XDocument loadSpotItemXML = XDocument.Load("database/spot/spot.xml");

        public Spot()
        {
            InitializeComponent();
            populateSpotListBox(loadSpotItemXML, spotList);
        }

        private void populateSpotListBox(XDocument xmlFile, ListBox spotList)
        {
            var retrievedData = retrieveXMLData(xmlFile, spotList);
            if (retrievedData.Any() == false)
            {
                SpotModel spotModel = new SpotModel();
                spotModel.name = "Nothing found ";
                retrievedData = new[] { spotModel };
            }
            spotList.ItemsSource = retrievedData;
        }

        private IEnumerable<SpotModel> retrieveXMLData(XDocument xmlFile, ListBox spotList)
        {
             IEnumerable<SpotModel> data = null;
             data = from cItem in loadSpotItemXML.Descendants("spot")
                    select new SpotModel()
                    {
                        name = (string)cItem.Element("name")
                        
                    };
            return data;
        }
        
        private void spot_click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            value = button.Content.ToString();
            SpotDetailBox detailBox = new SpotDetailBox(value);
            detailBox.Show();
        }

        private void BtnBackClick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/pages/2UG.xaml", UriKind.Relative));
        }
        }
    }
    