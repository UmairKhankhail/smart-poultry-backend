using Microsoft.AspNetCore.Mvc;
using SmartPoultry.Controllers;
using SmartPoultry.SaleLineItems;
using SmartPoultry.SaleLineItems.Dto;
using SmartPoultry.Sales.Dto;
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

        [HttpPost("insert")]
        public async Task<CreateSaleLineItemDto> InsertSale([FromBody] CreateSaleLineItemDto saleLineItem)
        {
            return await _saleLineItemsService.InsertSaleLineItemAsync(saleLineItem);
        }
    }
}
