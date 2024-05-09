using Sii.Dealer.SharedKernel.Enums;
using System;
using System.Collections.Generic;

namespace Sii.Dealer.Core.Domain.Entities
{
    public class Gearbox : IConfigurationOption
    {
        private Gearbox()
        {
        }
        public Gearbox(string code, string name, GearboxType type, int gearsCount, bool availability, decimal price)
        {
            Validate(code, name, gearsCount);

            Code = code.ToUpper();
            Name = name;
            Type = type;
            GearsCount = gearsCount;
            Availability = availability;
            Price = price;
        }

        public string Code { get; private set; }

        public GearboxType Type { get; private set; }

        public string Name { get; private set; }

        public int GearsCount { get; private set; }

        public bool Availability { get; private set; }

        public decimal Price { get; private set; }

        public void ChangeAvailability(bool availability)
        {
            Availability = availability;
        }

        public void ChangeName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName)) throw new ArgumentException("Code is not valid.", nameof(newName));
            if (string.IsNullOrEmpty(newName)) throw new ArgumentException("Code is not valid.", nameof(newName));
            Name = newName;
        }

        public void ChangeType(GearboxType type)
        {
            Type = type;
        }
        public void ChangeGearsCount(int gearsCount)
        {
            if (gearsCount < 5 || gearsCount > 7)
            {
                throw new ArgumentException("Number of gears is not valid.", nameof(gearsCount));
            }
            else GearsCount = gearsCount;
        } 
        private static void Validate(string code, string name, int gearsCount)
        {
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentException("Code is not valid.", nameof(code));
            if (string.IsNullOrEmpty(code)) throw new ArgumentException("Code is not valid.", nameof(code));
            if (code.Length < 4) throw new ArgumentException("Code must be at least 4 characters.", nameof(code));
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name is not valid", nameof(name));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Code is not valid.", nameof(name));
            if (gearsCount < 5 || gearsCount > 7) throw new ArgumentException("Number of gears is not valid.", nameof(gearsCount));
        }
        public void Update(string name, GearboxType type, int gearsCount, bool availability)
        {
            ChangeName(name);
            ChangeType(type);
            ChangeGearsCount(gearsCount);
            ChangeAvailability(availability);
        }
    }
}
