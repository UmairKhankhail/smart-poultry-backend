using Abp.Application.Services;
using Abp.UI;
using AutoMapper;
using SmartPoultry.Category.Dto;
using SmartPoultry.Common;
using SmartPoultry.EntityFrameworkCore;
using SmartPoultry.EntityFrameworkCore.Repositories;
using SmartPoultry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static SmartPoultry.Shared.ApplicationContants;

namespace SmartPoultry.Category
{
    [RemoteService(false)]
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(CategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<List<Models.Category>> GetAllCategoriesAsync()
        {
            List<Models.Category> categories = await _categoryRepository.GetAllListAsync();
            return categories;
        }
        public async Task<CreateCategoryDto> InsertCategoryAsync(CreateCategoryDto category)
        {
            if (category == null)
            {
                throw new UserFriendlyException(ResponseMessages.InvalidData);
            }

            var newCategory = _mapper.Map<Models.Category>(category);
            newCategory = await _categoryRepository.InsertAsync(newCategory);

            return _mapper.Map<CreateCategoryDto>(newCategory);
        }
        public async Task<CreateCategoryDto> UpdateCategoryAsync(UpdateCategoryDto category)
        {
            if (category == null || category.Id <= 0)
            {
                throw new UserFriendlyException(ResponseMessages.InvalidData);
            }

            var existingCategory = await _categoryRepository.GetAsync(category.Id);
            if (existingCategory == null)
            {
                throw new UserFriendlyException(ResponseMessages.RecordNotFound);
            }

            _mapper.Map(category, existingCategory);

            await _categoryRepository.UpdateAsync(existingCategory);

            return _mapper.Map<CreateCategoryDto>(existingCategory);
        }
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            if (id <= 0)
            {
                throw new UserFriendlyException(ResponseMessages.InvalidData);
            }

            var existingCategory = await _categoryRepository.GetAsync(id);
            if (existingCategory == null)
            {
                throw new UserFriendlyException(ResponseMessages.RecordNotFound);
            }

            await _categoryRepository.DeleteAsync(existingCategory);
            return true;
        }
    }
}
