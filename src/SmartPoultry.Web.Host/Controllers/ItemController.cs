using Microsoft.AspNetCore.Mvc;
using SmartPoultry.Category.Dto;
using SmartPoultry.Category;
using SmartPoultry.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartPoultry.Item;
using SmartPoultry.Item.Dto;

namespace SmartPoultry.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : SmartPoultryControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet("get-all")]
        public async Task<List<Models.Item>> GetAllItems()
        {
            return await _itemService.GetAllItemsAsync();
        }

        [HttpPost("insert")]
        public async Task<CreateItemDto> InsertItem([FromBody] CreateItemDto item)
        {
            return await _itemService.InsertItemAsync(item);
        }

        [HttpPut("update")]
        public async Task<CreateItemDto> UpdateItem([FromBody] UpdateItemDto item)
        {
            return await _itemService.UpdateItemAsync(item);
        }

        [HttpDelete("delete")]
        public async Task<bool> DeleteItem(int id)
        {
            return await _itemService.DeleteItemAsync(id);
        }
    }
}
