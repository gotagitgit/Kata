using Kata.Payments.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DevSetup
{
    public sealed class KataPaymentsDbContextFactory : IDesignTimeDbContextFactory<KataPaymentDbContext>
    {
        public KataPaymentDbContext CreateDbContext(string[] args)
        {
            var connectionString = "Data Source=localhost\\MSSQLLocalDB;Initial Catalog=OrderPayment;Integrated Security=True;";

            var builder = new DbContextOptionsBuilder<KataPaymentDbContext>();

            builder.UseSqlServer(connectionString, x => x.MigrationsAssembly("Kata.Payments.Data")
                                                         .MigrationsHistoryTable("AppDbVersion"));

            return new KataPaymentDbContext(builder.Options);
        }
    }
}
