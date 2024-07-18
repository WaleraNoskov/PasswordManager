using Microsoft.EntityFrameworkCore;
using PasswordManager.Core;

namespace PasswordManager.Infrastructure;

public class PasswordManagerDbContext : DbContext
{
    public DbSet<WebAddressPassword> WebAddressPasswords { get; set; }
    public DbSet<WebLinkPassword> WebLinkPasswords { get; set; }

    public PasswordManagerDbContext(DbContextOptions<PasswordManagerDbContext> options) : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        options.UseSqlite($"Data Source={Path.Join(path, "passwordManager.db")}");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<WebAddressPassword>(options =>
        {
            options.HasKey(e => e.Id);
            options.OwnsOne(e => e.EmailAddress);
            options.OwnsOne(e => e.Password);
        });
        builder.Entity<WebLinkPassword>(options =>
        {
            options.HasKey(e => e.Id);
            options.OwnsOne(e => e.WebLink);
            options.OwnsOne(e => e.Password);
        });

        base.OnModelCreating(builder);
    }
}
