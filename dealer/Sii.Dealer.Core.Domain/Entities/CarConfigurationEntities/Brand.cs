using System;

namespace Sii.Dealer.Core.Domain.Entities
{
    public class Brand : IConfigurationOption
    {
        private Brand()
        {
        }
        public Brand(string code, string name, bool availability, decimal price)
        {
            Validate(code, name);

            Code = code.ToUpper();
            Name = name;
            Availability = availability;
            Price = price;
        }
        public string Code { get; private set; }

        public string Name { get; private set; }

        public bool Availability { get; private set; }

        public decimal Price { get; private set; }

        public void ChangeAvailability(bool availability)
        {
            Availability = availability;
        }
        public void ChangeName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName)) throw new ArgumentException("Name is not valid.", nameof(newName));
            if (string.IsNullOrEmpty(newName)) throw new ArgumentException("Name is not valid.", nameof(newName));
            Name = newName;
        }
        private void Validate(string code, string name)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentException("Code is not valid.", nameof(code));
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentException("Code is not valid.", nameof(code));
            if (code.Length < 4) throw new ArgumentException("Code must contain at least 4 characters.", nameof(code));

            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is not valid.", nameof(name));
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name is not valid.", nameof(name));
        }
        public void Update(string name, bool availability)
        {
            ChangeName(name);
            ChangeAvailability(availability);
        }
    }
}
