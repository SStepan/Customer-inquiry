using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerInquiry.BusinessLogic.Interfaces;
using CustomerInquiry.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerInquiry.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> Get()
        {
            return Ok(_customerService.GetAllCustomers());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_customerService.GetCustomer(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] CustomerPostDto customer)
        {
            _customerService.AddCustomer(customer);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}