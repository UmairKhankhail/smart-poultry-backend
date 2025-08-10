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
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }

        public virtual Sale Sale { get; set; }
        public virtual Item Item{ get; set; }
    }
}
