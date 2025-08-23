using Microsoft.AspNetCore.Mvc;
using SmartPoultry.Controllers;
using SmartPoultry.SaleLineItems;
using SmartPoultry.SaleLineItems.Dto;
using SmartPoultry.Sales.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartPoultry.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleLineItemsController : SmartPoultryControllerBase
    {
        private readonly ISaleLineItemsService _saleLineItemsService;
        public SaleLineItemsController(ISaleLineItemsService saleLineItemsService)
        {
            _saleLineItemsService= saleLineItemsService;
        }

        [HttpGet("get-all")]
        public async Task<List<GetSaleItemsDto>> GetAllSaleLineItems()
        {
            return await _saleLineItemsService.GetAllSaleLineItems(); 
        }
        [HttpPost("insert")]
        public async Task<CreateSaleLineItemDto> InsertSaleLineItem([FromBody] CreateSaleLineItemDto saleLineItem)
        {
            return await _saleLineItemsService.InsertSaleLineItemAsync(saleLineItem);
        }

        [HttpPut("update")]
        public async Task<CreateSaleLineItemDto> UpdateSaleLineItem([FromBody] UpdateSaleLineItemDto saleLineItem)
        {
            return await _saleLineItemsService.UpdateSaleLineItemAsync(saleLineItem);
        }

        [HttpDelete("delete")]
        public async Task<bool> DeleteSaleLineItem(int id)
        {
            return await _saleLineItemsService.DeleteSaleLineItemAsync(id);
        }
    }
}
