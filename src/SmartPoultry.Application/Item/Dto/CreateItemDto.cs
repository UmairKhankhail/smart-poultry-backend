using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoultry.Item.Dto
{
    [AutoMapTo(typeof(Models.Item))]
    public class CreateItemDto
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public string UnitOfMeasure { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

    }
}