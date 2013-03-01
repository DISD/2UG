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
using _2UG.pages;
using _2UG.model.touristAttraction;
using System.Xml.Linq;
using Microsoft.Phone.Shell;

namespace _2UG
{
    public partial class Attraction : PhoneApplicationPage
    {
        private static XDocument loadActivityItemXML = XDocument.Load("database/tourist/touristAttraction.xml");
        public Attraction()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (searchBox.Text == "" || searchBox.Text == null)
            {
                return;
            }
            else
            {

                IEnumerable<ActivityModel> data = null;
                data = from aItem in loadActivityItemXML.Descendants("tourist_attraction")
                       where aItem.Element("activities").Element("activity").Value.Contains(searchBox.Text.ToLower())
                   select new ActivityModel()
                  {
                      name = (String)aItem.Element("name"),
                      address = (String)aItem.Element("address"),
                      district = (String)aItem.Element("district")
                };

                var retrivedData = data;
                if (retrivedData.Any() == false)
                {
                    errorLabel.Text = "No Search result found.";

                }
                else
                {
                    List<ActivityModel> activityModel = new List<ActivityModel>();

                    foreach(var activity in retrivedData){
                        ActivityModel a = (ActivityModel)activity;
                        activityModel.Add(a);

                    }

                    PhoneApplicationService.Current.State["Act"] = activityModel;
                    NavigationService.Navigate(new Uri("/pages/Activity.xaml?selectedCategoryImageUri=" + activityModel, UriKind.Relative));
                }
            }
        }

        
        private void BtnBackClick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/pages/2UG.xaml", UriKind.Relative));
        }


    }
}