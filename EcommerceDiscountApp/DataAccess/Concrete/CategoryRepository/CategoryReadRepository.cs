using DataAccess.Abstact.CategoryRepository;
using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.CategoryRepository
{
    public class CategoryReadRepository : RepositoryRead<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(DiscountContext context) : base(context)
        {
        }
    }
}
