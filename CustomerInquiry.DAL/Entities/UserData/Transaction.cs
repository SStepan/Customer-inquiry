using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInquiry.DAL.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int CustomerId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public int CurrencyCodeId { get; set; }
        public int TransactionStatusId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CurrencyCode CurrencyCode { get; set; }
        public virtual TransactionStatus TransactionStatus { get; set; }
    }
}
