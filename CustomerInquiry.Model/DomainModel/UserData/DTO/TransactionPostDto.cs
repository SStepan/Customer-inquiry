using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInquiry.Model
{
    public class TransactionPostDto
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
