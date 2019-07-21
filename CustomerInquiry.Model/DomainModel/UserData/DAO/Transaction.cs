using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CustomerInquiry.Model
{
    [Table("Transaction", Schema ="UserData")]
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TransactionId { get; set; }
        public long CustomerId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public int CurrencyCodeId { get; set; }
        public int TransactionStatusId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CurrencyCode CurrencyCode { get; set; }
        public virtual TransactionStatus TransactionStatus { get; set; }
    }
}
