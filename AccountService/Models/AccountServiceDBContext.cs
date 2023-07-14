using Microsoft.EntityFrameworkCore;

public class AccountServiceDBContext : DbContext
{
    public AccountServiceDBContext()
    {

    }

    public AccountServiceDBContext(DbContextOptions<AccountServiceDBContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    public DbSet<User> Users { get; set; }
}