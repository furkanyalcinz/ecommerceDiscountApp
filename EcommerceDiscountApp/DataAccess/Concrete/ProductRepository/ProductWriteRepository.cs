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
    public class ProductWriteRepository : RepositoryWrite<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(DiscountContext context) : base(context)
        {
        }
    }
}
