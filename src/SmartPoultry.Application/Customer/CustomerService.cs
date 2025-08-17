using Abp.Application.Services;
using Abp.UI;
using AutoMapper;
using SmartPoultry.Customer.Dto;
using SmartPoultry.EntityFrameworkCore.Repositories;
using SmartPoultry.Item.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmartPoultry.Shared.ApplicationContants;

namespace SmartPoultry.Customer
{
    [RemoteService(false)]
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(CustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<List<Models.Customer>> GetAllCustomersAsync(bool isSupplier = false)
        {
            List<Models.Customer> customers = await _customerRepository.GetAllListAsync(x=>x.IsSupplier == isSupplier);
            return customers;
        }

        public async Task<CreateCustomerDto> InsertCustomerAsync(CreateCustomerDto customer)
        {
            if (customer == null)
            {
                throw new UserFriendlyException(ResponseMessages.InvalidData);
            }

            var newCustomer = _mapper.Map<Models.Customer>(customer);
            newCustomer = await _customerRepository.InsertAsync(newCustomer);

            return _mapper.Map<CreateCustomerDto>(newCustomer);
        }

        public async Task<CreateCustomerDto> UpdateCustomerAsync(UpdateCustomerDto customer)
        {
            if (customer == null || customer.Id <= 0)
            {
                throw new UserFriendlyException(ResponseMessages.InvalidData);
            }

            var existingCustomer = await _customerRepository.GetAsync(customer.Id);
            _mapper.Map(customer, existingCustomer);

            await _customerRepository.UpdateAsync(existingCustomer);

            return _mapper.Map<CreateCustomerDto>(existingCustomer);
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            if (id <= 0)
            {
                throw new UserFriendlyException(ResponseMessages.InvalidData);
            }

            var existingCustomer = await _customerRepository.GetAsync(id);
            await _customerRepository.DeleteAsync(existingCustomer);
            return true;
        }
    }
}
