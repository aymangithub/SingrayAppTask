using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SingrayApp.ApplicationCore.DTOs;
using SingrayApp.ApplicationCore.Interfaces.Data;
using SingrayApp.ApplicationCore.Interfaces.Services;
namespace SingaryApp.infrastructure.Services
{
    internal class ItemService : IItemService
    {
        protected readonly ISingrayUnitOfWork _uow;
        protected readonly IMapper _autoMapper;
        public ItemService(ISingrayUnitOfWork singrayUnitOfWork, IMapper autoMapper)
        {
            _uow = singrayUnitOfWork;
            _autoMapper = autoMapper;
        }
     

        public IQueryable<Item> Filter(string term, int? itemID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Item> GetAll()
        {
            var result = _uow.ItemsRepository.Get().ProjectTo<Item>(_autoMapper.ConfigurationProvider);
            return result;
        }

        public async Task<OperationResult> CreateAsync(Item itemToInsert)
        {
            try
            {
                var item = _autoMapper.Map<SingrayApp.ApplicationCore.Entities.Item>(itemToInsert);

                await _uow.ItemsRepository.AddAsync(item);
                await _uow.SaveChangesAsync();

                return OperationResult.Succeeded(payload: item.ID);
            }
            catch (Exception ex)
            {

                return OperationResult.Failure(message: ex.Message);
            }


        }


        public async Task<OperationResult> DeleteAsync(int id)
        {
            var deleteTask = Task.Run(async () =>
            {

                var itemTodelete = await _uow.ItemsRepository.FindByIDAsync(id);
                if (itemTodelete != null)
                {

                    _uow.ItemsRepository.Delete(itemTodelete);
                    await _uow.SaveChangesAsync();

                    return OperationResult.Succeeded();
                }

                return OperationResult.NotFound();



            });
            return await deleteTask;

        }
    }
}
