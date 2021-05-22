using Microsoft.EntityFrameworkCore;
using SingrayApp.ApplicationCore.Entities;
using SingrayApp.ApplicationCore.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SingaryApp.infrastructure.Data
{
    internal class SingaryAppUnitOfWork : ISingrayUnitOfWork
    {
        private readonly DbContext _dbContext;
        public SingaryAppUnitOfWork(DbContext dBContext)
        {
            this._dbContext = dBContext;
        }

        private ISingrayGenericRepository<Item> _itemsRepository;

        public ISingrayGenericRepository<Item> ItemsRepository
        {
            get
            {
                if (_itemsRepository == null)
                    _itemsRepository = new SingaryAppGenaricRepository<Item>(_dbContext);
                return _itemsRepository;

            }

        }


        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
