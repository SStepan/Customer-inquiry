using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInquiry.Model
{ 
    public class CustomerDto
    {
        public CustomerDto()
        {
            Transactions = new List<TransactionDto>();
        }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ContactEmail { get; set; }
        public long MobileNumber { get; set; }

        public List<TransactionDto> Transactions { get; set; }
    }
}
