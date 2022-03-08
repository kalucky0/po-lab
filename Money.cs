using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace po_lab
{
    public class Money : IEquatable<Money>
    {
        private readonly decimal _value;
        private readonly Currency _currency;
        private Money(decimal value, Currency currency)
        {
            _value = value;
            _currency = currency;
        }

        public bool Equals(Money? other)
        {
            if (ReferenceEquals(this, other)) return true;
            return false;
        }

        public static Money? Of(decimal value, Currency currency)
        {
            return value < 0 ? null : new Money(value, currency);
        }

        public static Money OfWithException(decimal value, Currency currency)
        {
            if (value < 0)
                throw new ArgumentException("Value cannot be below zero");

            return new Money(value, currency);
        }

        public static Money ParseValue(string valueStr, Currency currency)
        {
            var value = decimal.Parse(valueStr);
            return new Money(value, currency);
        }
    }


    public enum Currency
    {
        PLN = 1,
        USD = 2,
        EUR = 3
    }
}
