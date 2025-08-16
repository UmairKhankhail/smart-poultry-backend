using Abp.Application.Services;
using SmartPoultry.Category.Dto;
using SmartPoultry.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartPoultry.Category
{
    public interface ICategoryService : IApplicationService
    {
        Task<List<Models.Category>> GetAllCategoriesAsync();
        Task<CreateCategoryDto> InsertCategoryAsync(CreateCategoryDto category);
        Task<CreateCategoryDto> UpdateCategoryAsync(UpdateCategoryDto category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
