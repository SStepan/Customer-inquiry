using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CustomerInquiry.Model
{
    public class CustomerInquiryDto
    {
        [RegularExpression(@"^[0-9]{1,10}$", ErrorMessage = "Invalid Customer ID")]
        public long CustomerId { get; set; }
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
    }
}
