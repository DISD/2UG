﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace _2UG
{
    public partial class About_ug : PhoneApplicationPage
    {
        public About_ug()
        {
            InitializeComponent();
            //MediaElement backgroundSong = new MediaElement();
            //backgroundSong.Source = new Uri("/music/Emali.wav", UriKind.Relative);
            //backgroundSong.AutoPlay = true;
            //backgroundSong.Position = new TimeSpan(0);
            //LayoutRoot.Children.Add(backgroundSong);
            //backgroundSong.Volume = 1;
            //backgroundSong.Play();
           
          

            XDocument loadCategoryData = XDocument.Load("database/AboutUg.xml");
            var categoryData = from query in loadCategoryData.Descendants("info")
                               select new Aboutuginfo
                               {
                                   AboutUgSec = (string)query.Element("sec"),
                                  
                               };
            aboutUg.ItemsSource = categoryData;

        }
        
        public class Aboutuginfo
        {
            string aboutUgSec;

            public string AboutUgSec
            {
                get { return aboutUgSec; }
                set { aboutUgSec = value; }

            }

        }

        private void DoThisWhenMediaEnds(object sender, RoutedEventArgs e)
        {
            backgroundMusic.AutoPlay = true;
            backgroundMusic.Position = new TimeSpan(1);
            //LayoutRoot.Children.Add(backgroundMusic);
            backgroundMusic.Volume = 1;
             backgroundMusic.Play();
        }
       

    }
}