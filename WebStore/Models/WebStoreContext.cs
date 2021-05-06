using Microsoft.EntityFrameworkCore;

namespace WebStore.Models
{
    public class WebStoreContext : DbContext
    {
        public virtual DbSet<Clothes> Clothes { get; set; }
        public virtual DbSet<ClothesColors> ClothesColors { get; set; }
        public virtual DbSet<ClothesOrders> ClothesOrders { get; set; }
        public virtual DbSet<ClothesSizes> ClothesSizes { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Type> Types { get; set; }

        public WebStoreContext(DbContextOptions<WebStoreContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
