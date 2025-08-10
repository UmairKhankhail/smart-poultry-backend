using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartPoultry.Models
{
    public class PurchaseLineItem : Entity<int>
    {
        [ForeignKey(nameof(Purchase))]
        public int PurchaseId { get; set; }

        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }

        public virtual Purchase Purchase { get; set; }
        public virtual Item Item { get; set; }
    }
}
