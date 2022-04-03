using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kata.SupermarketPricing.Models;

namespace Kata.SupermarketPricing.Repository
{
    public sealed class ProductRepository
    {
        public IList<Product> FindAll()
        {
            return new List<Product>
            {
                //new Product("Simple Product", 2.50, new SimplePriceScheme() ),
                //new Product("Apple by 3s", 1.99, new BundledProductPriceScheme())
            };
        }
    }
}
