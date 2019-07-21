using CustomerInquiry.DAL.Repository.Base;
using CustomerInquiry.Model;
using System.Linq;

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
