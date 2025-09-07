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
        public int Id { get; set; }
        public string Name { get; set; }
        public string UnitOfMeasure { get; set; }
        public string Description { get; set; }
        public Models.Category Category { get; set; }
    }
}
