using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInquiry.Model
{ 
    public class TransactionDto
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string TransactionStatus { get; set; }
    }
}
