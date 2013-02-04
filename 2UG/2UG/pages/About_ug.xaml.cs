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

namespace _2UG
{
    public partial class About_ug : PhoneApplicationPage
    {
        public About_ug()
        {
            InitializeComponent();
            MediaElement backgroundSong = new MediaElement();
            backgroundSong.Source = new Uri("/music/kadodi.wma", UriKind.Relative);
            backgroundSong.AutoPlay = true;
            backgroundSong.Position = new TimeSpan(0);
            LayoutRoot.Children.Add(backgroundSong);
            backgroundSong.Volume = 1;
            backgroundSong.Play();

        }
    }
}