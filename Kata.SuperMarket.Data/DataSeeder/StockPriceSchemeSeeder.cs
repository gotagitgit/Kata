using System;
using System.Collections.Generic;
using System.Linq;
using Kata.SuperMarket.Data.StockPriceSchemes;

namespace Kata.SuperMarket.Data.DataSeeder
{
    public sealed class StockPriceSchemeSeeder : IDataContextSeeder
    {
        public void Seed(ApplicationDbContext context)
        {
            if (!context.StockPriceSchemes.Any())
            {

                var priceSchemes = new List<StockPriceSchemeDto>
                {
                    new StockPriceSchemeDto
                    {
                        Id = Guid.NewGuid(),
                        StockId = new Guid("aeecb15e-0f97-45bd-81cd-f21aa5d856a1"),
                        PriceScheme = 0,
                        IsActive = true,
                        PriceSchemeDetail = CreateBundledPriceScheme(2, 2.50m)
                    }
                };

                context.AddRange(priceSchemes);
                context.SaveChanges();
            }
        }

        private static string CreateBundledPriceScheme(int countPerBundle, decimal price)
        {
            return $@"
<PriceSchemeDetail>
	<CountPerBundle>{countPerBundle}</CountPerBundle>
	<Price>{price}</Price>
</PriceSchemeDetail>";
        }
    }
}
