using DataAccess.Abstact.DiscountsRepository;
using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.DiscountRepository
{
    public class DiscountWriteRepository : RepositoryWrite<Discounts>, IDiscountsWriteRepository
    {
        public DiscountWriteRepository(DiscountContext context) : base(context)
        {
        }
    }
}
