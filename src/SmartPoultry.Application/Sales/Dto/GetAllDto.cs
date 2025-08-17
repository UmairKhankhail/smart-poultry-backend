using System;

namespace SmartPoultry.Sales.Dto
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
        public CustomerDto Customer { get; set; }
    }
}
