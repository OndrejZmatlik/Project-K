﻿using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project_K.Views
{
    public partial class RozvrhPage : ContentPage
    {
        public RozvrhPage()
        {
            InitializeComponent();
        }
        public void RefreshR(System.Collections.Generic.IList<Models.Cell> rozvrh)
        {
            RozvrhCollectionView.ItemsSource = rozvrh;
        }
    }
}