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
using _2UG.model.hotel;
using System.Xml.Linq;
using Microsoft.Phone.Shell;
using _2UG.pages;

namespace _2UG
{
    public partial class Hotel : PhoneApplicationPage
    {
        private static XDocument loadHotelItemXML = XDocument.Load("database/hotel/hotel.xml");
        private static XDocument loadRestaurantXML = XDocument.Load("database/hotel/restaurant.xml");
        private static XDocument loadApartmentXML = XDocument.Load("database/hotel/apartment.xml");
        private static XDocument loadClubXML = XDocument.Load("database/hotel/club.xml");

        private static String[] HOTEL_CATEGORIES = { "Hotels", "Restaurants", "Clubs", "Apartments" };
        private static String HOTEL_CATEGORY = "Hotels";
        private static String APARTMENT_CATEGORY = "Apartments";
        private static String RESTUARANT_CATEGORY = "Restaurants";
        private static String CLUB_CATEGORY = "Clubs";

        private static String UNKOWN_TYPE = "";
        private static String UNKOWN_DISTRICT_NAME = "";
        private static String UNKOWN_NAME = "";


        public Hotel()
        {
            InitializeComponent();

            this.hotelCategoryListPicker.ItemsSource = HOTEL_CATEGORIES;
            this.categorySelectedLabel.Text = (string)hotelCategoryListPicker.SelectedItem;
        }

        // Checks user selections
        private void hotels_listPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String selectedCategory = (string)hotelCategoryListPicker.SelectedItem;
            this.categorySelectedLabel.Text = selectedCategory;

            populateListBox(selectedCategory, UNKOWN_TYPE, UNKOWN_DISTRICT_NAME, UNKOWN_NAME);
        }

        private void populateListBox(String selectedCategory, String searchByType, String searchByDistrictName, String hotelName)
        {
            if (selectedCategory == HOTEL_CATEGORY)
            {
                populateCategoryListBox(loadHotelItemXML, HOTEL_CATEGORY, searchByType, searchByDistrictName, hotelName);
            }
            else if (selectedCategory == RESTUARANT_CATEGORY)
            {
                populateCategoryListBox(loadRestaurantXML, RESTUARANT_CATEGORY, searchByType, searchByDistrictName, hotelName);
            }
            else if (selectedCategory == APARTMENT_CATEGORY)
            {
                populateCategoryListBox(loadApartmentXML, APARTMENT_CATEGORY, searchByType, searchByDistrictName, hotelName);
            }
            else if (selectedCategory == CLUB_CATEGORY)
            {
                populateCategoryListBox(loadClubXML, CLUB_CATEGORY, searchByType, searchByDistrictName, hotelName);
            }
        }

        private void populateCategoryListBox(XDocument xmlFile, String categoryType, String searchByType, String searchByDistrictName, String hotelName)
        {

            var retrievedData = retrieveXMLData(xmlFile, categoryType, searchByType, searchByDistrictName, hotelName);
            if (retrievedData.Any() == false)
            {
                HotelModel hotelModel = new HotelModel();
                hotelModel.name = "No " + categoryType + " found with this search: " + searchByType + searchByDistrictName + hotelName;
                retrievedData = new[] { hotelModel };
            }

            hotelCategoryList.ItemsSource = retrievedData;
        }

