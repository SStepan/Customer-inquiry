using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInquiry.DAL.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ContactEmail { get; set; }
        public int MobileNumber { get; set; }
    }
}
