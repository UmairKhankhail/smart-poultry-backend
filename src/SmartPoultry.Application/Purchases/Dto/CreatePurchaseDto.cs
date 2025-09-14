using Abp.AutoMapper;
using SmartPoultry.Models;
using System;

namespace SmartPoultry.Purchases.Dto
{
    [AutoMapTo(typeof(Models.Purchase))]
    public class CreatePurchaseDto
    {
        public int SupplierId { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
    }
}
