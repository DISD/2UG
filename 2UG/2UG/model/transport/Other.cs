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
    public class Other
    {
        private String name;
        private String address;
        private String route;
        public string telphone;

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

        public String Route
        {
            get { return route; }
            set { route = value; }
        }
        public String Telphone
        {
            get { return telphone; }
            set { telphone = value; }
        }
    }
}
