using System.Collections.Generic;
using Xamarin.Forms;

namespace TshirtMVVM.Views
{
    public partial class OrderPage : ContentPage
    {
        public List<Tshirt> Orders { get; set; }
        public OrderPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var stuff = App.Database;
            Orders = await App.Database.GetItemsAsync();

            BindingContext = this;

        }
        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var SelectedItem = e.Item as Tshirt;
            await Navigation.PushAsync(new PlaceOrder(SelectedItem));
        }
    }
}
