using Business.Abstact;
using Business.Utilities.Result;
using DataAccess.Abstact.DiscountsRepository;
using DataAccess.Abstact.ProductRepository;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountsReadRepository _readRepository;
        private readonly IDiscountsWriteRepository _writeRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public DiscountService(IDiscountsReadRepository readRepository, IDiscountsWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<IResult> AddDiscount(AddDiscountDTO Discount)
        {
            var discount = new Discounts();
            discount.StartDate = Discount.StartDate;
            discount.EndDate = Discount.EndDate;
            discount.Rate = Discount.Rate;
            discount.CategoryId = Discount.CategoryId;

            return await _writeRepository.AddAsync(discount) ? new SuccessResult() : new ErrorResult();
        }

        public Task<IResult> DeleteDiscount(Discounts discounts)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Discounts>> GetAllDiscount()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IQueryable<Discounts>>> GetDiscountsByCategoryId(uint categoryId)
        {
            var discounts = _readRepository.GetWhere(x=>x.CategoryId == categoryId);
            var result = new SuccessDataResult<IQueryable<Discounts>>(data: discounts);
            return Task.FromResult<IDataResult<IQueryable<Discounts>>>(result);
        }

        public Task<IResult> UpdateDiscount(Discounts discounts)
        {
            throw new NotImplementedException();
        }
        
        
    }
}
