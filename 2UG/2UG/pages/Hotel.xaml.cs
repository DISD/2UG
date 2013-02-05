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
using _2UG.Model;
using System.Xml.Linq;

namespace _2UG
{
    public partial class Hotel : PhoneApplicationPage
    {
        private static XDocument loadHotelItemXML = XDocument.Load("database/hotel/hotel.xml");
        String[] HotelsCategory;// = { "Hotels", "Restaurants", "Clubs", "mines", "numbers",
                                 // "Triangle","Country"};
        public Hotel()
        {
            InitializeComponent();
            this.lpkCountry.ItemsSource = HotelsCategory;
        }

        //private hotel_comboBox_Se

        private void hotels_listPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            HenryTxtBox.Text = (string)lpkCountry.SelectedItem;

            // var hotelCombox = (ComboBox)sender;
            // if (hotelCombox.SelectedItem == null) return;

            //   ComboBoxItem selectedItemz = (ComboBoxItem) hotel_comboBox.SelectedItem;

            // hotelCombox.SelectedItem.ToString();
            //  

            //   if (selectedItemz.Equals("hotel_comboBoxItem"))
            //  {
            //    HenryTxtBox.Text = selectedItemz.DataContext + "";
            //NavigationService.Navigate(new Uri("/History.xaml", UriKind.Relative));
            //   populateHotelItemListBox();
            // }
            // populateHotelItemListBox();

        }

        private void populateHotelItemListBox()
        {
            String[] data = { "Hotels", "Restaurants", "Clubs", "mines", "numbers",
                                  "Triangle","Country"};
            HotelsCategory = data;
            var hotelData = retrieveHotelItemData();
            if (hotelData.Any() == false)
            {
                StructHotel htel = new StructHotel();
                htel.Name = "No Hotel Item found!";

                hotelData = new[] { htel };
            }
            
            // hotelList.ItemsSource = hotelData;
        }
        private IEnumerable<StructHotel> retrieveHotelItemData()
        {
            IEnumerable<StructHotel> hotelItemData = null;
            hotelItemData = from hItem in loadHotelItemXML.Descendants("hotel")
                            select new StructHotel()
                            {
                                Name = (String)hItem.Element("name"),
                                District = (String)hItem.Element("district"),
                                Address = (String)hItem.Element("address"),
                                Type = (String)hItem.Element("type")

                            };
            return hotelItemData;
        }

    }
}