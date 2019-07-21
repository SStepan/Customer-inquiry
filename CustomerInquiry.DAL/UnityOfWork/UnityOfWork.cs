using System;
using System.Collections.Generic;
using System.Text;
using CustomerInquiry.DAL.Repository;

namespace CustomerInquiry.DAL.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly CustomerInquiryDbContext _context;
        public UnityOfWork(CustomerInquiryDbContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            Transactions = new TransactionService(_context);
        }
        public ICustomerRepository Customers { get; }
        public ITransactionService Transactions { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
