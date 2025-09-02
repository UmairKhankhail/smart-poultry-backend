using AutoMapper;
using SmartPoultry.Models;

namespace SmartPoultry.SaleLineItems.Dto
{
    public class SaleLineItemMapProfile : Profile
    {
        public SaleLineItemMapProfile()
        {
            CreateMap<CreateSaleLineItemDto, SaleLineItem>()
                     .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(x => (x.Average * x.Rate) * x.Weight));
            CreateMap<SaleLineItem, CreateSaleLineItemDto>();
            CreateMap<UpdateSaleLineItemDto, SaleLineItem>();
            CreateMap<SaleLineItem, GetSaleItemsDto>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(x => x.Item));
        }
    }
}
