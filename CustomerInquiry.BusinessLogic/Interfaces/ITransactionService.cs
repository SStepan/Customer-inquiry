using CustomerInquiry.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInquiry.BusinessLogic.Interfaces
{
    public interface ITransactionService
    {
        IEnumerable<TransactionDto> GetAllTransactions();
        TransactionDto AddTransaction(TransactionPostDto customer);
        TransactionDto GetTransaction(long id);
    }
}
