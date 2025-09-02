using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoultry.SaleLineItems.Dto
{
    public class UpdateSaleLineItemDto
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public decimal Average { get; set; }
        public decimal Rate { get; set; }
        public decimal Weight { get; set; }
    }
}
