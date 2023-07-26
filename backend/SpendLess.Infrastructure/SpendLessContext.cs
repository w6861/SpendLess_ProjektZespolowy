using Microsoft.EntityFrameworkCore;
using SpendLess.Infrastructure.Models;

namespace SpendLess.Infrastructure;

public class SpendLessContext : DbContext
{
    public SpendLessContext(DbContextOptions<SpendLessContext> options) : base(options)
    {
    }

    public DbSet<DbExpense> Expenses { get; set; }
    public DbSet<DbCategory> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbCategory>()
            .HasKey(c => c.CategoryId);

        modelBuilder.Entity<DbCategory>()
            .HasMany(c => c.Expenses)
            .WithOne(c => c.Category);

        modelBuilder.Entity<DbCategory>()
            .HasData(
            new DbCategory
            {
                CategoryId = Guid.Parse("432ad70b-8ef5-407d-b375-2bd185426de8"),
                Name = "Rachunki"
            },
            new DbCategory
            {
                CategoryId = Guid.Parse("970d8398-765b-44d2-aef8-9205a6b43ef6"),
                Name = "Wydatki stałe"
            },
            new DbCategory
            {
                CategoryId = Guid.Parse("8aa3dcc6-6e03-43f6-b6b0-83ad31e343f9"),
                Name = "Zdrowie"
            },
            new DbCategory
            {
                CategoryId = Guid.Parse("f937ad10-43fe-41fa-a899-2c6db467ef61"),
                Name = "Transport/Paliwo"
            });

        modelBuilder.Entity<DbExpense>()
            .ToTable("Expenses")
            .HasKey(e => e.ExpenseId);

        modelBuilder.Entity<DbExpense>()
            .ToTable("Expenses")
            .Property(e => e.Amount)
            .HasColumnType("decimal(18,2)");
    }
}

