using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Kata.SuperMarket.Data;
using Kata.SuperMarket.Data.DataSeeder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kata.SuperMarketCheckout.Api.Tests
{
    public sealed class TestFixture : IDisposable
    {
        public TestFixture()
        {
            var application = new CheckoutApplication();

            Client = application.CreateClient();
        }

        public HttpClient Client { get; }

        public void Dispose()
        {
            Client.Dispose();
        }
    }

    class CheckoutApplication : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                
                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseInMemoryDatabase("CheckoutsInMemoryDb");
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var dbContext = scopedServices.GetRequiredService<ApplicationDbContext>();

                    dbContext.Database.EnsureDeleted();
                    dbContext.Database.EnsureCreated();

                    var dataContextSeeder = scopedServices.GetService<IEnumerable<IDataContextSeeder>>();

                    foreach (var seeder in dataContextSeeder)
                    {
                        seeder.Seed(dbContext);
                    }
                }
            });
        }
    }
}
