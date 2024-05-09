using Sii.Dealer.SharedKernel.Enums;
using System;

namespace Sii.Dealer.Core.Domain.Entities
{
    public class Engine : IConfigurationOption
    {
        private Engine()
        {
        }
        public Engine(string code, string name, int capacity, int power, EngineType type, bool availability, decimal price)
        {
            Validate(code, name, capacity, power);

            Code = code;
            Name = name;
            Capacity = capacity;
            Power = power;
            Availability = availability;
            Price = price;
            Type = type;
        }

        public string Code { get; private set; }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int Power { get; private set; }

        public EngineType Type { get; private set; }

        public bool Availability { get; private set; }

        public decimal Price { get; private set; }

        private void ChangeAvailability(bool availability)
        {
            Availability = availability;
        }

        private void ChangeName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName)) throw new ArgumentException("Name is not valid.", nameof(newName));
            if (string.IsNullOrEmpty(newName)) throw new ArgumentException("Name is not valid.", nameof(newName));
            Name = newName;
        }

        private void EngineForce(int newCapacity, int newPower)
        {
            switch (newPower)
            {
                case <65:
                    throw new ArgumentException("Engine power value below allowed limit (65).", nameof(newPower));
                case >650:
                    throw new ArgumentException("Engine power value above allowed limit (650).", nameof(newPower));
            }
            Power = newPower;

            switch (newCapacity)
            {
                case < 800:
                    throw new ArgumentException("Engine capacity value below allowed limit (800).", nameof(newCapacity));
                case >6000:
                    throw new ArgumentException("Engine capacity value above allowed limit (6000).", nameof(newCapacity));
            }
            Capacity = newCapacity;
        }

        private void ChangeType(EngineType type)
         {
            if(Enum.IsDefined(typeof(EngineType), type))
            {
                Type = type;
            }
            throw new ArgumentException("Engine type is not vale.");
        }

        private static void Validate(string code, string name, int capacity, int power)
        {
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentException("Code is not valid.", nameof(code));
            if (string.IsNullOrEmpty(code)) throw new ArgumentException("Code is not valid.", nameof(code));
            if (code.Length < 4) throw new ArgumentException("Code must contain at least 4 characters.", nameof(code));

            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is not valid.", nameof(name));
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name is not valid.", nameof(name));

            if (capacity<800 || capacity> 6000) throw new ArgumentException("Capacity value is not valid.", nameof(capacity));

            if (power<65 || power> 650) throw new ArgumentException("Power value is not valid.", nameof(capacity));
        }

        public void Update(string name, int capacity, int power, EngineType type, bool availability)
        {
            ChangeName(name);
            EngineForce(capacity,power);
            ChangeType(type);
            ChangeAvailability(availability);
        }
    }
}
