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
        IResult AddCategory(AddCategoryDTO categoryDTO);
        IDataResult<List<Category>> GetAllCategories(Category categoryFilter);
        IDataResult<Category> GetCategory(Category category);
        IResult UpdateCategory(Category category);
        IResult DeleteCategory(Category category);
    }
}
