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
using System.Windows.Controls.Primitives;
using System.Xml.Linq;
using _2UG.model.dangerousSpot;
using Microsoft.Phone.Shell;
using _2UG.pages;
using System.Windows.Media.Imaging;

namespace _2UG.pages
{
    public partial class SpotDetailBox : ChildWindow
    {
          
        private static XDocument loadSpotDetailsXML = XDocument.Load("database/spot/spot.xml");

        public SpotDetailBox(string value)
        {
            InitializeComponent();
            populateSpotDetails(value);
        }

        private void populateSpotDetails(string value)
        {
            SpotModel spotModel = retrieveSpotDetailData(value);
            spotDanger2.Text = spotModel.detail;
            Uri imageUri = new Uri(spotModel.image, UriKind.Relative);
            ImageSource imgSource = new BitmapImage(imageUri);
            spotImageUrl.Source = imgSource;
            spotTitle.Text = spotModel.name;
           // spotImageUrl.Source = spotModel.image;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           // this.spotName = spotDager1.Text;
            
           // this.details = 
            disableApplicationBarIcon();
            
            this.DialogResult = true;
        }

        private void disableApplicationBarIcon()
        {
            /*(ApplicationBar.Buttons[0] as ApplicationBarIconButton).IsEnabled = false;
            (ApplicationBar.Buttons[1] as ApplicationBarIconButton).IsEnabled = false;
            (ApplicationBar.Buttons[2] as ApplicationBarIconButton).IsEnabled = false;*/
        }

        private SpotModel retrieveSpotDetailData(string spotName) {
            IEnumerable<SpotModel> spotD = null;
            spotD = from sM in loadSpotDetailsXML.Descendants("spot")
                    where sM.Element("name").Value.Contains(spotName)
                    select new SpotModel()
                          {
                             // image = (string)sModel.Element("image"),
                              name = (string)sM.Element("name"),
                              detail = (string)sM.Element("danger"),
                              image = (string)sM.Element("image")
                          };

            SpotModel sModel = spotD.ElementAt(0);
            return sModel;
        }
    }
}