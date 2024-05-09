using System;
using Sii.Dealer.Core.Base.Entities;
using Sii.Dealer.SharedKernel.Enums;

namespace Sii.Dealer.Customers.Entities
{
    public class Customer : AggregateRoot<int>
    {
        private Customer()
        {
        }

        public Customer(CustomerType type, string identityNo, string email, string firstName, string lastName, string city, string street, string number, string phone)
        {
            Validate(email, firstName, lastName, phone);

            Type = type;
            IdentityNo = identityNo;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            City = city;
            Street = street;
            Number = number;
            Phone = phone;
        }

        public Customer(string email, string firstName, string lastName, string phone)
        {
            Validate(email, firstName, lastName, phone);

            Type = 0;
            IdentityNo = null;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            City = null;
            Street = null;
            Number = null;
            Phone = phone;
        }

        public CustomerType Type { get; private set; }

        public string IdentityNo { get; private set; }

        public string Email { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string City { get; private set; }

        public string Street { get; private set; }

        public string Number { get; private set; }

        public string Phone { get; private set; }

        public void Update(CustomerType type, string identityNo, string email, string firstName, string lastName, string city, string street, string number, string phone)
        {
            Validate(email, firstName, lastName, phone);

            Type = type;
            IdentityNo = identityNo;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            City = city;
            Street = street;
            Number = number;
            Phone = phone;
        }

        private static void Validate(string email, string firstName, string lastName, string phone)
        {
            if (string.IsNullOrEmpty(email)) throw new ArgumentException(nameof(email));
            if (string.IsNullOrEmpty(firstName)) throw new ArgumentException(nameof(firstName));
            if (string.IsNullOrEmpty(lastName)) throw new ArgumentException(nameof(lastName));
            if (phone?.Length > 20) throw new ArgumentException(nameof(phone));
        }
    }
}
