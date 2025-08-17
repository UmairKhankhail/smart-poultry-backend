using Abp.AutoMapper;
using SmartPoultry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoultry.Sales.Dto
{
    [AutoMapTo(typeof(Sale))]
    public class UpdateSaleDto : CreateSaleDto
    {
        public int Id { get; set; }
        public decimal? PaidAmount { get; set; }
    }
}
