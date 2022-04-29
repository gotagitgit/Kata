using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Kata.Payments.Domain.Products.Models;

namespace Kata.Payments.Domain.Products.Repository
{
    public interface IProductRepository
    {
        ValueTask<ImmutableList<Product>> FindAllAsync();
        ValueTask<Product> FindAsync(Guid id);
    }
}