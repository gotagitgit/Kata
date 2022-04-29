using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kata.Payments.Domain.Products.Models;

namespace Kata.Payments.Domain.Products.Services
{
    public sealed class ShippingService : IShippingService
    {

        //public ShippingService(CourierRepository courierRepository, CustomerRepository)
        //{

        //}

        public void ProcessShipping(Product product)
        {
            if (product.Category == ProductCategory.Book)
            {
                // handle duplicate packing slip packingSlipForRoyaltyService;
                
            }
            
            // hanlde packing slip
        }
    }
}
