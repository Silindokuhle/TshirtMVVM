using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using TshirtMVVM.Models;
using TshirtMVVM.Services.Interfaces;
using TshirtMVVM.ViewModels.TshirtDatabases;
using Xamarin.Essentials;

namespace TshirtMVVM.ViewModels
{
    public class PlaceOrderViewModel : BindableBase
    {
        private ObservableCollection<Tshirt> _orders;
        private IDatabase _database;
        private IPageDialogService dialogService;

        public ObservableCollection<Tshirt> Orders
        {
            get { return _orders; }
            set { SetProperty(ref _orders, value); }
        }


        //Save button to save changes made to the details of the order
        private DelegateCommand _saveCommand;
        public DelegateCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new DelegateCommand(ExecuteSaveCommand));

        //View Map button to be able to see the shippig address of the parcel
        private DelegateCommand _viewMapCommand; 
        public DelegateCommand ViewMapCommand =>
            _viewMapCommand ?? (_viewMapCommand = new DelegateCommand(ExecuteViewMapCommand));

        //Confirm order button which sends to the internet and tells you if the internet is working

        private DelegateCommand _confirmOrderCommand;
        public DelegateCommand ConfirmOrderCommand =>
            _confirmOrderCommand ?? (_confirmOrderCommand = new DelegateCommand(ExecuteConfirmOrderCommand));

        public PlaceOrderViewModel(Prism.Navigation.INavigationService navigationService, IDatabase database, IPageDialogService : base(navigationService)
        {
            _database = database;
            _dialogService = dialogService;
           
        }
        void ExecuteSaveCommand()
        {
            
        }
        void ExecuteViewMapCommand()
        {

        }

        //code that takes the button to the next page where you want it to navigate to
       private async void ExecuteConfirmOrderCommand()
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                await _dialogService.DisplayAlertAync("Connection", "Internet is working", "ok");
            }
            if (current != NetworkAccess.Internet)
            {
                await _dialogService.DisplayAlert("Connection", "Internet is not working", "ok");
            }
            var databaseContent = _database;

            var stuff = new TshirtDatabase();
            var unsubmitted = await stuff.GetUnSubmittedOrders();

            var MyServerOrders = unsubmitted.Select(x => new Tshirt()
            {
                Name = x.Name,
                Gender = x.Gender,
                T_shirtsize = x.T_shirtsize,
                Dateoforder = x.Dateoforder,
                T_shirtcolor = x.T_shirtcolor,
                ShippingAddress = x.ShippingAddress
            });.ToList();

            var json = JsonConvert.SerializeObject(MyServerOrders);
            var client = new HttpClient();
            var url = "http://10.0.2.2:5000/Products";
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync(url, content);
                await _dialogService.DisplayAlertAlertAsync(("Response Message", response.ReasonPhrase, "ok");
                for (int i=0; i < Orders.Count; i++)
                {
                    Orders[i].Posted = true;
                    await databaseContent.SaveItemsAsync(Orders[i]);
                }
            }
            catch (Exception ex)
            {
                await _dialogService.DisplayAlertAsync("Exception", ex.Message, "ok");
            }

        }
        public override async void Initialize(INavigationParameters parameters)
         {
            base.OnNavigatedFrom(parameters);
            Orders = new ObservableCollection<Tshirt>(await _database.GetItemsAsync());   
         }
    }
}
