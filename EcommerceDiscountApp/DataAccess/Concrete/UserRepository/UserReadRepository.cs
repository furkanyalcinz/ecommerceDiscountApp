using DataAccess.Abstact.UserRepository;
using DataAccess.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.UserRepository
{
    public class UserReadRepository : RepositoryRead<User>, IUserReadRepository
    {
        public UserReadRepository(DiscountContext context) : base(context)
        {
        }
    }
}
