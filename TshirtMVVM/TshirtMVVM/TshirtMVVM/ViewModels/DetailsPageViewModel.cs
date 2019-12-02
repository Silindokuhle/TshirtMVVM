using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using TshirtMVVM.Services.Interfaces;
using TshirtMVVM.ViewModels;

namespace TshirtMVVM.ViewModels
{
    public class DetailsPageViewModel : ViewModelBase
    {
        private IDatabase database;
        private DelegateCommand _saveCommand;
        public DelegateCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new DelegateCommand(ExecuteSaveCommand));

        private DelegateCommand _cancelCommand;
        public DelegateCommand CancelCommand =>
            _cancelCommand ?? (_cancelCommand = new DelegateCommand(ExecuteCancelCommand));

    }

    public async void ExecuteCancelCommand()
    {
        await NavigationService.NavigateAsync("MainPage");
    }

    public async void ExecuteSaveCommand()
    {
        await NavigationService.NavigateAsync("OrderPage");
    }

}    
