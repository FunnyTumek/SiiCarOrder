using AutoMapper;
using Sii.Dealer.Customers.DataTransferObjects;
using Sii.Dealer.Customers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sii.Dealer.Customers.Mapping.MappingToDto
{
    public class MappingCustomersProfile : Profile
    {
        public MappingCustomersProfile()
        {
            CreateMap<Customer, CustomerDto>();
        }
    }
}
