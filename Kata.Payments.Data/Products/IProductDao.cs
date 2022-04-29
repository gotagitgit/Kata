using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kata.Payments.Data.Products
{
    public interface IProductDao
    {
        Task<bool> DeleteAsync(Guid id);
        Task<List<ProductDto>> FindAllAsync();
        Task<ProductDto> FindAsync(Guid id);
        Task<bool> InsertAsync(ProductDto stock);
        Task<bool> UpdateAsync(ProductDto stock);
    }
}