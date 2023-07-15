using Microsoft.EntityFrameworkCore;

namespace CheckOutService.Models
{
    public class CheckOutServiceDBContext : DbContext
    {
        public CheckOutServiceDBContext()
        {
            
        }

        public CheckOutServiceDBContext(DbContextOptions<CheckOutServiceDBContext> options) : base(options) 
        { 

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasOne(o => o.user).WithMany(u => u.orders).HasForeignKey(o => o.userGuid);
            modelBuilder.Entity<Product>().HasOne(p => p.order).WithMany(o => o.products).HasForeignKey(p => p.orderGuid);
        }
    }
}
