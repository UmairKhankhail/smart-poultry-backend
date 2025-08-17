using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoultry.Customer.Dto
{
    public class CustomerMapProfile : Profile
    {
        public CustomerMapProfile()
        {
            CreateMap<CreateCustomerDto,Models.Customer>();
            CreateMap<Models.Customer, CreateCustomerDto>();
            CreateMap<UpdateCustomerDto,Models.Customer>();
        }
    }
}
