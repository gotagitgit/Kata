using System.Threading.Tasks;
using Kata.Payments.Data.Products;
using Kata.Payments.Domain.Products.Models;

namespace Kata.Payments.Domain.Products.Factory
{
    public interface IProductFactory
    {
        ValueTask<Product> ToModelAsync(ProductDto dto);
    }
}