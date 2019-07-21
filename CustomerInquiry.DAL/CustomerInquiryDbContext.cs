using CustomerInquiry.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomerInquiry.DAL
{
    public class CustomerInquiryDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<CurrencyCode> CurrencyCodes { get; set; }
        public DbSet<TransactionStatus> TransactionStatuses { get; set; }

        public CustomerInquiryDbContext(DbContextOptions<CustomerInquiryDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().Property(t => t.CurrencyCodeId).IsRequired(true);
            modelBuilder.Entity<Transaction>().Property(t => t.TransactionStatusId).IsRequired(true);
            modelBuilder.Entity<Transaction>().Property(t => t.CustomerId).IsRequired(true);
        
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Customer)
                .WithMany(t => t.Transactions)
                .HasForeignKey(t => t.CustomerId);

            modelBuilder.Entity<Customer>()
                .HasMany(t => t.Transactions)
                .WithOne(t => t.Customer)
                .HasForeignKey(t => t.CustomerId);

            

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.CurrencyCode)
                .WithMany()
                .HasForeignKey(t => t.CurrencyCodeId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.TransactionStatus)
                .WithMany()
                .HasForeignKey(t => t.TransactionStatusId);
        }
    }
}
