using Abp.Application.Services;
using Abp.UI;
using AutoMapper;
using SmartPoultry.Category.Dto;
using SmartPoultry.EntityFrameworkCore.Repositories;
using SmartPoultry.Item;
using SmartPoultry.Item.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmartPoultry.Shared.ApplicationContants;

namespace SmartPoultry.Items
{
    [RemoteService(false)]
    public class ItemService : IItemService
    {
        private readonly ItemRepository _itemRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ItemService(ItemRepository itemRepository, IMapper mapper, CategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<List<Models.Item>> GetAllItemsAsync()
        {
            List<Models.Item> items = await _itemRepository.GetAllListAsync();
            return items;
        }

        public async Task<CreateItemDto> InsertItemAsync(CreateItemDto item)
        {
            if (item == null)
            {
                throw new UserFriendlyException(ResponseMessages.InvalidData);
            }

            await _categoryRepository.GetAsync(item.CategoryId);
            
            var newItem = _mapper.Map<Models.Item>(item);
            newItem = await _itemRepository.InsertAsync(newItem);

            return _mapper.Map<CreateItemDto>(newItem);
        }

        public async Task<CreateItemDto> UpdateItemAsync(UpdateItemDto item)
        {
            if (item == null || item.Id <= 0)
            {
                throw new UserFriendlyException(ResponseMessages.InvalidData);
            }

            var existingItem = await _itemRepository.GetAsync(item.Id);
            _mapper.Map(item, existingItem);

            await _categoryRepository.GetAsync(existingItem.CategoryId);
            await _itemRepository.UpdateAsync(existingItem);

            return _mapper.Map<CreateItemDto>(existingItem);
        }
        public async Task<bool> DeleteItemAsync(int id)
        {
            if (id <= 0)
            {
                throw new UserFriendlyException(ResponseMessages.InvalidData);
            }

            var existingItem = await _itemRepository.GetAsync(id);
            await _itemRepository.DeleteAsync(existingItem);
            return true;
        }
    }
}
