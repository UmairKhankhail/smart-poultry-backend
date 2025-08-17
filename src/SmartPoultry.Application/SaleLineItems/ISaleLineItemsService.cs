using Abp.Application.Services;
using SmartPoultry.SaleLineItems.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoultry.SaleLineItems
{
    public interface ISaleLineItemsService : IApplicationService
    {
        Task<CreateSaleLineItemDto> InsertSaleLineItemAsync(CreateSaleLineItemDto saleLineItem);
    }
}
