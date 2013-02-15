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
        private string DANGEROUS_SPOT = "dangerousSpot";
        private string HOTEL = "hotel";
        private string TRANSPORT = "transport";
        private string CURRENCY_CONVERTER = "currency";
        private string TOURIST_ATTRACTIION = "attraction";


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

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            String selectedPanel = (string)((StackPanel)sender).Tag;

            if(selectedPanel.Equals(TRANSPORT)){

                NavigationService.Navigate(new Uri("/pages/Transport.xaml", UriKind.Relative));

            }else if(selectedPanel.Equals(HOTEL)){

                NavigationService.Navigate(new Uri("/pages/Hotel.xaml", UriKind.Relative));

            }else if (selectedPanel.Equals(TOURIST_ATTRACTIION)){

                NavigationService.Navigate(new Uri("/pages/TouristAttraction.xaml", UriKind.Relative));

            }else if (selectedPanel.Equals(DANGEROUS_SPOT)){

            }else if (selectedPanel.Equals(CURRENCY_CONVERTER)){

                NavigationService.Navigate(new Uri("/pages/CurrencyConvert.xaml", UriKind.Relative));
            }
            
        }
    }
}