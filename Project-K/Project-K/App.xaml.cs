﻿using Project_K.Views;
using System.Net;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Project_K
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var Id = SecureStorage.GetAsync("Id").Result;
            if (Id == null)
                MainPage = new LoginPage();
            else
                MainPage = new AppShell();
        }
        //protected override void OnStart()
        //{
        //}

        //protected override void OnSleep()
        //{
        //}

        //protected override void OnResume()
        //{
        //}
    }
}
