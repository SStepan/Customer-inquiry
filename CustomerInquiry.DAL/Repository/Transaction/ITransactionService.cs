using CustomerInquiry.DAL.Repository.Base;
using CustomerInquiry.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInquiry.DAL.Repository
{
    public interface ITransactionService : IRepository<Transaction>
    {
    }
}
