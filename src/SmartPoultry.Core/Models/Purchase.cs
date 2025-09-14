using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Abp.Domain.Entities.Auditing;

namespace SmartPoultry.Models
{
    public class Purchase : FullAuditedEntity<int>
    {
        [ForeignKey(nameof(Supplier))]
        public int SupplierId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<PurchaseLineItem> PurchaseLineItems { get; set; }
    }
}
