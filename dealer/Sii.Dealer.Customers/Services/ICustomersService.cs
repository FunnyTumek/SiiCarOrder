using Sii.Dealer.Customers.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sii.Dealer.Customers.Services
{
    public interface ICustomersService
    {
        
        Task<IEnumerable<CustomerDto>> GetAll();
        Task<CustomerDto> GetByEmail(string email);
        CustomerDto GetByEmailSync(string email);
        Task<CustomerDto> GetByidentityNo(string identityNo);
        Task Create(CustomerDto dto);
        Task<bool> UpdateAsync(string email, CustomerDto dto);
        void CreateCustomer(CustomerDto dto);

    }
}