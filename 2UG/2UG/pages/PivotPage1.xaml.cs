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
using System.Windows.Controls.Primitives;
using _2UG.pages;
using Microsoft.Phone.Shell;

namespace _2UG
{
    public partial class PivotPage1 : PhoneApplicationPage
    {
        private static XDocument loadSpecialHireXMl = XDocument.Load("database/transport/specialHire.xml");
        private static XDocument loadTourTravelXML = XDocument.Load("database/transport/tourTravel.xml");
        private static XDocument loadOtherXML = XDocument.Load("database/transport/other.xml");
        private static int UNKOWN_SEARCH_CRITERIA = 3;

        public PivotPage1()
        {
            InitializeComponent();
            populateSpecialHireListBox();
            populateTourTravelListBox();
            populateOtherListBox();
        }

        private void callEventHandler(object sender, RoutedEventArgs e)
        {
            string tel = (string)((Button)sender).Tag;
            disableAppliicationBarIcon();
            CallForm callForm = new CallForm(tel);
            callForm.Show();

            callForm.Closed += new EventHandler(OnCallEnded);

            callForm.VerticalAlignment = VerticalAlignment.Top;
            callForm.HorizontalAlignment = HorizontalAlignment.Center;
            callForm.Margin = new Thickness(0, 30, 0, 0);
        }

        private void populateSpecialHireListBox()
        {
            specialHireList.ItemsSource = retrieveSpecialHireData("", UNKOWN_SEARCH_CRITERIA);
        }

        private void populateTourTravelListBox()
        {
            tourTravelList.ItemsSource = retrieveTourTravelData("", UNKOWN_SEARCH_CRITERIA);
        }

        private void populateOtherListBox()
        {
            otherList.ItemsSource = retrieveOtherData("", UNKOWN_SEARCH_CRITERIA);
        }

        private IEnumerable<Other> retrieveOtherData(string searchText, int searchCriteria)
        {
            IEnumerable<Other> otherData = null;

            if (searchText.Equals("") && searchCriteria == UNKOWN_SEARCH_CRITERIA)
            {
                otherData = from oTher in loadOtherXML.Descendants("other")
                            select new Other()
                            {
                                Name = (String)oTher.Element("name"),
                                Address = (String)oTher.Element("address"),
                                Route = (String)oTher.Element("route"),
                                Telphone = (String)oTher.Element("telphone")
                            };
            }
            else if (!searchText.Equals("") && searchCriteria == 1)
            {
                otherData = from oTher in loadOtherXML.Descendants("other")
                            where oTher.Element("name").Value.Contains(convertFirstElementToUpperCase(searchText.ToLower()))
                            select new Other()
                            {
                                Name = (String)oTher.Element("name"),
                                Address = (String)oTher.Element("address"),
                                Route = (String)oTher.Element("route"),
                                Telphone = (String)oTher.Element("telphone")
                            };
            }
            return otherData;
        }

        private IEnumerable<TourTravel> retrieveTourTravelData(string searchText, int searchCriteria)
        {
            IEnumerable<TourTravel> tourTravelData = null;

            if (searchText.Equals("") && searchCriteria == UNKOWN_SEARCH_CRITERIA)
            {
                tourTravelData = from tTravel in loadTourTravelXML.Descendants("tour_travel")
                                 select new TourTravel()
                                 {
                                     Name = (String)tTravel.Element("name"),
                                     Address = (String)tTravel.Element("address"),
                                     Telphone = (String)tTravel.Element("telphone"),
                                     District = convertFirstElementToUpperCase((String)tTravel.Element("district")),
                                     IconUri = (String)tTravel.Element("icon")
                                 };
            }
            else if (!searchText.Equals("") && searchCriteria == 0)
            {
                tourTravelData = from tTravel in loadTourTravelXML.Descendants("tour_travel")
                                 where tTravel.Element("district").Value.Contains(searchText.ToLower())
                                 select new TourTravel()
                                 {
                                     Name = (String)tTravel.Element("name"),
                                     Address = (String)tTravel.Element("address"),
                                     Telphone = (String)tTravel.Element("telphone"),
                                     District = convertFirstElementToUpperCase((String)tTravel.Element("district")),
                                     IconUri = (String)tTravel.Element("icon")
                                 };
            }
            else if (!searchText.Equals("") && searchCriteria == 1)
            {
                tourTravelData = from tTravel in loadTourTravelXML.Descendants("tour_travel")
                                 where tTravel.Element("name").Value.Contains(convertFirstElementToUpperCase(searchText.ToLower()))
                                 select new TourTravel()
                                 {
                                     Name = (String)tTravel.Element("name"),
                                     Address = (String)tTravel.Element("address"),
                                     Telphone = (String)tTravel.Element("telphone"),
                                     District = convertFirstElementToUpperCase((String)tTravel.Element("district")),
                                     IconUri = (String)tTravel.Element("icon")
                                 };
            }

            return tourTravelData;
        }

