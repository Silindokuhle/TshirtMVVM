using System;
using System.Collections.Generic;
using TshirtMVVM.Models;
using Xamarin.Forms;

namespace TshirtMVVM.Views
{
    public partial class DetailsPage : ContentPage
    {
        public List<Tshirt> TshirtOrder { get; set; }
        public DetailsPage()
        {
            InitializeComponent();
        }
        private async void cancel_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var tshirt = new Tshirt();
            BindingContext = tshirt;
        }
        //private async void OnSaveClicked(object sender, EventArgs e)
        //{
        //    var tshirt = (Tshirt)BindingContext;

        //    var location = tshirt.ShippingAddress;
        //    var myadd = "Makhaza Cape Town";
        //    var locate = await Geocoding.GetLocationsAsync(myadd);
        //    Location finalLocate = locate?.FirstOrDefault();
        //    var addPos = string.Empty;
        //    if (finalLocate != null)
        //    {
        //        addPos = $"Latitude: {finalLocate.Latitude}, Longitude: {finalLocate.Longitude}";
        //    }
        //    tshirt.AddressPosition = addPos;
        //    await App.Database.SaveItemAsync(tshirt);
        //    await Navigation.PushAsync(new OrderPage());
        //}
    }
}
