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

namespace _2UG
{
    public partial class Currency_convert : PhoneApplicationPage
    {
        String[] Currency = { "", "USH", "USD", "GBP", "EUR", "" };
        string firstCurrency;
        string secondCurrency;
        String amountEntered;
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

        private void Currency_Product(object sender, RoutedEventArgs e)
        {
            if (!((firstCurrency == "") || (secondCurrency == ""))) 
            {
                amountEntered = amountTextBox.Text;
                if (!(amountEntered == "")) 
                {
                    try
                    {
                        valueEntered = int.Parse(amountEntered);
                        if (firstCurrency == "USD")
                        {
                            if (secondCurrency == "USH")
                            {
                                result = valueEntered * 2558.57;
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
                            if (secondCurrency == "USH")
                            {
                                result = valueEntered * 4174.75;
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
                            if (secondCurrency == "USH")
                            {
                                result = valueEntered * 3559.83;
                                resultTextBlock.Text = string.Concat(result) + " SHS";
                            }
                            else
                            {
                                // Pop up
                                MessageBoxResult errorBox = MessageBox.Show("Only converts to and from SHS");
                            }
                        }
                        
                        else if (firstCurrency == "USH")
                        {
                            if (secondCurrency == "USD")
                            {
                                result = Math.Round((valueEntered * (1 / 2648.64)), 2);
                                resultTextBlock.Text = string.Concat(result) + " USD";
                            }

                            else if (secondCurrency == "GBP")
                            {
                                result = Math.Round((valueEntered * (1 / 4159.16)), 2);
                                resultTextBlock.Text = string.Concat(result) + " GBP";
                            }
                            else if (secondCurrency == "EUR")
                            {
                                result = Math.Round((valueEntered * (1 / 3546.53)), 2);
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

    }
}