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
using System.Windows.Controls.Primitives;

namespace _2UG.pages
{
    public partial class TransportSearchBox : ChildWindow
    {
        public string _qTransportScreen;
        public string SearchText { get; set; }
        public int SearchCretria { get; set; }

        private int districtOrNameSelected = 1;

        public TransportSearchBox(string searchName, int isOtherPivotSelected)
        {
            InitializeComponent();
            this.SearchNameLabel.Text = searchName;

            if (isOtherPivotSelected == 1)
            {
                districtRadioBtn.IsEnabled = false;
            }

        }

        public void button2_Click(object sender, RoutedEventArgs e)
        {
            t_SearchText.Text = "";
            this.DialogResult = false;

        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // if districtOrNameSelected = 0 => district radio btn is checked else name
            if (districtRadioBtn.IsChecked == true)
            {
                districtOrNameSelected = 0;
            }
            else
            {
                districtOrNameSelected = 1;
            }

            this.SearchCretria = districtOrNameSelected;
            this.SearchText = t_SearchText.Text;
            t_SearchText.Text = "";

            this.DialogResult = true;
        }

    }
}
