
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
using System.Collections;
using System.Collections.Generic;

namespace _2UG.model.touristAttraction
{
    public class TAttractions : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            return AutoCompletions.GetEnumerator();
        }

        public IEnumerable AutoCompletions = new List<string>(){
            "fishing",
            "camping", 
            "gorilla tracking" , 
            "Chimpanzee trekking",
            "Wildlife safaris",
            "Bird watching",
            "Mountain Hiking",
            "Launch Cruises",
            "Water Rafting",
            "Jungle Walks",
            "Community Tours",
            "Eco and Cultural Tourism",
            "Sport Fishing",
            "Rwenzori Mountaineering",
            "Game Viewing",
            "Boat Riding",
            "Horse Back safaris",
            "Mountain Biking",
            "Worship",
            "Camping",
            "Rhino Trekking",
            "Bungee Jumping",
            "Biking"
        };
    }
}
