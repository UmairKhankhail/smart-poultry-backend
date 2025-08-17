using Abp.Application.Services;
using SmartPoultry.Item.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoultry.Item
{
    public interface IItemService : IApplicationService
    {
        Task<List<GetItemDto>> GetAllItemsAsync();
        Task<Models.Item> GetById(int id);
        Task<CreateItemDto> InsertItemAsync(CreateItemDto item);
        Task<CreateItemDto> UpdateItemAsync(UpdateItemDto item);
        Task<bool> DeleteItemAsync(int id);
        Task<bool> ValidateAndSubstractItemQuantity(Models.Item item, double quantity);
    }
}
