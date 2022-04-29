using System.Collections.Generic;
using Kata.SuperMarket.Data;
using Kata.SuperMarket.Data.DataSeeder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DevSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            var appDbContextFactory = new AppDbContextFactory();

            using var dbContext = appDbContextFactory.CreateDbContext(args);

            dbContext.Database.EnsureDeleted();

            dbContext.Database.Migrate();

            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var dataContextSeeder = serviceProvider.GetService<IEnumerable<IDataContextSeeder>>();

            foreach (var seeder in dataContextSeeder)
            {
                seeder.Seed(dbContext);
            }
        }

        private static void ConfigureServices(ServiceCollection serviceCollection)
        {
            DiSuperMarketData.Configure(serviceCollection);
        }
    }
}
