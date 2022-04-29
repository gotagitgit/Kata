using Kata.Payments.Domain.Products.Models;

namespace Kata.Payments.Domain.Products.Services
{
    public interface IShippingService
    {
        void ProcessShipping(Product product);
    }
}