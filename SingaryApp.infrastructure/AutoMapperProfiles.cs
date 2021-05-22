using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SingaryApp.infrastructure
{
    public class AutoMapperProfiles
    {
        public class ItemProfile : Profile
        {
            public ItemProfile()
            {
                CreateMap<SingrayApp.ApplicationCore.Entities.Item, SingrayApp.ApplicationCore.DTOs.Item>();
                CreateMap<SingrayApp.ApplicationCore.DTOs.Item, SingrayApp.ApplicationCore.Entities.Item>();
            }
        }
    }
}
