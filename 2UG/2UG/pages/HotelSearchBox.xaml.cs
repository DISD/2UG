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

            this.typeListStackPanel.Visibility = Visibility.Collapsed;
            this.searchOptionStackPanel.Visibility = Visibility.Visible;
            this.nameRadioBtn.IsChecked = true;

            this.searchCategoryTextLabel.Text = category;
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            if (nameRadioBtn.IsChecked == true)
            {
                hotelName = districtORNameTextBox.Text;
                hotelType = "";
                districtName = "";

            }
            else if (districtRadioBtn.IsChecked == true)
            {
                districtName = districtORNameTextBox.Text;
                hotelType = "";
                hotelName = "";
            }
            else
            {

                hotelType = "general";
                districtName = "";
                hotelName = "";

                if (chineseRadioBtn.IsChecked == true)
                {
                    hotelType = "chinese";
                }
                else if (italianRadioBtn.IsChecked == true)
                {
                    hotelType = "italian";
                }
            }

            this.DialogResult = true;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            districtORNameTextBox.Text = "";
            this.DialogResult = false;
        }

        private void districtRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            this.typeListStackPanel.Visibility = Visibility.Collapsed;
            this.searchOptionStackPanel.Visibility = Visibility.Visible;
        }

        private void typeRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            this.typeListStackPanel.Visibility = Visibility.Visible;
            this.searchOptionStackPanel.Visibility = Visibility.Collapsed;
        }

        private void nameRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (typeListStackPanel.Visibility != Visibility.Collapsed)
            {
                this.typeListStackPanel.Visibility = Visibility.Collapsed;
            }

            this.searchOptionStackPanel.Visibility = Visibility.Visible;
            this.districtORNameTextBox.Text = "";
        }
    }
}
