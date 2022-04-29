using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kata.Payments.Data.DataSeeder
{
    public interface IDatabaseContextSeeder
    {
        void Seed(DbContext dbContext);
    }
}