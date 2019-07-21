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
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
