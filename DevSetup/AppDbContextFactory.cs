using Kata.SuperMarket.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DevSetup
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var connectionString = "Data Source=localhost\\MSSQLLocalDB;Initial Catalog=SuperMarket;Integrated Security=True;";

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            builder.UseSqlServer(connectionString, x => x.MigrationsAssembly("Kata.SuperMarket.Data")
                                                         .MigrationsHistoryTable("AppDbVersion"));

            return new ApplicationDbContext(builder.Options);
        }
    }
}
