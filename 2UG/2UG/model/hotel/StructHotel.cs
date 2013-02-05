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

namespace _2UG.Model
{
    public class StructHotel
    {
        private String name;
        private String address;
        private String type;
        private String district;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Address
        {
            get { return address; }
            set { address = value; }
        }

        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        public String District
        {
            get { return district; }
            set { district = value; }
        }

    }

}
