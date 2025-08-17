using Microsoft.AspNetCore.Mvc;
using SmartPoultry.Category;
using SmartPoultry.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartPoultry.Customer.Dto;
using SmartPoultry.Customer;

namespace SmartPoultry.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : SmartPoultryControllerBase
    {
        
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("get-all")]
        public async Task<List<Models.Customer>> GetAllCustomers(bool isSupplier = false)
        {
            return await _customerService.GetAllCustomersAsync(isSupplier);
        }

        [HttpPost("insert")]
        public async Task<CreateCustomerDto> InsertCustomer([FromBody] CreateCustomerDto customer)
        {
            return await _customerService.InsertCustomerAsync(customer);
        }

        [HttpPut("update")]
        public async Task<CreateCustomerDto> UpdateCategory([FromBody] UpdateCustomerDto customer)
        {
            return await _customerService.UpdateCustomerAsync(customer);
        }

        [HttpDelete("delete")]
        public async Task<bool> DeleteCategory(int id)
        {
            return await _customerService.DeleteCustomerAsync(id);
        }
    }
}
