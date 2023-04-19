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
    public class UserWriteRepository : RepositoryWrite<User>, IUserWriteRepository
    {
        public UserWriteRepository(DiscountContext context) : base(context)
        {
        }
    }
}
