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
using System.Windows.Navigation;
using Microsoft.Phone.Shell;
namespace _2UG.pages
{
    public partial class Activity : PhoneApplicationPage
    {

        public Activity()
        {
            InitializeComponent();


        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<ActivityModel> dPage = (List<ActivityModel>)PhoneApplicationService.Current.State["Act"];
            activityList.ItemsSource = dPage;
        }

        private void BtnBackClick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/pages/TouristAttraction.xaml", UriKind.Relative));
        }


    }
}