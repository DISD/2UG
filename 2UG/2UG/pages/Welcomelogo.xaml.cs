using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace _2UG.pages
{
    public partial class Welcomelogo : PhoneApplicationPage
    {
        private BackgroundWorker _backgroundWorker;
        public Welcomelogo()
        {
            InitializeComponent();
            this.progressBar1.IsIndeterminate = true;
            StartLoadingData();
        }
        
        private void StartLoadingData()
        {
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += new DoWorkEventHandler(backroungWorker_DoWork);
            _backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackroungWorkerRunWorkerCompleted);
            _backgroundWorker.RunWorkerAsync();
        }


        void BackroungWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(() => NavigationService.Navigate(new Uri("/pages/2UG.xaml", UriKind.Relative)));
           
        }

        void backroungWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Do some data loading on a background
            // We'll just sleep for the demo
            Thread.Sleep(3000);
        }
    }
}