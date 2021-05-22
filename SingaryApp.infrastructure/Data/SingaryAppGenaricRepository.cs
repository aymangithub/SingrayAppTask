using Microsoft.EntityFrameworkCore;
using SingrayApp.ApplicationCore.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SingaryApp.infrastructure.Data
{
    internal class SingaryAppGenaricRepository<T> : ISingrayGenericRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> entity;
        public SingaryAppGenaricRepository(DbContext dbcontext)
        {
            _dbContext = dbcontext;
            entity = _dbContext.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await this.entity.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            this.entity.Remove(entity);
            _dbContext.Entry<T>(entity).State = EntityState.Deleted;
        }

        public async Task<T> FindByIDAsync<Input>(Input id)
        {
            return await entity.FindAsync(id);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = entity;

            if (filter != null)
                query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {

                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            return query;
        }
    }
}
