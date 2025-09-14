using Abp.Application.Services;
using Abp.UI;
using AutoMapper;
using SmartPoultry.EntityFrameworkCore.Repositories;
using SmartPoultry.Purchases.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using static SmartPoultry.Shared.ApplicationContants;

namespace SmartPoultry.Purchase
{
    [RemoteService(false)]
    public class PurchaseService : IPurchaseService
    {
        private readonly PurchaseRepository _purchaseRepository;
        private readonly SupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        public PurchaseService(PurchaseRepository purchaseRepository, SupplierRepository supplierRepository, IMapper mapper)
        {
            _purchaseRepository = purchaseRepository;
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAllDto>> GetAllPurchasesAsync()
        {
            var query = await _purchaseRepository.GetAllIncludingAsync(x => x.Supplier);
            List<GetAllDto> purchases = _mapper.Map<List<GetAllDto>>(query);
            return purchases;
        }
        public async Task<CreatePurchaseDto> InsertPurchaseAsync(CreatePurchaseDto purchase)
        {
            if (purchase == null)
            {
                throw new UserFriendlyException(ResponseMessages.InvalidData);
            }

            await _supplierRepository.GetAsync(purchase.SupplierId);
            var newPurchase = _mapper.Map<Models.Purchase>(purchase);
            newPurchase.IsDeleted = false;
            newPurchase = await _purchaseRepository.InsertAsync(newPurchase);

            return _mapper.Map<CreatePurchaseDto>(newPurchase);
        }
        public async Task<CreatePurchaseDto> UpdatePurchaseAsync(UpdatePurchaseDto purchase)
        {
            if (purchase == null || purchase.Id <= 0)
            {
                throw new UserFriendlyException(ResponseMessages.InvalidData);
            }

            await _supplierRepository.GetAsync(purchase.SupplierId);
            var existingPurchase = await _purchaseRepository.GetAsync(purchase.Id);
            existingPurchase.DueAmount -= existingPurchase.PaidAmount;
            _mapper.Map(purchase, existingPurchase);

            await _purchaseRepository.UpdateAsync(existingPurchase);

            return _mapper.Map<CreatePurchaseDto>(existingPurchase);
        }
        public async Task<bool> DeletePurcahseAsync(int id)
        {
            if (id <= 0)
            {
                throw new UserFriendlyException(ResponseMessages.InvalidData);
            }

            var existingPurchase = await _purchaseRepository.GetAsync(id);

            await _purchaseRepository.DeleteAsync(existingPurchase);
            return true;
        }
        public async Task UpdatePurchaseAmount(int saleId, decimal amount)
        {
            Models.Purchase existingPurchase = await _purchaseRepository.GetAsync(saleId);
            existingPurchase.TotalAmount += amount;
            existingPurchase.DueAmount += amount;
            await _purchaseRepository.UpdateAsync(existingPurchase);
        }

    }
}
