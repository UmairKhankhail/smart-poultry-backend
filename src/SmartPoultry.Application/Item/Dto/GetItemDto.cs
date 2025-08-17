using SmartPoultry.Category.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoultry.Item.Dto
{
    public class GetItemDto
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public string UnitOfMeasure { get; set; }
        public string Description { get; set; }
        public Models.Category Category { get; set; }
    }
}
