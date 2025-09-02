
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoultry.SaleLineItems.Dto
{
    public class CreateSaleLineItemDto
    {
        public int SaleId { get; set; }
        public int ItemId { get; set; }
        public decimal Average { get; set; }
        public decimal Rate { get; set; }
        public decimal Weight { get; set; }
    }
}
