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
    public partial class PivotPage1 : PhoneApplicationPage
    {
        private static XDocument loadSpecialHireXMl = XDocument.Load("database/specialHire.xml");

        public PivotPage1()
        {
            InitializeComponent();
            populateSpecialHireListBox();
        }

        private void populateSpecialHireListBox(){
            specialHireList.ItemsSource = retrieveSpecialHireData("");
        }

        private IEnumerable<SpecialHire> retrieveSpecialHireData(string districtName)
        {
            IEnumerable<SpecialHire> specialHireData = null;
            if (districtName.Equals(""))
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
            else {
                specialHireData = from sHire in loadSpecialHireXMl.Descendants("special_hire")
                                  where sHire.Element("district").Value.Contains(districtName.ToLower())
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

            return char.ToUpper(text[0]) + text.Substring(1);
        }

        private void specialHire_Searchbox_handler(Object sender, KeyEventArgs e)
        {
            var specialHireData = retrieveSpecialHireData(specialHireSearchBox.Text);
            if(specialHireData.Any() == false){
                if (e.Key == Key.Enter)
                {
                    SpecialHire spHire = new SpecialHire();
                    spHire.Name = "No special Hire found!";

                    specialHireData = new[] { spHire };
                }
            }

            specialHireList.ItemsSource = specialHireData;
        }
    }
}