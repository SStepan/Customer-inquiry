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

        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> Get()
        {
            return Ok(_customerService.GetAllCustomers());
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerDto> Get(int id)
        {
            return Ok(_customerService.GetCustomer(id));
        }

        [HttpPost]
        public void Post([FromBody] CustomerPostDto customer)
        {
            _customerService.AddCustomer(customer);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _customerService.RemoveCustomer(id);
        }
    }
}