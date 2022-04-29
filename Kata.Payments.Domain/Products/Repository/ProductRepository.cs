using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Kata.Payments.Data.Products;
using Kata.Payments.Domain.Products.Factory;
using Kata.Payments.Domain.Products.Models;

namespace Kata.Payments.Domain.Products.Repository
{
    public sealed class ProductRepository : IProductRepository
    {
        private readonly IProductDao _productDao;
        private readonly IProductFactory _productFactory;

        public ProductRepository(
            IProductDao productDao,
            IProductFactory productFactory)
        {
            _productDao = productDao;
            _productFactory = productFactory;
        }

        public async ValueTask<ImmutableList<Product>> FindAllAsync()
        {
            var products = await _productDao.FindAllAsync();

            var result = ImmutableList<Product>.Empty;

            var builder = result.ToBuilder();

            foreach (var productDto in products)
            {
                var product = await _productFactory.ToModelAsync(productDto);

                builder.Add(product);
            }

            return builder.ToImmutable();
        }

        public async ValueTask<Product> FindAsync(Guid id)
        {
            var productDto = await _productDao.FindAsync(id);

            return await _productFactory.ToModelAsync(productDto);
        }
    }
}
