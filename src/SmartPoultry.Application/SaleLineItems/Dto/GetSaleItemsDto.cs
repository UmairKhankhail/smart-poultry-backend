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
        public double Quantity { get; set; }
        public double TotalAmount { get; set; }
    }
}
