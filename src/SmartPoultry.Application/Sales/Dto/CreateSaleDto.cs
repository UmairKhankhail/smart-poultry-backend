using Abp.AutoMapper;
using SmartPoultry.Models;
using System;

namespace SmartPoultry.Sales.Dto
{
    [AutoMapTo(typeof(Sale))]
    public class CreateSaleDto
    {
        public int CustomerId { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }

    }
}
