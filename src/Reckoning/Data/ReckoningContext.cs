using Microsoft.EntityFrameworkCore;
using Reckoning.Core.Models;
namespace Reckoning.Data;

public class ReckoningContext(DbContextOptions<ReckoningContext> options) : DbContext(options)
{
    //Tables
    public DbSet<Account> Accounts { get; set; } = default!;
    public DbSet<Statement> Statements { get; set; } = default!;
    public DbSet<StatementTransaction> Transactions { get; set; } = default!;
    public DbSet<Email> Emails { get; set; } = default!;
    public DbSet<Phone> Phones { get; set; } = default!;

    //Entities
    public DbSet<Asset> Assets { get; set; } = default!;
    public DbSet<Income> Income { get; set; } = default!;
    public DbSet<Credit> Credit { get; set; } = default!;
    public DbSet<Loan> Loans { get; set; } = default!;
    public DbSet<Utility> Utilities { get; set; } = default!;
    public DbSet<Subscription> Subscriptions { get; set; } = default!;
    public DbSet<Miscellaneous> Miscellaneous { get; set; } = default!;
    public DbSet<Bill> Bills { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Account>()
            .HasDiscriminator(a => a.AccountType)
            .IsComplete(false);

        modelBuilder.Entity<Account>()
            .Navigation(a => a.Email)
            .IsRequired();

        modelBuilder.Entity<Account>()
            .Navigation(a => a.Phone)
            .IsRequired();

        modelBuilder.Entity<Email>()
            .HasMany(e => e.Accounts)
            .WithOne(e => e.Email)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Phone>()
            .HasMany(p => p.Accounts)
            .WithOne(p => p.Phone)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Statement>()
            .HasDiscriminator(s => s.StatementType)
            .IsComplete(false);

        modelBuilder.Entity<Statement>()
            .Navigation(s => s.Account)
            .IsRequired();

        modelBuilder.Entity<StatementTransaction>()
            .HasOne(e => e.PayorStatement)
            .WithMany()
            .HasForeignKey(t => t.PayorStatementID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<StatementTransaction>()
            .HasOne(e => e.PayeeStatement)
            .WithMany()
            .HasForeignKey(t => t.PayeeStatementID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
