using Microsoft.EntityFrameworkCore;

public class AccountServiceDBContext : DbContext
{
    public AccountServiceDBContext()
    {
        this.Database.EnsureCreated();
    }

    public AccountServiceDBContext(DbContextOptions<AccountServiceDBContext> options) : base(options)
    {
        this.Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    public DbSet<User> Users { get; set; }
}