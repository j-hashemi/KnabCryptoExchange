using System;

namespace Exchange.Domain.Entity
{
    public class Money
    {
        public decimal Value { get; set; }

        public Money(decimal value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value),
                    "Just values are equal and greater than zero are acceptable");

            Value = value;
        }

        public static implicit operator decimal(Money m) => m.Value;
        public static implicit operator Money(decimal value) => new Money(value);
    }
}