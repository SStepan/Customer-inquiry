using CustomerInquiry.DAL.Repository.Base;
using CustomerInquiry.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInquiry.DAL.Repository
{
    public class TransactionService : Repository<Transaction>, ITransactionService
    {
        private readonly CustomerInquiryDbContext _customerInquiryDbContext;

        public TransactionService(CustomerInquiryDbContext context) : base(context)
        {
            _customerInquiryDbContext = context;
        }

    }
}
