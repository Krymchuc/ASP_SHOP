using Microsoft.EntityFrameworkCore;

namespace ASP_MVC_Shop.Models
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options): base(options)
        {

        }
        public DbSet<CatalogItem> CatalogItems { get; set; }
    }
}
