using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace _2UG.model.hotel
{
    public class HotelModel
    {
        public string name {set; get;}
        public string address { set; get; }
        public string telphone { set; get; }
        public string district { set; get; }
        public string type { set; get; }

        public String Telphone
        {
            get { return telphone; }
            set { telphone = value; }
        }

    }
}
