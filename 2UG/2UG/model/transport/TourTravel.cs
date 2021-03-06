﻿using System;
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
    public class TourTravel
    {
        private String name;
        private String address;
        private String telphone;
        private String district;
        private String iconUri;

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

        public String Telphone
        {
            get { return telphone; }
            set { telphone = value; }
        }

        public String District
        {
            get { return district; }
            set { district = value; }
        }

        public String IconUri
        {
            get { return iconUri; }
            set { iconUri = value; }
        }
    }
}
