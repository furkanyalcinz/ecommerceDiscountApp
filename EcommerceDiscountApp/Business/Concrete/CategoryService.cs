using Business.Abstact;
using Business.Utilities.Result;
using DataAccess.Abstact.CategoryRepository;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;

        public CategoryService(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<IResult> AddCategory(AddCategoryDTO categoryDTO)
        {
            Category category = new Category();
            category.CategoryName = categoryDTO.CategoryName;
            var result = await _categoryWriteRepository.AddAsync(category);
            return result ? new SuccessResult() : new ErrorResult();
        }

        public async Task<IResult> DeleteCategory(Category category)
        {
            var result = _categoryWriteRepository.Remove(category);
            return result ? new SuccessResult() : new ErrorResult();
        }

        public Task<IDataResult<IQueryable<Category>>> GetAllCategories()
        {
            var response =  _categoryReadRepository.GetAll(tracking:false);
            var result = new SuccessDataResult<IQueryable<Category>>(data: response);
            return Task.FromResult<IDataResult<IQueryable<Category>>>(result);
        }

        public async Task<IDataResult<Category>> GetCategoryById(uint category_id)
        {
            try
            {
                var response = await _categoryReadRepository.GetSingleAsync(c => c.Id == category_id);

                return new SuccessDataResult<Category>(response);
            }
            catch
            {
                return new ErrorDataResult<Category>();
            }
        }

        public async Task<IResult> UpdateCategory(Category category)
        {
            var result = _categoryWriteRepository.Update(category);
            
            
            return result ? new SuccessResult():new ErrorResult();
        }
    }
}
