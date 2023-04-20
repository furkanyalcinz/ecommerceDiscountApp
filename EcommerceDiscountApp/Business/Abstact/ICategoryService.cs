using Business.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstact
{
    public interface ICategoryService
    {
        Task<IResult> AddCategory(AddCategoryDTO categoryDTO);
        Task<IDataResult<IQueryable<Category>>> GetAllCategories();
        Task<IDataResult<Category>> GetCategoryById(uint category_id);
        Task<IResult> UpdateCategory(Category category);
        Task<IResult> DeleteCategory(Category category);
    }
}
