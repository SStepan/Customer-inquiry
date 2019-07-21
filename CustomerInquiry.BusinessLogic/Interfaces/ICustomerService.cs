using CustomerInquiry.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInquiry.BusinessLogic.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetAllCustomers();
        CustomerDto AddCustomer(CustomerPostDto customer);
        CustomerDto GetCustomer(int id);
        CustomerDto GetCustomer(string email);
    }
}
