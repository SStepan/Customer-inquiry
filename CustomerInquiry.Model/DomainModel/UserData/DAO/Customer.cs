using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CustomerInquiry.Model
{
    [Table("Customer", Schema = "UserData")]
    public class Customer
    {
        public Customer()
        {
            Transactions = new List<Transaction>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CustomerId { get; set; }
        [MaxLength(30)]
        public string CustomerName { get; set; }
        [MaxLength(25)]
        public string ContactEmail { get; set; }
        [MaxLength(30)]
        public long MobileNumber { get; set; }

        public virtual List<Transaction> Transactions { get; set; }
    }
}
