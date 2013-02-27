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
using System.Xml.Linq;
using _2UG.model.touristAttraction;

namespace _2UG.pages
{
    public partial class Activity : PhoneApplicationPage
    {
        private static XDocument loadActivityItemXML = XDocument.Load("database/tourist/activities.xml");
        public Activity()
        {
            InitializeComponent();
            populateActivityListBox(loadActivityItemXML);
        }
        private void populateActivityListBox(XDocument xmlFile)
        {
            var retrievedData = retrieveXMLData(xmlFile, activityList);
            if (retrievedData.Any() == false)
            {
                ActivityModel activityModel = new ActivityModel();
                activityModel.activity = "Nothing found ";
                retrievedData = new[] { activityModel };
            }
            activityList.ItemsSource = retrievedData;
        }

        private IEnumerable<ActivityModel> retrieveXMLData(XDocument xmlFile, ListBox activityList)
        {
            IEnumerable<ActivityModel> data = null;
            data = from aItem in loadActivityItemXML.Descendants("activity")
                   select new ActivityModel()
                   {
                       activity = (string)aItem.Element("activity")
                   };
            return data;
        }
    }
}