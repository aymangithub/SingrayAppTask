using SingrayApp.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingrayApp.ApplicationCore.Interfaces.Services
{
   public interface IItemService
    {

        IQueryable<Item> GetAll();
        IQueryable<Item> Filter(string term, int? itemID);
        Task<OperationResult> DeleteAsync(int id);
        Task<OperationResult> CreateAsync(Item itemToInsert);
        
    }
}
