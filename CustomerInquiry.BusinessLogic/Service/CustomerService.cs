using AutoMapper;
using CustomerInquiry.BusinessLogic.Interfaces;
using CustomerInquiry.DAL.UnityOfWork;
using CustomerInquiry.Model;
using CustomerInquiry.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                throw new Exception($"customer with email: {exitingCustomer.ContactEmail} already exists");
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
            return result;
        }

        public CustomerDto GetCustomer(int id)
        {
            var customer = _unityOfWork.Customers.GetById(id);
            return _mapper.Map<CustomerDto>(customer);
        }

        public CustomerDto GetCustomer(string email)
        {
            var customer = _unityOfWork.Customers.GetCustomerByEmail(email);
            return _mapper.Map<CustomerDto>(customer);
        }

        public CustomerDto GetCustomer(CustomerInquiryDto inquiryDto)
        {
            Customer result;
            if(!string.IsNullOrEmpty(inquiryDto.Email))
            {
                result = _unityOfWork.Customers.GetCustomerByEmail(inquiryDto.Email);
                return _mapper.Map<CustomerDto>(result);
            }

            result = _unityOfWork.Customers.GetById(inquiryDto.CustomerId);
            return _mapper.Map<CustomerDto>(result);
        }
    }
}
