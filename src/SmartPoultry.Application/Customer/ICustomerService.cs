using Abp.Application.Services;
using SmartPoultry.Customer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoultry.Customer
{
    public interface ICustomerService : IApplicationService
    {
        Task<List<Models.Customer>> GetAllCustomersAsync(bool isSupplier = false);
        Task<CreateCustomerDto> InsertCustomerAsync(CreateCustomerDto customer);
        Task<CreateCustomerDto> UpdateCustomerAsync(UpdateCustomerDto customer);
        Task<bool> DeleteCustomerAsync(int id);
    }
}
