﻿#pragma checksum "E:\windows-phone-apps\2UG\2UG\2UG\pages\Hotel.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CB76C3919A3EFE202A5471C0E4099921"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace _2UG {
    
    
    public partial class Hotel : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock msgText;
        
        internal Microsoft.Phone.Controls.Pivot hotelPivot;
        
        internal Microsoft.Phone.Controls.PivotItem hotelPivotItem;
        
        internal System.Windows.Controls.TextBlock FirstPivot;
        
        internal System.Windows.Controls.ListBox hotelList;
        
        internal Microsoft.Phone.Controls.PivotItem apartmentPivotItem;
        
        internal System.Windows.Controls.TextBlock SecondPivot;
        
        internal System.Windows.Controls.ListBox apartmentList;
        
        internal Microsoft.Phone.Controls.PivotItem restuarantPivotItem;
        
        internal System.Windows.Controls.TextBlock ThirdPivot;
        
        internal System.Windows.Controls.ListBox restuarantList;
        
        internal Microsoft.Phone.Controls.PivotItem clubPivotItem;
        
        internal System.Windows.Controls.TextBlock FourthPivot;
        
        internal System.Windows.Controls.ListBox clubList;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/2UG;component/pages/Hotel.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.msgText = ((System.Windows.Controls.TextBlock)(this.FindName("msgText")));
            this.hotelPivot = ((Microsoft.Phone.Controls.Pivot)(this.FindName("hotelPivot")));
            this.hotelPivotItem = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("hotelPivotItem")));
            this.FirstPivot = ((System.Windows.Controls.TextBlock)(this.FindName("FirstPivot")));
            this.hotelList = ((System.Windows.Controls.ListBox)(this.FindName("hotelList")));
            this.apartmentPivotItem = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("apartmentPivotItem")));
            this.SecondPivot = ((System.Windows.Controls.TextBlock)(this.FindName("SecondPivot")));
            this.apartmentList = ((System.Windows.Controls.ListBox)(this.FindName("apartmentList")));
            this.restuarantPivotItem = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("restuarantPivotItem")));
            this.ThirdPivot = ((System.Windows.Controls.TextBlock)(this.FindName("ThirdPivot")));
            this.restuarantList = ((System.Windows.Controls.ListBox)(this.FindName("restuarantList")));
            this.clubPivotItem = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("clubPivotItem")));
            this.FourthPivot = ((System.Windows.Controls.TextBlock)(this.FindName("FourthPivot")));
            this.clubList = ((System.Windows.Controls.ListBox)(this.FindName("clubList")));
        }
    }
}

