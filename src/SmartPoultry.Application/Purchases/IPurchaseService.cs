using Abp.Application.Services;
using SmartPoultry.Purchases.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartPoultry.Purchase
{
    public interface IPurchaseService : IApplicationService
    {
        Task<List<GetAllDto>> GetAllPurchasesAsync();
        Task<CreatePurchaseDto> InsertPurchaseAsync(CreatePurchaseDto purchase);
        Task<CreatePurchaseDto> UpdatePurchaseAsync(UpdatePurchaseDto purchase);
        Task<bool> DeletePurcahseAsync(int id);
        Task UpdatePurchaseAmount(int saleId, decimal amount);
    }
}
