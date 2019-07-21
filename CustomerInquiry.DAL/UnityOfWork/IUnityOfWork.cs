using CustomerInquiry.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInquiry.DAL.UnityOfWork
{
    public interface IUnityOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        ITransactionService Transactions { get; }
        int Complete();
    }
}
