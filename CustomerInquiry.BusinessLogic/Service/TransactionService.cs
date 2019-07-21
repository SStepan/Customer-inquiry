using AutoMapper;
using CustomerInquiry.BusinessLogic.Interfaces;
using CustomerInquiry.DAL.UnityOfWork;
using CustomerInquiry.Model;
using CustomerInquiry.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInquiry.BusinessLogic.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public TransactionService(IUnityOfWork unityOfWork,
            IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }

        public TransactionDto AddTransaction(TransactionPostDto transactionDto)
        {
            var transaction = _mapper.Map<Transaction>(transactionDto);
            var currency = (Currencies)Enum.Parse(typeof(Currencies), transactionDto.Currency);
            transaction.CurrencyCodeId = (int)currency;
            transaction.TransactionStatusId = 1;
            transaction.TransactionDate = DateTime.UtcNow;

            _unityOfWork.Transactions.Add(transaction);
            _unityOfWork.Complete();
            return GetTransaction(transaction.TransactionId);
        }

        public IEnumerable<TransactionDto> GetAllTransactions()
        {
            var transactions = _unityOfWork.Transactions.GetAll();
            var result = _mapper.Map<IEnumerable<TransactionDto>>(transactions);
            return result;
        }

        public TransactionDto GetTransaction(long id)
        {
            var transaction = _unityOfWork.Transactions.GetById(id);
            return _mapper.Map<TransactionDto>(transaction);
        }
    }
}
