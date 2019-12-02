using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TshirtMVVM.Models;
using TshirtMVVM.Services.Interfaces;

namespace TshirtMVVM.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }
        private IDatabase database;
        private DelegateCommand _placeOrder;
        public DelegateCommand PlaceOrder =>
            _placeOrder ?? (_placeOrder = new DelegateCommand(ExecutePlaceOrder));

        private DelegateCommand _viewOrder;
        public DelegateCommand ViewOrder =>
            _viewOrder ?? (_viewOrder = new DelegateCommand(ExecuteViewOrder));

        public Tshirt TshirtOrder { get; set; }
        public async void ExecutePlaceOrder()
        {
            await NavigationService.NavigateAsync("Details");

        }
        public async void ExecuteViewOrder()
        {
            await NavigationService.NavigateAsync("OrderPage");
        }
    }
}
