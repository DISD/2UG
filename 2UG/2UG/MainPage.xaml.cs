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
using Microsoft.Phone.Shell;


namespace _2UG
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Transport.xaml", UriKind.Relative));
        }

        private void MenuItem1_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/", UriKind.Relative));
        }

        private void MenuItem2_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/", UriKind.Relative));
        }
    }
}