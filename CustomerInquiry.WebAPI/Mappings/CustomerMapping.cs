using AutoMapper;
using CustomerInquiry.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInquiry.WebAPI.Mappings
{
    public class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<CustomerPostDto, Customer>();
            CreateMap<Transaction, TransactionDto>()
                .ForMember(t => t.TransactionStatus, opts => opts.MapFrom(t => t.TransactionStatus.Name))
                .ForMember(t => t.CurrencyCode, opts => opts.MapFrom(t => t.CurrencyCode.Name));
        }
    }
}
