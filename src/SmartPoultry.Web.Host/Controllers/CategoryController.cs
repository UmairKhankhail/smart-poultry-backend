using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using SmartPoultry.Category;
using SmartPoultry.Category.Dto;
using SmartPoultry.Common;
using SmartPoultry.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartPoultry.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : SmartPoultryControllerBase 
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("get-all")]
        public async Task<List<Models.Category>> GetAllCategories()  
        {
            return await _categoryService.GetAllCategoriesAsync();
        }

        [HttpPost("insert")]
        public async Task<CreateCategoryDto> InsertCategory([FromBody] CreateCategoryDto category)
        {
            return await _categoryService.InsertCategoryAsync(category);
        }

        [HttpPut("update")]
        public async Task<CreateCategoryDto> UpdateCategory([FromBody] UpdateCategoryDto category)
        {
            return await _categoryService.UpdateCategoryAsync(category);
        }

        [HttpDelete("delete")]
        public async Task<bool> DeleteCategory(int id)
        {
            return await _categoryService.DeleteCategoryAsync(id);
        }
    }
}
