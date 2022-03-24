using System;
using System.Collections.Generic;
using Kata.SupermarketPricing;
using Kata.SupermarketPricing.Models;
using Kata.SupermarketPricing.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kata.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            ComputeProductCost(serviceCollection);

            Console.ReadLine();
        }

        private static void ComputeProductCost(ServiceCollection serviceCollection)
        {

            var item1 = new Item(new Product("Simple Product", 2.50, new SimplePriceScheme()), 2);

            var item2 = new Item(new Product("Apple by 3s", 1.99, new GroupOf3ItemsPriceScheme()), 4);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var itemService = serviceProvider.GetService<IItemService>();

            var items = new List<Item>
            {
                item1,
                item2
            };

            var totalCost = itemService.ComputeCost(items);

            foreach (var item in items)
            {
                var product = item.Product;

                Console.WriteLine($"{product.Name} @ {product.Price} with a quantity of {item.Quantity} \t\t {item.ComputeItemCost()}");
            }

            Console.WriteLine($"\n\nItem Count \t\t {items.Count}");
            Console.WriteLine($"Total Cost \t\t {totalCost}");
        }

        private static void ConfigureServices(ServiceCollection serviceCollection)
        {
            DiSupermarketPricing.Configure(serviceCollection);
        }
    }
}
