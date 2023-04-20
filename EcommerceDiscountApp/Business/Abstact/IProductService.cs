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
    public interface IProductService
    {
        Task<IResult> AddProduct(Product product);
        Task<IResult> UpdateProduct(Product product);
        Task<IResult> DeleteProduct(Product product);
        Task<IDataResult<IQueryable<Product>>> GetAllProducts();
        Task<IDataResult<Product>> GetById(int id);
        Task<IDataResult<IQueryable<Product>>> GetProducts(GetProductsFilterDTO getProductsFilter);
    }
}
