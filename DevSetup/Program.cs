using System;
using System.Collections.Generic;
using Kata.Payments.Data;
using Kata.Payments.Data.DataSeeder;
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
            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();            

            BuildSuperMarketDatabase(serviceProvider, args);
            
            BuildPaymentsDatabase(serviceProvider, args);
        }

        private static void BuildSuperMarketDatabase(IServiceProvider serviceProvider, string[] args)
        {
            var appDbContextFactory = new AppDbContextFactory();

            using var dbContext = appDbContextFactory.CreateDbContext(args);

            dbContext.Database.EnsureDeleted();

            dbContext.Database.Migrate();           

            var dataContextSeeder = serviceProvider.GetService<IEnumerable<IDataContextSeeder>>();

            foreach (var seeder in dataContextSeeder)
            {
                seeder.Seed(dbContext);
            }
        }

        private static void BuildPaymentsDatabase(IServiceProvider serviceProvider, string[] args)
        {
            var appDbContextFactory = new KataPaymentsDbContextFactory();

            using var dbContext = appDbContextFactory.CreateDbContext(args);

            dbContext.Database.EnsureDeleted();

            dbContext.Database.Migrate();

            var dataContextSeeder = serviceProvider.GetService<IEnumerable<IDatabaseContextSeeder>>();

            foreach (var seeder in dataContextSeeder)
            {
                seeder.Seed(dbContext);
            }
        }

        private static void ConfigureServices(ServiceCollection serviceCollection)
        {
            DiSuperMarketData.Configure(serviceCollection);
            DiKataPaymentData.Configure(serviceCollection);
        }
    }
}
