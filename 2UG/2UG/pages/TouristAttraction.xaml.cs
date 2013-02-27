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


namespace _2UG
{
    public partial class Attraction : PhoneApplicationPage
    {
        
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
              //  searchBox.Text = "yes";
                //Activity activity = new Activity();
                NavigationService.Navigate(new Uri("/pages/Activity.xaml", UriKind.Relative));

            }
        }

        
        private void BtnBackClick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/pages/2UG.xaml", UriKind.Relative));
        }


    }
}