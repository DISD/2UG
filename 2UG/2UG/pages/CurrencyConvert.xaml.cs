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
using Microsoft.Phone.Tasks;
using System;

namespace _2UG
{
    public partial class Currency_convert : PhoneApplicationPage
    {
        String[] Currency = { "", "UGX", "USD", "GBP", "EUR", "" };
        string firstCurrency;
        string secondCurrency;
        String amountEntered;
        String exchangeRate;
        double exchangeEntered;
        double valueEntered;
        double result;
        /*
         * Buying USD 2,649.97
         * selling USD  2,659.52
         * currency buying selling
         * USD (9:30am)	2,648.64	2,558.57
USD (12:30pm)		
USD (3:30pm)		
GBP (09:30am)	4,159.16	4,174.75
EUR (09:30am)	3,546.53	3,559.83
KSH (09:30am)	30.29	30.4
TSH (09:30am)	1.64	1.65
USD 7/02/13-WAR	2,650.05	2,659.4
         */

        public Currency_convert()
        {
            InitializeComponent();
            this.lpkCurrency1.ItemsSource = Currency;
             this.lpkCurrency2.ItemsSource = Currency;
        }

        private void currency1_listPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           firstCurrency = (string)lpkCurrency1.SelectedItem;
        }

        private void currency2_listPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           secondCurrency = (string)lpkCurrency2.SelectedItem;
        }

        private void BtnBackClick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/pages/2UG.xaml", UriKind.Relative));
        }

        private void Currency_Product(object sender, RoutedEventArgs e)
        {
            if (!((firstCurrency == "") || (secondCurrency == ""))) 
            {
                amountEntered = amountTextBox.Text;
                exchangeRate = exchangeTextBox.Text;
                if (!(amountEntered == "") || (exchangeRate == "")) 
                {
                    try
                    {

                        //ConvertorExchangeBox exchangeBox = new ConvertorExchangeBox();
                       // exchangeBox.Closed += new EventHandler(hotelSearchBoxClosed);
                       // exchangeBox.Show();
                       // exchangeBox.VerticalAlignment = VerticalAlignment.Top;
                      //  exchangeBox.HorizontalAlignment = HorizontalAlignment.Center;
                       // exchangeBox.Margin = new Thickness(0, 30, 0, 0);
                        valueEntered = Double.Parse(amountEntered);
                        exchangeEntered = Double.Parse(exchangeRate);
                        if (firstCurrency == "USD")
                        {
                            if (secondCurrency == "UGX")
                            {
                                result = valueEntered * exchangeEntered;
                                resultTextBlock.Text = string.Concat(result) + " SHS";
                            }
                            else 
                            {
                                // Pop up
                                MessageBoxResult errorBox = MessageBox.Show("Only converts to and from SHS");
                            }
                        }
                        else if (firstCurrency == "GBP")
                        {
                            if (secondCurrency == "UGX")
                            {
                                result = valueEntered * exchangeEntered;
                                resultTextBlock.Text = string.Concat(result) + " SHS";
                            }
                            else
                            {
                                // Pop up
                                MessageBoxResult errorBox = MessageBox.Show("Only converts to and from SHS");
                            }
                        }
                        else if (firstCurrency == "EUR") 
                        {
                            if (secondCurrency == "UGX")
                            {
                                result = valueEntered * exchangeEntered;
                               resultTextBlock.Text = string.Concat(result) + " SHS";
                            }
                            else
                            {
                                // Pop up
                                MessageBoxResult errorBox = MessageBox.Show("Only converts to and from SHS");
                            }
                        }
                        
                        else if (firstCurrency == "UGX")
                        {
                            if (secondCurrency == "USD")
                            {
                                result = Math.Round((valueEntered * (1 / exchangeEntered)), 2);
                                resultTextBlock.Text = string.Concat(result) + " USD";
                            }

                            else if (secondCurrency == "GBP")
                            {
                                result = Math.Round((valueEntered * (1 / exchangeEntered)), 2);
                                resultTextBlock.Text = string.Concat(result) + " GBP";
                            }
                            else if (secondCurrency == "EUR")
                            {
                                result = Math.Round((valueEntered * (1 / exchangeEntered)), 2);
                               resultTextBlock.Text = string.Concat(result) + " EUR";
                            }
                        }
                    }
                    catch { 
                        // Return the user a message "Only numeric values allowed"
                    }
                }
            }
        }

        private void HyperButton_Clicked(object sender, RoutedEventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
           // task.Uri = new Uri("http://www.google.com");
            //task.URL = new Uri("http://www.bou.or.ug/bou/home.html", UriKind.Absolute);
            
        }

    }
}