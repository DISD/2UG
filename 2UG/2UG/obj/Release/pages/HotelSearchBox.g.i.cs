﻿#pragma checksum "C:\Users\Acer\Documents\Visual Studio 2010\Projects\WindowsPhone\2UG\2UG\2UG\pages\HotelSearchBox.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E99287DC6A213FBE27865636D4EFB0BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace _2UG.pages {
    
    
    public partial class HotelSearchBox : System.Windows.Controls.ChildWindow {
        
        internal System.Windows.Controls.Grid HotelLayoutRoot;
        
        internal System.Windows.Controls.TextBlock SearchNameLabel;
        
        internal System.Windows.Controls.Image image1;
        
        internal System.Windows.Controls.TextBlock searchCategoryTextLabel;
        
        internal System.Windows.Controls.RadioButton hotelNameRadioBtn;
        
        internal System.Windows.Controls.RadioButton hotelDistrictRadioBtn;
        
        internal System.Windows.Controls.RadioButton hotelTypeRadioBtn;
        
        internal System.Windows.Controls.StackPanel hoteTypeListStackPanel;
        
        internal System.Windows.Controls.RadioButton hotelGeneralRadioBtn;
        
        internal System.Windows.Controls.RadioButton hotelChineseRadioBtn;
        
        internal System.Windows.Controls.RadioButton hotelItalianRadioBtn;
        
        internal System.Windows.Controls.StackPanel hotelSearchOptionStackPanel;
        
        internal System.Windows.Controls.TextBlock districtNameLabel;
        
        internal System.Windows.Controls.TextBox hotelDistrictORNameTextBox;
        
        internal System.Windows.Controls.Button hotelSearchBtn;
        
        internal System.Windows.Controls.Button hotelCloseBtn;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/2UG;component/pages/HotelSearchBox.xaml", System.UriKind.Relative));
            this.HotelLayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("HotelLayoutRoot")));
            this.SearchNameLabel = ((System.Windows.Controls.TextBlock)(this.FindName("SearchNameLabel")));
            this.image1 = ((System.Windows.Controls.Image)(this.FindName("image1")));
            this.searchCategoryTextLabel = ((System.Windows.Controls.TextBlock)(this.FindName("searchCategoryTextLabel")));
            this.hotelNameRadioBtn = ((System.Windows.Controls.RadioButton)(this.FindName("hotelNameRadioBtn")));
            this.hotelDistrictRadioBtn = ((System.Windows.Controls.RadioButton)(this.FindName("hotelDistrictRadioBtn")));
            this.hotelTypeRadioBtn = ((System.Windows.Controls.RadioButton)(this.FindName("hotelTypeRadioBtn")));
            this.hoteTypeListStackPanel = ((System.Windows.Controls.StackPanel)(this.FindName("hoteTypeListStackPanel")));
            this.hotelGeneralRadioBtn = ((System.Windows.Controls.RadioButton)(this.FindName("hotelGeneralRadioBtn")));
            this.hotelChineseRadioBtn = ((System.Windows.Controls.RadioButton)(this.FindName("hotelChineseRadioBtn")));
            this.hotelItalianRadioBtn = ((System.Windows.Controls.RadioButton)(this.FindName("hotelItalianRadioBtn")));
            this.hotelSearchOptionStackPanel = ((System.Windows.Controls.StackPanel)(this.FindName("hotelSearchOptionStackPanel")));
            this.districtNameLabel = ((System.Windows.Controls.TextBlock)(this.FindName("districtNameLabel")));
            this.hotelDistrictORNameTextBox = ((System.Windows.Controls.TextBox)(this.FindName("hotelDistrictORNameTextBox")));
            this.hotelSearchBtn = ((System.Windows.Controls.Button)(this.FindName("hotelSearchBtn")));
            this.hotelCloseBtn = ((System.Windows.Controls.Button)(this.FindName("hotelCloseBtn")));
        }
    }
}

