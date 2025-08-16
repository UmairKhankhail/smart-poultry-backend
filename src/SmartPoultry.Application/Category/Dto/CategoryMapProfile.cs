using AutoMapper;
using System.Collections.Generic;

namespace SmartPoultry.Category.Dto
{
    public class CategoryMapProfile : Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<CreateCategoryDto, Models.Category>();
            CreateMap<Models.Category,CreateCategoryDto>();
            CreateMap<List<Models.Category>,List<CreateCategoryDto>>();
            CreateMap<UpdateCategoryDto,Models.Category>();
        }
    }
}
