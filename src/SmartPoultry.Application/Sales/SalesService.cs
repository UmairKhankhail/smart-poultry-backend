using Abp.Application.Services;
using Abp.UI;
using AutoMapper;
using SmartPoultry.Category.Dto;
using SmartPoultry.EntityFrameworkCore.Repositories;
using SmartPoultry.Models;
using SmartPoultry.Sales.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmartPoultry.Shared.ApplicationContants;

namespace SmartPoultry.Sales
{
    [RemoteService(false)]
    public class SalesService : ISalesService
    {
        private readonly SaleRepository _saleRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public SalesService(SaleRepository saleRepository, CustomerRepository customerRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAllDto>> GetAllSalesAsync()
        {
            var query = await _saleRepository.GetAllIncludingAsync(x => x.Customer);
            List<GetAllDto> sales = _mapper.Map<List<GetAllDto>>(query);
            return sales;
        }
        public async Task<CreateSaleDto> InsertSaleAsync(CreateSaleDto sale)
        {
            if (sale == null)
            {
                throw new UserFriendlyException(ResponseMessages.InvalidData);
            }

            await _customerRepository.GetAsync(sale.CustomerId);
            var newSale = _mapper.Map<Sale>(sale);
            newSale.IsDeleted = false;
            newSale = await _saleRepository.InsertAsync(newSale);

            return _mapper.Map<CreateSaleDto>(newSale);
        }
        public async Task<CreateSaleDto> UpdateSaleAsync(UpdateSaleDto sale)
        {
            if (sale == null || sale.Id <= 0)
            {
                throw new UserFriendlyException(ResponseMessages.InvalidData);
            }

            await _customerRepository.GetAsync(sale.CustomerId);
            var existingCategory = await _saleRepository.GetAsync(sale.Id);
            _mapper.Map(sale, existingCategory);

            await _saleRepository.UpdateAsync(existingCategory);

            return _mapper.Map<CreateSaleDto>(existingCategory);
        }
        public async Task<bool> DeleteSaleAsync(int id)
        {
            if (id <= 0)
            {
                throw new UserFriendlyException(ResponseMessages.InvalidData);
            }

            var existingSale = await _saleRepository.GetAsync(id);

            await _saleRepository.DeleteAsync(existingSale);
            return true;
        }
        public async Task UpdateSaleAmount(int saleId, double quantity , double price)
        {
            var existingSale = await _saleRepository.GetAsync(saleId);
            existingSale.TotalAmount += (price * quantity);
            await _saleRepository.UpdateAsync(existingSale);   
        }
    }
}
