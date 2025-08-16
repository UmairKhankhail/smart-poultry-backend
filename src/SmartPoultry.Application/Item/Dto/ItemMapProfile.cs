using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoultry.Item.Dto
{
    public class ItemMapProfile : Profile
    {
        public ItemMapProfile()
        {
            CreateMap<CreateItemDto, Models.Item>();
            CreateMap<UpdateItemDto, Models.Item>();
            CreateMap<Models.Item, CreateItemDto>();
        }
    }
}
