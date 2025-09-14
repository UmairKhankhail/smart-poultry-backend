using AutoMapper;

namespace SmartPoultry.Purchases.Dto
{
    public class PurchaseMapProfile : Profile
    {
        public PurchaseMapProfile()
        {
            CreateMap<CreatePurchaseDto, Models.Purchase>();
            CreateMap<UpdatePurchaseDto, Models.Purchase>();
            CreateMap<Models.Purchase, CreatePurchaseDto>();
            CreateMap<Models.Purchase, GetAllDto>();
            CreateMap<Models.Supplier, SupplierDto>();
        }
    }
}
