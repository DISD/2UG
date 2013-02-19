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
using System.Device.Location;
using Microsoft.Phone.Controls.Maps;
//using _2UG.model.Spot;

namespace _2UG
{
    /*public enum GoogleType
    {
        Street = 'm',
        Hybrid = 'y',
        Satellite = 's',
        Physical = 't',
        PhysicalHybrid = 'p',
        StreetOverlay = 'h',
        WaterOverlay = 'r',
    }*/
    public partial class Spot : PhoneApplicationPage
    {
        public Spot()
        {
            InitializeComponent();
            getLocationDetails();
            Map spotMap = new Map();
            spotMap.CredentialsProvider = new ApplicationIdCredentialsProvider("Ag7dPWSfPX4rxbDj9FT0aPT_4gsUwpqgACBfzz_8ajJR7xhKms3AJzDraUiu95jq");

            //  MapType = GoogleType.Street;

            // UriFormat = @"http://mt{0}.google.com/vt/lyrs={1}&z={2}&x={3}&y={4}";
        }

        //     public GoogleType MapType { get; set; }

        /* public override Uri Geturi(int x, int y, int zoomLevel)
         {
             return new Uri(
                 string.Format(UriFormat, (X % 2) + (2 * (Y % 2)),
         (char)MapType, zoomLevel, AX, Y));
         }*/

        private void spot_details(object sender, RoutedEventArgs e)
        {
            // ApplicationIdCredentialsProvider = "";

        }

        static void PlaceText(Map map, string text, LocationRect location)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.DataContext = text;

            map.Children.Add(textBlock);
        }

        //private IEnumerable<SpotModel> retrieveData()
        //{
         //   IEnumerable<SpotModel> data = null;
         //   SpotModel spot = new SpotModel();
         //   spot.name = "";
         //   spot.desc = "";
            /* data = new SpotModel()
             {
                 name = "",
                 desc = ""
             };*/
       //     return data;
    //    }

        private void position1(object sender, RoutedEventArgs e)
        {

        }

        public void getLocationDetails()
        {
            GeoCoordinateWatcher coordinateWatcher;
            coordinateWatcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High)
            {
                MovementThreshold = 20
            };
            coordinateWatcher.StatusChanged += this.watcher_StatusChanged;
            coordinateWatcher.PositionChanged += this.watcher_PositionChanged;
            coordinateWatcher.Start();
            textBlock1.Text = coordinateWatcher.Position.Location.ToString();

        }

        private void watcher_StatusChanged(Object sender, GeoPositionStatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case GeoPositionStatus.Disabled:
                    break;

                case GeoPositionStatus.NoData:
                    break;
            }
        }

        private void watcher_PositionChanged(Object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            var epl = e.Position.Location;
            epl.Latitude.ToString("0.000");
            epl.Longitude.ToString("0.000");
            epl.Altitude.ToString();
            epl.HorizontalAccuracy.ToString();
            epl.VerticalAccuracy.ToString();
            epl.Course.ToString();
            epl.Speed.ToString();
            e.Position.Timestamp.LocalDateTime.ToString();
        }


    }
}