using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CustomerInquiry.Model
{
    [Table("CurrencyCode", Schema = "Installation")]
    public class CurrencyCode
    {
        public int CurrencyCodeId { get; set; }
        public string Name { get; set; }
    }
}
