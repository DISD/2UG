﻿using System;
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
            //Creates the animation when another page is loaded
            NavigationInTransition navigationInTransition = new NavigationInTransition();
            navigationInTransition.Backward = new TurnstileTransition { Mode = TurnstileTransitionMode.BackwardIn };
            navigationInTransition.Forward = new TurnstileTransition { Mode = TurnstileTransitionMode.ForwardIn};

            NavigationOutTransition navigateOutTransition = new NavigationOutTransition();
            navigateOutTransition.Backward = new TurnstileTransition { Mode = TurnstileTransitionMode.BackwardOut };
            navigateOutTransition.Forward = new TurnstileTransition { Mode = TurnstileTransitionMode.ForwardOut };
            TransitionService.SetNavigationInTransition(this, navigationInTransition);
            TransitionService.SetNavigationOutTransition(this, navigateOutTransition);

            
        }
        
        private void image4_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void about_Ug_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/pages/About_ug.xaml", UriKind.Relative));
        }

        private void transport_btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/pages/Transport.xaml", UriKind.Relative));
        }

        private void hotel_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/pages/Hotel.xaml", UriKind.Relative));
        }

        private void tourist_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dangerous_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void currency_btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/pages/CurrencyConvert.xaml", UriKind.Relative));
        }
    }
}