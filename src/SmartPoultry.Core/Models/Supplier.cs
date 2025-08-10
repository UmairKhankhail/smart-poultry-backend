using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SmartPoultry.Models
{
    public class Supplier : Entity<int>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
