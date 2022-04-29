using System;
using System.Collections.Generic;
using System.Linq;
using Kata.Payments.Data.Products;
using Microsoft.EntityFrameworkCore;

namespace Kata.Payments.Data.DataSeeder
{
    public sealed class ProductsSeeder : IDatabaseContextSeeder
    {
        public static Guid NewMembershipProductId => new Guid("560fa1fc-0995-4d99-bf99-3e9f56c7a3d0");
        public static Guid UpgradeMembershipProductId => new Guid("a04f2e6f-a143-49ed-9077-135fe57819c9");
        public static Guid PhysicalProductId => new Guid("36821256-9948-418a-ba45-0e2d16c90f3b");
        public static Guid BookProductId => new Guid("9c6a01cf-f828-4fc2-9422-15f7522ba44e");
        public static Guid LearningToSkiVideoId => new Guid("13698805-eee3-42db-b73a-d5b27397b146");
        public static Guid FirstAidVideoId => new Guid("f61d8a12-b3f3-44f3-9688-31badd13d7ed");

        public void Seed(DbContext dbContext)
        {
            if (dbContext is KataPaymentDbContext kataPaymentDbContext)
            {
                if (kataPaymentDbContext.Products.Any())
                    return;

                var products = CreatProducts();

                kataPaymentDbContext.AddRange(products);

                kataPaymentDbContext.SaveChanges();
            }
        }

        private static List<ProductDto> CreatProducts()
        {
            return new List<ProductDto>
            {
                new ProductDto
                {
                    Id = NewMembershipProductId,
                    Name = "New Membership Product",
                    ProductType = 2,
                    Category = 2
                },
                new ProductDto
                {
                    Id = UpgradeMembershipProductId,
                    Name = "Upgrade Membership Product",
                    ProductType = 2,
                    Category = 2
                },
                new ProductDto
                {
                    Id = PhysicalProductId,
                    Name = "Physical Product",
                    ProductType = 1,
                    Category = 0
                },
                new ProductDto
                {
                    Id = BookProductId,
                    Name = "This is a book",
                    ProductType = 1,
                    Category = 1
                },
                new ProductDto
                {
                    Id = LearningToSkiVideoId,
                    Name = "Learning to Ski Video",
                    ProductType = 2,
                    Category = 3
                },
                new ProductDto
                {
                    Id = FirstAidVideoId,
                    Name = "First Aid Video",
                    ProductType = 2,
                    Category = 3
                },
            };
        }
    }
}
