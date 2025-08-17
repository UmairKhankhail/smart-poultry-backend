using AutoMapper;
using SmartPoultry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoultry.Sales.Dto
{
    public class SaleMapProfile : Profile
    {
        public SaleMapProfile()
        {
            CreateMap<CreateSaleDto,Sale>();
            CreateMap<UpdateSaleDto, Sale>();
            CreateMap<Sale,CreateSaleDto>();
            CreateMap<Sale,GetAllDto>();
            CreateMap<Models.Customer, CustomerDto>();
        }
    }
}
