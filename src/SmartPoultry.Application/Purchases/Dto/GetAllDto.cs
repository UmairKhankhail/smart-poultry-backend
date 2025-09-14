using SmartPoultry.Purchases.Dto;
using SmartPoultry.Sales.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoultry.Purchases.Dto
{
    public class GetAllDto
    {
        public int Id { get; set; }
        public DateTime? CreationTime { get; set; }
        public double? TotalAmount { get; set; }
        public double? PaidAmount { get; set; }
        public double? DueAmount { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }
        public SupplierDto Supplier { get; set; }
    }
}
