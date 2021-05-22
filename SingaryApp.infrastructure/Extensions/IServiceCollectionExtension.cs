using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SingaryApp.infrastructure.Data;
using SingrayApp.ApplicationCore.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SingrayApp.ApplicationCore.Interfaces.Services;
using SingaryApp.infrastructure.Services;

namespace SingaryApp.infrastructure.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void RegisterLibrary(this IServiceCollection services, DbContext dbContext, Type mapperAssemblyType = null)
        {
            List<Type> list = new List<Type>();
            list.Add(typeof(AutoMapperProfiles));
            if (mapperAssemblyType != null)
            {
                list.Add(mapperAssemblyType);
            }
            //Register AutoMapper and configure Profiles 
            services.AddAutoMapper(list.ToArray());

            if (dbContext == null)
                throw new ArgumentNullException(nameof(dbContext));
            services.AddScoped<ISingrayUnitOfWork, SingaryAppUnitOfWork>(uow => new SingaryAppUnitOfWork(dbContext));

            services.AddTransient<IItemService, ItemService>();

        }
    }
}
