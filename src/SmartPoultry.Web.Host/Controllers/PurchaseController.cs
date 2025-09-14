using Microsoft.AspNetCore.Mvc;
using SmartPoultry.Controllers;
using SmartPoultry.Purchase;
using SmartPoultry.Purchases.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartPoultry.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : SmartPoultryControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet("get-all")]
        public async Task<List<GetAllDto>> GetAllSales()
        {
            return await _purchaseService.GetAllPurchasesAsync();
        }

        [HttpPost("insert")]
        public async Task<CreatePurchaseDto> InsertPurcahse([FromBody] CreatePurchaseDto category)
        {
            return await _purchaseService.InsertPurchaseAsync(category);
        }

        [HttpPut("update")]
        public async Task<CreatePurchaseDto> UpdatePurchase([FromBody] UpdatePurchaseDto purchase)
        {
            return await _purchaseService.UpdatePurchaseAsync(purchase);
        }

        [HttpDelete("delete")]
        public async Task<bool> DeletePurchase(int id)
        {
            return await _purchaseService.DeletePurcahseAsync(id);
        }

    }
}
