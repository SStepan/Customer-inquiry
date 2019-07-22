using AutoMapper;
using CustomerInquiry.BusinessLogic.Interfaces;
using CustomerInquiry.DAL.UnityOfWork;
using CustomerInquiry.Model;
using CustomerInquiry.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CustomerInquiry.BusinessLogic.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnityOfWork unityOfWork,
            IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }

        public CustomerDto AddCustomer(CustomerPostDto customer)
        {
            var exitingCustomer = _unityOfWork.Customers.GetCustomerByEmail(customer.ContactEmail);
            if(exitingCustomer != null)
            {
                throw new ValidationException($"customer with email: {exitingCustomer.ContactEmail} already exists");
            }

            var newCustomer = _mapper.Map<Customer>(customer);
            _unityOfWork.Customers.Add(newCustomer);
            _unityOfWork.Complete();
            return GetCustomer(customer.ContactEmail);
        }

        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            var allCustomers = _unityOfWork.Customers.GetAll();
            var result = _mapper.Map<IEnumerable<CustomerDto>>(allCustomers);
            foreach (var customerDto in result)
            {
                customerDto.Transactions = GetLastTransactions(customerDto.CustomerId);
            }
            return result;
        }

        public CustomerDto GetCustomer(long id)
        {
            var customer = _unityOfWork.Customers.GetById(id);
            var result = _mapper.Map<CustomerDto>(customer);
            result.Transactions = GetLastTransactions(result.CustomerId);
            return result;
        }

        public CustomerDto GetCustomer(string email)
        {
            var customer = _unityOfWork.Customers.GetCustomerByEmail(email);
            var result = _mapper.Map<CustomerDto>(customer);
            result.Transactions = GetLastTransactions(result.CustomerId);
            return result;
        }

        public CustomerDto GetCustomer(CustomerInquiryDto inquiryDto)
        {
            CustomerDto result;
            if(!string.IsNullOrEmpty(inquiryDto.Email))
            {
                result = GetCustomer(inquiryDto.Email);
                if (inquiryDto.CustomerID != 0 && result.CustomerId != inquiryDto.CustomerID)
                {
                    throw new ValidationException("email and customer ID are not consistent");
                }
                return result;
            }

            return GetCustomer(inquiryDto.CustomerID);
        }

        public int RemoveCustomer(long id)
        {
            var customerToDelete = _unityOfWork.Customers.GetById(id);
            _unityOfWork.Customers.Remove(customerToDelete);

            return _unityOfWork.Complete();
        }

        private List<TransactionDto> GetLastTransactions(long customerId)
        {
            var recentTransactions = _unityOfWork.Transactions
                .Find(t => t.CustomerId == customerId)
                .OrderByDescending(t => t.TransactionDate)
                .Take(5);

            return _mapper.Map<IEnumerable<TransactionDto>>(recentTransactions).ToList();
        }
    }
}
