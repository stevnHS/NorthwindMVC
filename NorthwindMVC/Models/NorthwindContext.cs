using Microsoft.EntityFrameworkCore;

namespace NorthwindMVC.Models
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options): base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

    }
}
