namespace Kata.SuperMarket.Data.DataSeeder
{
    public interface IDataContextSeeder
    {
        void Seed(ApplicationDbContext context);
    }
}