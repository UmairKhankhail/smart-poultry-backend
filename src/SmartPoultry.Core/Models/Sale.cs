using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartPoultry.Models
{
    public class Sale : FullAuditedEntity<int>
    {
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public double TotalAmount { get; set; }
        public double PaidAmount { get; set; }
        public double DueAmount { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<SaleLineItem> SaleLineItems { get; set; }
    }
}
