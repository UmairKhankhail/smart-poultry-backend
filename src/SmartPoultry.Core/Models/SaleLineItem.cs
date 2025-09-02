using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartPoultry.Models
{
    public class SaleLineItem : Entity<int>
    {
        [ForeignKey(nameof(Sale))]
        public int SaleId { get; set; }

        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        public decimal Average { get; set; }
        public decimal Rate { get; set; }
        public decimal Weight { get; set; }
        public decimal TotalAmount { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual Item Item{ get; set; }
    }
}
