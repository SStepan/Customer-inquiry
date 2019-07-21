using CustomerInquiry.DAL.Entities;
using CustomerInquiry.DAL.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerInquiry.DAL.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly CustomerInquiryDbContext _customerInquiryDbContext;
        
        public CustomerRepository(CustomerInquiryDbContext context) : base(context)
        {
            _customerInquiryDbContext = context;
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _customerInquiryDbContext.Customers.FirstOrDefault(t => t.ContactEmail == email);
        }
    }
}
