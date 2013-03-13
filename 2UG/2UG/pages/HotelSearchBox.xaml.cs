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

namespace _2UG.pages
{
    public partial class HotelSearchBox : ChildWindow
    {
        public string districtName { get; set; }
        public string hotelType { get; set; }
        public string hotelName { get; set; }

        public HotelSearchBox(string category)
        {
            InitializeComponent();

            this.hoteTypeListStackPanel.Visibility = Visibility.Collapsed;
           this.hotelSearchOptionStackPanel.Visibility = Visibility.Visible;
           this.hotelNameRadioBtn.IsChecked = true;

           // this.searchCategoryTextLabel.Text = category;
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            if (hotelNameRadioBtn.IsChecked == true)
           {
                hotelName = hotelDistrictORNameTextBox.Text;
                hotelType = "";
                districtName = "";

            }
           else if (hotelDistrictRadioBtn.IsChecked == true)
            {
               districtName = hotelDistrictORNameTextBox.Text;
                hotelType = "";
                hotelName = "";
            }
            else
            {

                hotelType = "general";
                districtName = "";
                hotelName = "";

                if (hotelChineseRadioBtn.IsChecked == true)
                {
                    hotelType = "chinese";
                }
                else if (hotelItalianRadioBtn.IsChecked == true)
                {
                    hotelType = "italian";
                }
            }

            this.DialogResult = true;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
           hotelDistrictORNameTextBox.Text = "";
            this.DialogResult = false;
        }

        private void districtRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            this.hoteTypeListStackPanel.Visibility = Visibility.Collapsed;
            this.hotelSearchOptionStackPanel.Visibility = Visibility.Visible;
        }

        private void typeRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            this.hoteTypeListStackPanel.Visibility = Visibility.Visible;
            this.hotelSearchOptionStackPanel.Visibility = Visibility.Collapsed;
        }

        private void nameRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
           if (hoteTypeListStackPanel.Visibility != Visibility.Collapsed)
            {
                this.hoteTypeListStackPanel.Visibility = Visibility.Collapsed;
           }

            this.hotelSearchOptionStackPanel.Visibility = Visibility.Visible;
            this.hotelDistrictORNameTextBox.Text = "";
        }

        private void hotelDistrictORNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                if (hotelNameRadioBtn.IsChecked == true)
                {
                    hotelName = hotelDistrictORNameTextBox.Text;
                    hotelType = "";
                    districtName = "";

                }
                else if (hotelDistrictRadioBtn.IsChecked == true)
                {
                    districtName = hotelDistrictORNameTextBox.Text;
                    hotelType = "";
                    hotelName = "";
                }
                else
                {

                    hotelType = "general";
                    districtName = "";
                    hotelName = "";

                    if (hotelChineseRadioBtn.IsChecked == true)
                    {
                        hotelType = "chinese";
                    }
                    else if (hotelItalianRadioBtn.IsChecked == true)
                    {
                        hotelType = "italian";
                    }
                }

                this.DialogResult = true;
            }
        }
    }
}
