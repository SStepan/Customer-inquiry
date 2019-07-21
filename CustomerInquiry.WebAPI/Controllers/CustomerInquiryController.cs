using CustomerInquiry.BusinessLogic.Interfaces;
using CustomerInquiry.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;

namespace CustomerInquiry.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInquiryController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerInquiryController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public ActionResult<CustomerDto> Get([FromBody] CustomerInquiryDto customerIquiry)
        {
            if (string.IsNullOrEmpty(customerIquiry.Email) && customerIquiry.CustomerId == 0)
            {
                return BadRequest(new { message = "Invalid criteria" });
            }

            var result = _customerService.GetCustomer(customerIquiry);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}