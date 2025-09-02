using SmartPoultry.Item.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoultry.SaleLineItems.Dto
{
    public class GetSaleItemsDto
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public ItemDto Item { get; set; }
        public decimal Average { get; set; }
        public decimal Rate { get; set; }
        public decimal Weight { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
