using Abp.Application.Services;
using SmartPoultry.Models;
using SmartPoultry.Sales.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoultry.Sales
{
    public interface ISalesService : IApplicationService
    {
        Task<List<GetAllDto>> GetAllSalesAsync();
        Task<CreateSaleDto> InsertSaleAsync(CreateSaleDto sale);
        Task<CreateSaleDto> UpdateSaleAsync(UpdateSaleDto sale);
        Task<bool> DeleteSaleAsync(int id);
        Task UpdateSaleAmount(int saleId, double quantity, double price);
    }
}
