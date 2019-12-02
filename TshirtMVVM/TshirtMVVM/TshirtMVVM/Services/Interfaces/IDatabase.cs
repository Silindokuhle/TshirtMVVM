using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TshirtMVVM.Models;

namespace TshirtMVVM.Services.Interfaces
{
    public interface IDatabase 
    {
        Task<List<Tshirt>> GetItemsAsync();
        Task<Tshirt>  GetItemsNotDoneAsync();
        Task<Tshirt> GetItemsAsync(int id);
        Task<int> SaveItemsAsync(Tshirt item);
        Task<int> DeleteItemsAsync(Tshirt item);
        Task<List<Tshirt>> GetUnSubmittedOrders();
       
    }
}