        private IEnumerable<HotelModel> retrieveXMLData(XDocument xmlFile, String categoryType, String searchByType, String searchByDistrictName, String hotelName)
        {
            String firstXMLNode = categoryType.Substring(0, categoryType.Length - 1).ToLower();
            IEnumerable<HotelModel> data = null;

            if (!searchByType.Equals(""))
            {
                data = from hItem in xmlFile.Descendants(firstXMLNode)
                       where hItem.Element("type").Value.Contains(searchByType.ToLower())
                       select new HotelModel()
                       {
                           name = (string)hItem.Element("name"),
                           address = (string)hItem.Element("address"),
                           telphone = (string)hItem.Element("telphone"),
                           district = convertFirstElementToUpperCase((string)hItem.Element("district")),
                           type = convertFirstElementToUpperCase((string)hItem.Element("type"))
                       };
            }
            else if (!searchByDistrictName.Equals(""))
            {
                data = from hItem in xmlFile.Descendants(firstXMLNode)
                       where hItem.Element("district").Value.Contains(searchByDistrictName.ToLower())
                       select new HotelModel()
                       {
                           name = (string)hItem.Element("name"),
                           address = (string)hItem.Element("address"),
                           telphone = (string)hItem.Element("telphone"),
                           district = convertFirstElementToUpperCase((string)hItem.Element("district")),
                           type = convertFirstElementToUpperCase((string)hItem.Element("type"))
                       };
            }
            else if (!hotelName.Equals(""))
            {
                data = from hItem in xmlFile.Descendants(firstXMLNode)
                       where hItem.Element("name").Value.Contains(hotelName.ToUpper())
                       select new HotelModel()
                       {
                           name = (string)hItem.Element("name"),
                           address = (string)hItem.Element("address"),
                           telphone = (string)hItem.Element("telphone"),
                           district = convertFirstElementToUpperCase((string)hItem.Element("district")),
                           type = convertFirstElementToUpperCase((string)hItem.Element("type"))
                       };
            }
            else
            {
                data = from hItem in xmlFile.Descendants(firstXMLNode)
                       select new HotelModel()
                       {
                           name = (string)hItem.Element("name"),
                           address = (string)hItem.Element("address"),
                           telphone = (string)hItem.Element("telphone"),
                           district = convertFirstElementToUpperCase((string)hItem.Element("district")),
                           type = convertFirstElementToUpperCase((string)hItem.Element("type"))
                       };
            }

            return data;
        }


        private string convertFirstElementToUpperCase(string text)
        {
            if (text != null && text.Length > 0)
            {
                return char.ToUpper(text[0]) + text.Substring(1);
            }

            return null;
        }

        private void backButtonClick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/pages/2UG.xaml", UriKind.Relative));
        }

        private void searchButtonClickHandler(object sender, EventArgs e)
        {
            (ApplicationBar.Buttons[0] as ApplicationBarIconButton).IsEnabled = false;
            (ApplicationBar.Buttons[1] as ApplicationBarIconButton).IsEnabled = false;
            (ApplicationBar.Buttons[2] as ApplicationBarIconButton).IsEnabled = false;

            HotelSearchBox hotelSearchBox = new HotelSearchBox((string)hotelCategoryListPicker.SelectedItem);
            hotelSearchBox.Closed += new EventHandler(hotelSearchBoxClosed);
            hotelSearchBox.Show();
            hotelSearchBox.VerticalAlignment = VerticalAlignment.Top;
            hotelSearchBox.HorizontalAlignment = HorizontalAlignment.Center;
            hotelSearchBox.Margin = new Thickness(0, 150, 0, 0);
        }

        private void hotelSearchBoxClosed(object sender, EventArgs e)
        {
            HotelSearchBox h_searchBox = sender as HotelSearchBox;

            if (h_searchBox.DialogResult == true)
            {
                String selectedCategory = (string)hotelCategoryListPicker.SelectedItem;
                if (!h_searchBox.hotelName.Equals(""))
                {
                    populateListBox(selectedCategory, UNKOWN_TYPE, UNKOWN_DISTRICT_NAME, h_searchBox.hotelName);
                }
                else if (!h_searchBox.districtName.Equals(""))
                {
                    populateListBox(selectedCategory, UNKOWN_TYPE, h_searchBox.districtName, UNKOWN_NAME);
                }
                else if (!h_searchBox.hotelType.Equals(""))
                {
                    populateListBox(selectedCategory, h_searchBox.hotelType, UNKOWN_DISTRICT_NAME, UNKOWN_NAME);
                }

                enableApplicationBarButton();
            }
            else
            {
                enableApplicationBarButton();
            }
        }

        private void enableApplicationBarButton()
        {
            (ApplicationBar.Buttons[0] as ApplicationBarIconButton).IsEnabled = true;
            (ApplicationBar.Buttons[1] as ApplicationBarIconButton).IsEnabled = true;
            (ApplicationBar.Buttons[2] as ApplicationBarIconButton).IsEnabled = true;
        }

        private void refreshButtonClickHandler(object sender, EventArgs e)
        {
            String selectedCategory = (string)hotelCategoryListPicker.SelectedItem;
            populateListBox(selectedCategory, UNKOWN_TYPE, UNKOWN_DISTRICT_NAME, UNKOWN_NAME);
        }

    }
}