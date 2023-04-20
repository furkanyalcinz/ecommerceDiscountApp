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
    public interface IDiscountService
    {
        Task<IResult> AddDiscount(AddDiscountDTO Discount);
        Task<IResult> UpdateDiscount(Discounts discounts);
        Task<IResult> DeleteDiscount(Discounts discounts);
        Task<IDataResult<Discounts>> GetAllDiscount();
        Task<IDataResult<IQueryable<Discounts>>> GetDiscountsByCategoryId(uint categoryId);
        public Task ApplayDiscounts();


    }
}
