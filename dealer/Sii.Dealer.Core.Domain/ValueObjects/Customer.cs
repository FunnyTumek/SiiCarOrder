using System;
using System.Net.Mail;
using Sii.Dealer.Core.Base.ValueObjects;

namespace Sii.Dealer.Core.Domain.ValueObjects
{
    public class Customer : ValueObject<Customer>
    {
        public Customer(string firstName, string lastName, string email, string phone)
        {
            if (!MailAddress.TryCreate(email, out _)) throw new ArgumentException("Wrong email", nameof(email));
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("First name cannot be empty", nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("Last name cannot be empty", nameof(lastName));
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
    }
}
