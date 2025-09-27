using Abp.Application.Services;
using Abp.UI;
using AutoMapper;
using SmartPoultry.EntityFrameworkCore.Repositories;
using SmartPoultry.Item;
using SmartPoultry.Models;
using SmartPoultry.SaleLineItems.Dto;
using SmartPoultry.Sales;
using System.Collections.Generic;
using System.Threading.Tasks;
using static SmartPoultry.Shared.ApplicationContants;

namespace SmartPoultry.SaleLineItems
{
    [RemoteService(false)]
    public class SaleLineItemsService : ISaleLineItemsService
    {
        private readonly SaleLineItemsRepository _saleLineItemsRepository;
        private readonly IItemService _itemService;
        private readonly ISalesService _salesService;
        private readonly IMapper _mapper;
        public SaleLineItemsService(SaleLineItemsRepository saleLineItemsRepository, IItemService itemService, IMapper mapper, ISalesService salesService) 
        {
            _saleLineItemsRepository = saleLineItemsRepository;
            _itemService = itemService;
            _salesService = salesService;
            _mapper = mapper;
        }

        public async Task<List<GetSaleItemsDto>> GetAllSaleLineItems()
        {
            var saleLineItems = await _saleLineItemsRepository.GetAllIncludingAsync(x => x.Item);
            var saleLineItemsDto = _mapper.Map<List<GetSaleItemsDto>>(saleLineItems);
            return saleLineItemsDto;
        }
        public async Task<CreateSaleLineItemDto> InsertSaleLineItemAsync(CreateSaleLineItemDto saleLineItem)
        {
            if (saleLineItem == null)
            {
                throw new UserFriendlyException(ResponseMessages.InvalidData);
            }
            Models.Item item = await _itemService.GetById(saleLineItem.ItemId);
            
            var newSaleLineItem = _mapper.Map<SaleLineItem>(saleLineItem);
            newSaleLineItem = await _saleLineItemsRepository.InsertAsync(newSaleLineItem);
            await _salesService.UpdateSaleAmount(saleLineItem.SaleId, newSaleLineItem.TotalAmount);

            return _mapper.Map<CreateSaleLineItemDto>(newSaleLineItem);
        }
        public async Task<CreateSaleLineItemDto> UpdateSaleLineItemAsync(UpdateSaleLineItemDto saleLineItem)
        {
            if (saleLineItem == null || saleLineItem.Id <= 0)
            {
                throw new UserFriendlyException(ResponseMessages.InvalidData);
            }

            await _itemService.GetById(saleLineItem.ItemId);
            var existingSaleLineItem = await _saleLineItemsRepository.GetAsync(saleLineItem.Id);
            _mapper.Map(saleLineItem, existingSaleLineItem);

            await _saleLineItemsRepository.UpdateAsync(existingSaleLineItem);

            return _mapper.Map<CreateSaleLineItemDto>(existingSaleLineItem);
        }
        public async Task<bool> DeleteSaleLineItemAsync(int id)
        {
            if (id <= 0)
            {
                throw new UserFriendlyException(ResponseMessages.InvalidData);
            }

            var existingSaleLineItem = await _saleLineItemsRepository.GetAsync(id);
            await _saleLineItemsRepository.DeleteAsync(existingSaleLineItem);
            return true;
        }
    }
}
