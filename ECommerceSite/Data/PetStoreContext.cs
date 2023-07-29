using Microsoft.EntityFrameworkCore;
namespace ECommerceSite.Data
{
    public class PetStoreContext : DbContext
    {
        public PetStoreContext(DbContextOptions<PetStoreContext> options) : base(options)
        {

        }
        public DbSet<Models.Product> Products { get; set; }
    }
}
