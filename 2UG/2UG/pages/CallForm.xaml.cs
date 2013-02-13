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
using _2UG.model.call;
using Microsoft.Phone.Tasks;

namespace _2UG.pages
{
    public partial class CallForm : ChildWindow
    {
        public CallForm(String numberz)
        {

            InitializeComponent();
            string numberd = numberz + ",";
            callNumberList.ItemsSource = extractedNummbers(numberd);
        }

        private List<CallModel> extractedNummbers(string numberz)
        {
            string extractNmbrz = numberz.Substring(numberz.IndexOf(")") + 1, (numberz.Length - numberz.IndexOf(")")) - 1).Trim();
            List<CallModel> numberStore = new List<CallModel>();

            int startChar = 0;
            int endChar = -1;

            for (int i = 0; i < extractNmbrz.Length; i++)
            {

                if (extractNmbrz[i] == ',')
                {
                    endChar = i - 1;
                    CallModel cModel = new CallModel();
                    cModel.number = extractNmbrz.Substring(startChar, endChar - startChar + 1).Trim();
                    numberStore.Add(cModel);
                    startChar = i + 1;

                }
            }
            return numberStore;
        }

        private void callNumberList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (callNumberList.SelectedIndex == -1)
            {
                return;
            }

            PhoneCallTask callTask = new PhoneCallTask();
            callTask.PhoneNumber = "+256" + ((CallModel)(callNumberList.SelectedItem)).number;
            callTask.Show();

        }


        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {



        }
    }
}
