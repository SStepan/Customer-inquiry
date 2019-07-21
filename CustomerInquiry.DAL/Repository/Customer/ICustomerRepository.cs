using CustomerInquiry.DAL.Repository.Base;
using CustomerInquiry.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInquiry.DAL.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetCustomerByEmail(string email);
    }
}
