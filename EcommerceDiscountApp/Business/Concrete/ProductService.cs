using Business.Abstact;
using Business.Utilities.Result;
using DataAccess.Abstact.ProductRepository;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductReadRepository _readRepository;
        private readonly IProductWriteRepository _writeRepository;

        public ProductService(IProductReadRepository readRepository, IProductWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<IResult> AddProduct(Product product)
        {
            return await _writeRepository.AddAsync(product) ? new SuccessResult(): new ErrorResult();
        }

        public async Task<IResult> DeleteProduct(Product product)
        {
            return _writeRepository.Remove(product) ? new SuccessResult() : new ErrorResult();
        }

        public Task<IDataResult<IQueryable<Product>>> GetAllProducts()
        {
            var response = _readRepository.GetAll(tracking: false);
            var result = new SuccessDataResult<IQueryable<Product>>(data:response);
            return Task.FromResult<IDataResult<IQueryable<Product>>>(result);
        }

        public async Task<IDataResult<Product>> GetById(int id)
        {
            var response = await _readRepository.GetSingleAsync(x => x.Id == id);
            var result = new SuccessDataResult<Product>(response!);
            return await Task.FromResult<IDataResult<Product>>(result);
        }

        public Task<IDataResult<IQueryable<Product>>> GetProducts(GetProductsFilterDTO getProductsFilter)
        {
            var products = _readRepository.GetWhere(x => x.ProductName == getProductsFilter.ProductName & x.CategoryId == getProductsFilter.CategoryId, tracking:false);
            return Task.FromResult<IDataResult<IQueryable<Product>>>(new SuccessDataResult<IQueryable<Product>>(products));
        }

        public async Task<IResult> UpdateProduct(Product product)
        {
            var result = _writeRepository.Update(product);
            return result ? new SuccessResult():new ErrorResult();
        }
    }
}
