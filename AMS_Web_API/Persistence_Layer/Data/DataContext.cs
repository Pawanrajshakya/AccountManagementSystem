using Microsoft.EntityFrameworkCore;
using Persistence_Layer.Models;

namespace Persistence_Layer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<UserHistory> UserHistories { get; set; }
        public DbSet<AccountHistory> AccountHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasKey(t => new { t.UserId, t.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserRole)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(pt => pt.Role)
                .WithMany(t => t.UserRole)
                .HasForeignKey(pt => pt.RoleId);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Description = "Admin" },
                new Role { Id = 2, Description = "User" },
                new Role { Id = 3, Description = "Viewer" }
            );

            modelBuilder.Entity<Business>().HasData(
                new Business { Id = 1, Address1 = "Address 1", Address2 = "Address 2", Name = "Business Name", State = "zz", ZipCode = "zzzzz" }
            );

            modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1, Description = "New Group" }
            );
        }
    }
}