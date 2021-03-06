﻿using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace WorkManagerSample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DependencyService.Resolve<INotificationScheduler>().ScheduleJob(50);
        }
    }
}