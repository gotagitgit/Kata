using System;
using System.Collections.Generic;
using System.Linq;
using Kata.SuperMarket.Data.Stocks;

namespace Kata.SuperMarket.Data.DataSeeder
{
    public sealed class StockSeeder : IDataContextSeeder
    {
        public void Seed(ApplicationDbContext context)
        {
            if (!context.Stocks.Any())
            {

                var stocks = new List<StockDto>
                {
                    new StockDto
                    {
                        Id = new Guid("aeecb15e-0f97-45bd-81cd-f21aa5d856a1"),
                        Name = "Bundled Stock",
                        Price = 1.5m,
                        Uom = 4 // Bundle
                    },
                    new StockDto
                    {
                        Id = new Guid("cdb45229-2b4e-4ce1-be35-8ddc092cb1d3"),
                        Name = "Buy 2 Get 1 Free Stock",
                        Price = 2.5m,
                        Uom = 3 // pc
                    },
                    new StockDto
                    {
                        Id = new Guid("dd913c78-9134-420c-aeb7-09f02a229d7d"),
                        Name = "Converted weight Stock",
                        Price = 1.99m,
                        Uom = 2 // oz
                    }
                };

                context.AddRange(stocks);
                context.SaveChanges();
            }
        }
    }
}
