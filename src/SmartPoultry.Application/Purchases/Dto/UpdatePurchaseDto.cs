using SmartPoultry.Purchases.Dto;

namespace SmartPoultry.Purchases.Dto
{
    public class UpdatePurchaseDto : CreatePurchaseDto
    {
        public int Id { get; set; }
        public decimal? PaidAmount { get; set; }
    }
}
