using Abp.UI;
using SmartPoultry.EntityFrameworkCore.Repositories;
using SmartPoultry.Models;
using SmartPoultry.Sales.Dto;
using static SmartPoultry.Shared.ApplicationContants;
using System.Threading.Tasks;
using SmartPoultry.SaleLineItems.Dto;
using SmartPoultry.Item;
using AutoMapper;
using SmartPoultry.Sales;

namespace SmartPoultry.SaleLineItems
{
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

        public async Task<CreateSaleLineItemDto> InsertSaleLineItemAsync(CreateSaleLineItemDto saleLineItem)
        {
            if (saleLineItem == null)
            {
                throw new UserFriendlyException(ResponseMessages.InvalidData);
            }
            Models.Item item = await _itemService.GetById(saleLineItem.ItemId);
            bool isValidQuantity = await _itemService.ValidateAndSubstractItemQuantity(item, saleLineItem.Quantity);
            if (!isValidQuantity)
            {
                throw new UserFriendlyException(ResponseMessages.InValidQuantity);
            }

            var newSaleLineItem = _mapper.Map<SaleLineItem>(saleLineItem);
            newSaleLineItem = await _saleLineItemsRepository.InsertAsync(newSaleLineItem);
            await _salesService.UpdateSaleAmount(saleLineItem.SaleId, saleLineItem.Quantity, item.Price);

            return _mapper.Map<CreateSaleLineItemDto>(newSaleLineItem);
        }

    }
}
