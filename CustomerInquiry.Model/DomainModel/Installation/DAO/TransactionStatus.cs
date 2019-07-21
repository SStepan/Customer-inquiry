using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CustomerInquiry.Model
{
    [Table("TransactionStatus", Schema = "Installation")]
    public class TransactionStatus
    {
        [Key]
        public int TransactionStatusId { get; set; }
        public string Name { get; set; }
    }
}
