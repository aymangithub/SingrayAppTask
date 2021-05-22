using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SingrayApp.ApplicationCore.Interfaces.Data
{
  public  interface ISingrayGenericRepository<T> where T : class
    {
        Task AddAsync(T entity); 
        void Delete(T entity);
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null, string includeProperties = null);
        Task<T> FindByIDAsync<Input>(Input id);
                
    }
}
