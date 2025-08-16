using Abp.AutoMapper;

namespace SmartPoultry.Category.Dto
{
    [AutoMapTo(typeof(Models.Category))]
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
