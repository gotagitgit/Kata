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
                    },
                    new StockPriceSchemeDto
                    {
                        Id = Guid.NewGuid(),
                        StockId = new Guid("cdb45229-2b4e-4ce1-be35-8ddc092cb1d3"),
                        PriceScheme = 1,
                        IsActive = true,
                        PriceSchemeDetail = CreateBuyAndGetFreePriceScheme(2, 1)
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

        private static string CreateBuyAndGetFreePriceScheme(int pricedItemCount, int freeItemCount)
        {
            return $@"
<PriceSchemeDetail>
	<PricedItemCount>{pricedItemCount}</PricedItemCount>
	<FreeItemCount>{freeItemCount}</FreeItemCount>
</PriceSchemeDetail>";
        }
    }
}
