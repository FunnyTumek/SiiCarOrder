using Sii.Dealer.SharedKernel.Enums;

namespace Sii.Dealer.Customers.DataTransferObjects
{
    public class CustomerDto
    {
        public CustomerType Type { get; set; }

        public string IdentityNo { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Phone { get; set; }
    }
}
