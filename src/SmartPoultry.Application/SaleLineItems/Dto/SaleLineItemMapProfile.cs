using AutoMapper;
using SmartPoultry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoultry.SaleLineItems.Dto
{
    public class SaleLineItemMapProfile : Profile
    {
        public SaleLineItemMapProfile()
        {
            CreateMap<CreateSaleLineItemDto, SaleLineItem>();
            CreateMap<SaleLineItem, CreateSaleLineItemDto>();
            CreateMap<UpdateSaleLineItemDto,SaleLineItem>();
            CreateMap<SaleLineItem, GetSaleItemsDto>()
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(x => x.Item.Price * x.Quantity))
                .ForMember(dest => dest.Item, opt => opt.MapFrom(x => x.Item));
        }
    }
}
