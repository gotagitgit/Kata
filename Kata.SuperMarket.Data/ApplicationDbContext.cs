using Kata.SuperMarket.Data.StockPriceSchemes;
using Kata.SuperMarket.Data.Stocks;
using Microsoft.EntityFrameworkCore;

namespace Kata.SuperMarket.Data
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<StockDto> Stocks { get; set; }

        public DbSet<StockPriceSchemeDto> StockPriceSchemes { get; set; }        
    }
}
