using Kata.Payments.Domain.Payments.Models;

namespace Kata.Payments.Domain.Payments.Services
{
    public interface IShippingService
    {
        void ProcessShipping(Product product);
    }
}