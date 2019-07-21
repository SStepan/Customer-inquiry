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
        public int CustomerId { get; set; }
        [MaxLength(30)]
        public string CustomerName { get; set; }
        [MaxLength(25)]
        public string ContactEmail { get; set; }
        [MaxLength(30)]
        public int MobileNumber { get; set; }

        public virtual List<Transaction> Transactions { get; set; }
    }
}
