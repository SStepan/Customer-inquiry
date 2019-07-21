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
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<TransactionDto>> Get()
        {
            return Ok(_transactionService.GetAllTransactions());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<TransactionDto> Get(int id)
        {
            return Ok(_transactionService.GetTransaction(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] TransactionPostDto transaction)
        {
            _transactionService.AddTransaction(transaction);
        }
    }
}