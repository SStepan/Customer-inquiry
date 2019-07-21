using CustomerInquiry.DAL.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using CustomerInquiry.Model;

namespace CustomerInquiry.DAL.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetCustomerByEmail(string email);
    }
}
