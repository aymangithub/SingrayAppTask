using SingrayApp.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SingrayApp.ApplicationCore.Interfaces.Data
{
   public interface ISingrayUnitOfWork
    {

        ISingrayGenericRepository<Item> ItemsRepository { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
