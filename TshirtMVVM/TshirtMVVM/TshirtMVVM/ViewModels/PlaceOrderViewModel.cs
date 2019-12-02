using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TshirtMVVM.ViewModels
{
    public class PlaceOrderViewModel : BindableBase
    {
        private DelegateCommand saveCommand;
        public DelegateCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new DelegateCommand(ExecuteSaveCommand));

        private DelegateCommand _fieldName;
        public DelegateCommand ViewMapCommand =>
            _viewMapCommand ?? (_viewMapCommand = new DelegateCommand(ExecuteViewMapCommand));

        private DelegateCommand _fieldName;
        public DelegateCommand ConfirmOrderCommand =>
            _confirmOrderCommande ?? (_confirmOrderCommand = new DelegateCommand(ExecuteConfirmOrderCommand));

        public async void ExecuteSaveCommand()
        {
            await NavigationService.NavigateAsync("ExitPage");
        }

        public async void ExecuteViewMapCommand()
        {

        }

        public async void ExecuteConfirmOrderCommand()
        {

        }
    }
}
