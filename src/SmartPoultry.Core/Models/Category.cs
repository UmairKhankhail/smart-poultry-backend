using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SmartPoultry.Models
{
    public class Category : Entity<int>
    {
        [StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
