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
using _2UG.model.hotel;
using System.Xml.Linq;

namespace _2UG
{
    public partial class Hotel : PhoneApplicationPage
    {
        private static XDocument loadHotelItemXML = XDocument.Load("database/hotel/hotel.xml");
        private static XDocument loadRestaurantXML = XDocument.Load("database/hotel/restaurant.xml");
        private static XDocument loadApartmentXML = XDocument.Load("database/hotel/apartment.xml");
        private static XDocument loadClubXML = XDocument.Load("database/hotel/club.xml");
        String[] HotelsCategory = { "", "Hotels","Restaurants", "Clubs", "Apartments",""};
        public Hotel()
        {
            InitializeComponent();
            this.lpkCountry.ItemsSource = HotelsCategory;
        }

        // Checks user selections
        private void hotels_listPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String text = (string)lpkCountry.SelectedItem;
            if (text == "Hotels")
            {
                    populateHotelItemListBox();
            }
            else if (text == "Restaurants")
            {
                populateRestaurantItemListBox();
            }
            else if (text == "Apartments")
            {
                popualteApartmentItemListBox();
            }
            else if (text == "Clubs")
            {
                populateClubItemListBox();
            }
        }

        private void populateClubItemListBox()
        {
            var clubData = retrieveClubItemData();
            if (clubData.Any() == false)
            {
                StructClub cLub = new StructClub();
                cLub.Name = "No Club(s) found";
                clubData = new[] { cLub };
            }
            hotelList.ItemsSource = retrieveClubItemData();
        }

        private IEnumerable<StructClub> retrieveClubItemData()
        {
            var clubData = from cItem in loadClubXML.Descendants("club")
                           select new StructClub()
                           {
                               Name = (string)cItem.Element("name"),
                               District = (string)cItem.Element("district"),
                               Address = (string)cItem.Element("address")

                           };
            return clubData;
        }

        private void popualteApartmentItemListBox()
        {
            var apartmentData = retrieveApartmentItemData();
            if (apartmentData.Any() == false)
            {
                StructApartment aPartment = new StructApartment();
                aPartment.Name = "No Apartment(s) Item found!";

                apartmentData = new[] { aPartment };
            }

            hotelList.ItemsSource = retrieveApartmentItemData(); 
        }

        private IEnumerable<StructApartment> retrieveApartmentItemData()
        {
            var apartmentData = from aItem in loadApartmentXML.Descendants("apartment")
                                select new StructApartment()
                                {
                                    Name = (string)aItem.Element("name"),
                                    District = (string)aItem.Element("district"),
                                    Address = (string)aItem.Element("address")

                                };
            return apartmentData;
        }
        // Populates listbox with restaurant data
        private void populateRestaurantItemListBox()
        {
            var restaurantData = retrieveRestaurantItemData();
            if (restaurantData.Any() == false)
            {
                StructRestaurant rtaurant = new StructRestaurant();
                rtaurant.Name = "No Restaurant Item found!";

                restaurantData = new[] { rtaurant };
            }

            hotelList.ItemsSource = retrieveRestaurantItemData(); 
        }
        // Fetches data from restaurant
        private IEnumerable<StructRestaurant> retrieveRestaurantItemData()
        {
            IEnumerable<StructRestaurant> restaurantData = null;
            restaurantData = from rItem in loadRestaurantXML.Descendants("restaurant")
                            select new StructRestaurant()
                            {
                                Name = (String)rItem.Element("name"),
                                District = (String)rItem.Element("district"),
                                Address = (String)rItem.Element("address"),
                                Type = (String)rItem.Element("type")

                            };
            return restaurantData;
        }
        // Populates ListBox with Hotel data
        private void populateHotelItemListBox()
        {
            var hotelData = retrieveHotelItemData();
            if (hotelData.Any() == false)
            {
                StructHotel htel = new StructHotel();
                htel.Name = "No Hotel Item found!";

                hotelData = new[] { htel };
            }

            hotelList.ItemsSource = retrieveHotelItemData(); 
        }
        // Fetches data about hotels
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