using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TshirtMVVM.Models;

namespace TshirtMVVM.ViewModels
{
    public class OrderPageViewModel : BindableBase
    {
        private ObservableCollection<Tshirt> _orders;
        public ObservableCollection<Tshirt> Orders
        {
            get { return _orders; }
            set { SetProperty(ref _orders, value); }
        }
        private DelegateCommand _fieldName;
        public DelegateCommand CommandName =>
            _fieldName ?? (_fieldName = new DelegateCommand(ExecuteCommandName));

        void ExecuteCommandName()
        {

        }

        //public override void Initialize(INavigationParameters parameters)
        //{
        //    base.OnNavigatedFrom(parameters);

        //}


    }
}