        private IEnumerable<SpecialHire> retrieveSpecialHireData(string searchText, int searchCriteria)
        {
            IEnumerable<SpecialHire> specialHireData = null;
            if (searchText.Equals("") && searchCriteria == UNKOWN_SEARCH_CRITERIA)
            {
                specialHireData = from sHire in loadSpecialHireXMl.Descendants("special_hire")
                                  select new SpecialHire()
                                  {
                                      Name = (String)sHire.Element("name"),
                                      Address = (String)sHire.Element("address"),
                                      Telphone = (String)sHire.Element("telphone"),
                                      District = convertFirstElementToUpperCase((String)sHire.Element("district")),
                                      IconUri = (String)sHire.Element("icon")
                                  };
            }
            else if (!searchText.Equals("") && searchCriteria == 0)
            {
                specialHireData = from sHire in loadSpecialHireXMl.Descendants("special_hire")
                                  where sHire.Element("district").Value.Contains(searchText.ToLower())
                                  select new SpecialHire()
                                  {
                                      Name = (String)sHire.Element("name"),
                                      Address = (String)sHire.Element("address"),
                                      Telphone = (String)sHire.Element("telphone"),
                                      District = convertFirstElementToUpperCase((String)sHire.Element("district")),
                                      IconUri = (String)sHire.Element("icon")
                                  };
            }
            else
            {
                specialHireData = from sHire in loadSpecialHireXMl.Descendants("special_hire")
                                  where sHire.Element("name").Value.Contains(convertFirstElementToUpperCase(searchText.ToLower()))
                                  select new SpecialHire()
                                  {
                                      Name = (String)sHire.Element("name"),
                                      Address = (String)sHire.Element("address"),
                                      Telphone = (String)sHire.Element("telphone"),
                                      District = convertFirstElementToUpperCase((String)sHire.Element("district")),
                                      IconUri = (String)sHire.Element("icon")
                                  };
            }

            return specialHireData;
        }

        private string convertFirstElementToUpperCase(string text)
        {
            if (text == null)
            {
            }
            else
            {
                if (text.Length > 0)
                {
                    return char.ToUpper(text[0]) + text.Substring(1);
                }
            }

            return null;
        }

        private void BtnBackClick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/pages/2UG.xaml", UriKind.Relative));
        }

        private void BtnSearchClick(object sender, EventArgs e)
        {

            disableAppliicationBarIcon();

            string activePivotName = "";
            int pivotActiveItem = transportPivot.SelectedIndex;
            int otherPivotSelected = 0;

            if (pivotActiveItem == 0)
            {
                activePivotName = "Special Hire";
            }
            else if (pivotActiveItem == 1)
            {
                activePivotName = "Tour n Travel";
            }
            else
            {
                activePivotName = "Others";
                otherPivotSelected = 1;
            }

            TransportSearchBox transportSearchBox = new TransportSearchBox(activePivotName, otherPivotSelected);

            transportSearchBox.Closed += new EventHandler(OnSearchBoxShow);
            transportSearchBox.Show();
            transportSearchBox.VerticalAlignment = VerticalAlignment.Top;
            transportSearchBox.HorizontalAlignment = HorizontalAlignment.Center;
            transportSearchBox.Margin = new Thickness(0, 30, 0, 0);
        }

        private void disableAppliicationBarIcon()
        {
            (ApplicationBar.Buttons[0] as ApplicationBarIconButton).IsEnabled = false;
            (ApplicationBar.Buttons[1] as ApplicationBarIconButton).IsEnabled = false;
            (ApplicationBar.Buttons[2] as ApplicationBarIconButton).IsEnabled = false;
        }

        private void OnSearchBoxShow(object sender, EventArgs e)
        {
            TransportSearchBox t_SearchBox = sender as TransportSearchBox;
            if (t_SearchBox.DialogResult == true)
            {
                int pivotActiveItem = transportPivot.SelectedIndex;
                int searchCretria = t_SearchBox.SearchCretria;
                string searchText = t_SearchBox.SearchText;

                if (!searchText.Equals(""))
                {

                    if (pivotActiveItem == 0)
                    {

                        var specialHireData = retrieveSpecialHireData(searchText, searchCretria);
                        if (specialHireData.Any() == false)
                        {
                            SpecialHire spHire = new SpecialHire();
                            spHire.Name = "No special Hire found!";

                            specialHireData = new[] { spHire };
                        }

                        specialHireList.ItemsSource = specialHireData;
                        transportPivot.SelectedItem = specialHirePivot;
                    }
                    else if (pivotActiveItem == 1)
                    {
                        var tourNTravelData = retrieveTourTravelData(searchText, searchCretria);
                        if (tourNTravelData.Any() == false)
                        {
                            TourTravel tTravel = new TourTravel();
                            tTravel.Name = "No travel n travel found!";

                            tourNTravelData = new[] { tTravel };
                        }


                        tourTravelList.ItemsSource = tourNTravelData;
                        transportPivot.SelectedItem = tourNTravelPivot;

                    }
                    else if (pivotActiveItem == 2)
                    {
                        var otherData = retrieveOtherData(searchText, searchCretria);
                        if (otherData.Any() == false)
                        {
                            Other other = new Other();
                            other.Name = "No record found!";

                            otherData = new[] { other };
                        }

                        otherList.ItemsSource = otherData;
                        transportPivot.SelectedItem = otherPivot;
                    }
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

        private void refreshBtnClick(object o, EventArgs e)
        {
            int pivotActiveItem = transportPivot.SelectedIndex;
            if (pivotActiveItem == 0)
            {
                specialHireList.ItemsSource = retrieveSpecialHireData("", UNKOWN_SEARCH_CRITERIA);
            }
            else if (pivotActiveItem == 1)
            {
                tourTravelList.ItemsSource = retrieveTourTravelData("", UNKOWN_SEARCH_CRITERIA);
            }
            else if (pivotActiveItem == 2)
            {
                otherList.ItemsSource = retrieveOtherData("", UNKOWN_SEARCH_CRITERIA);
            }

        }

        private void OnCallEnded(object sender, EventArgs e)
        {
            CallForm cForm = sender as CallForm;
            if (cForm.DialogResult == false)
            {
                enableApplicationBarButton();
            }
        }

    }
}