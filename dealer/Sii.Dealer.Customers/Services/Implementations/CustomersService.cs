using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sii.Dealer.Customers.DataTransferObjects;
using Sii.Dealer.Customers.Entities;
using Sii.Dealer.SharedKernel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sii.Dealer.Customers.Services.Implementations
{
    public class CustomersService : ICustomersService
    {
        private readonly CustomersDbContext dbContext;
        private readonly IMapper mapper;
        private readonly ILogger<CustomersService> logger;


        public CustomersService(CustomersDbContext dbContext, IMapper mapper, ILogger<CustomersService> logger)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<IEnumerable<CustomerDto>> GetAll()
        {
            var customers = await dbContext.Customers.ToListAsync();

            logger.LogInformation("Customer List.");

            return mapper.Map<List<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> GetByEmail(string email)
        {
            var customer = await dbContext.Customers.SingleOrDefaultAsync(x => x.Email == email);

            if (customer == null) return null;

            logger.LogInformation("Customer CustomerEmail = {Email}.", customer.Email);

            return mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> GetByidentityNo(string identityNo)
        {
            var customer = await dbContext.Customers.SingleOrDefaultAsync(x => x.IdentityNo == identityNo);

            if (customer == null) return null;

            logger.LogInformation("Customer CustomerIdentityNo = {IdentityNo}.", customer.IdentityNo);

            return mapper.Map<CustomerDto>(customer);
        }
        public async Task Create(CustomerDto dto)
        {
            var customer = new Customer(dto.Type, dto.IdentityNo, dto.Email, dto.FirstName, dto.LastName, dto.City, dto.Street, dto.Number, dto.Phone);
            await dbContext.Customers.AddAsync(customer);

            logger.LogInformation("Customer created CustomerEmail = {Email}.", customer.Email);

            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(string email, CustomerDto dto)
        {
            var customer = await dbContext.Customers.FirstOrDefaultAsync(x => x.Email == email);

            if (customer == null) return false;

            customer.Update(dto.Type, dto.IdentityNo, dto.Email, dto.FirstName, dto.LastName, dto.City, dto.Street, dto.Number, dto.Phone);

            logger.LogInformation("Customer updated CustomerEmail = {Email}.", customer.Email);

            dbContext.SaveChanges();

            return true;
        }

        public void CreateCustomer(CustomerDto dto)
        {
            var customer = new Customer(dto.Email, dto.FirstName, dto.LastName, dto.Phone);
            dbContext.Customers.Add(customer);

            logger.LogInformation("Customer created CustomerEmail = {Email}.", customer.Email);

            dbContext.SaveChanges();
        }
        public CustomerDto GetByEmailSync(string email)
        {
            var customer = dbContext.Customers.SingleOrDefault(x => x.Email == email);

            if (customer == null) return null;

            return mapper.Map<CustomerDto>(customer);
        }
    }
}
