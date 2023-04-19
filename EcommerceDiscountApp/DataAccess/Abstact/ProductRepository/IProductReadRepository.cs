﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstact.ProductRepository
{
    public interface IProductReadRepository:IRepositoryRead<Product>
    {
    }
}
