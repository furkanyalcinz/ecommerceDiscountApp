using DataAccess.Abstact.ProductRepository;
using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.ProductRepository
{
    public class ProductReadRepository : RepositoryRead<Product>, IProductReadRepository
    {
        public ProductReadRepository(DiscountContext context) : base(context)
        {
        }
    }
}
