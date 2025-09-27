using Microsoft.AspNetCore.Mvc;
using SmartPoultry.Controllers;
using SmartPoultry.Models;
using SmartPoultry.Sales;
using SmartPoultry.Sales.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartPoultry.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : SmartPoultryControllerBase
    {
        private readonly ISalesService _salesService;
        public SalesController(ISalesService salesService)
        {
            _salesService= salesService;
        }

        [HttpGet("get-all")]
        public async Task<List<GetAllDto>> GetAllSales()
        {
            return await _salesService.GetAllSalesAsync();
        }

        [HttpPost("insert")]
        public async Task<CreateSaleDto> InsertSale([FromBody] CreateSaleDto category)
        {
            return await _salesService.InsertSaleAsync(category);
        }

        [HttpPut("update")]
        public async Task<CreateSaleDto> UpdateSale([FromBody] UpdateSaleDto category)
        {
            return await _salesService.UpdateSaleAsync(category);
        }

        [HttpDelete("delete")]
        public async Task<bool> DeleteSale(int id)
        {
            return await _salesService.DeleteSaleAsync(id);
        }
    }
}
