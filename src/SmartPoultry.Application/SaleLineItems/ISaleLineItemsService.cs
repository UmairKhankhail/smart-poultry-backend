using Abp.Application.Services;
using SmartPoultry.SaleLineItems.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartPoultry.SaleLineItems
{
    public interface ISaleLineItemsService : IApplicationService
    {
        Task<List<GetSaleItemsDto>> GetAllSaleLineItems();
        Task<CreateSaleLineItemDto> InsertSaleLineItemAsync(CreateSaleLineItemDto saleLineItem);
        Task<CreateSaleLineItemDto> UpdateSaleLineItemAsync(UpdateSaleLineItemDto saleLineItem);
        Task<bool> DeleteSaleLineItemAsync(int id);
    }
}
