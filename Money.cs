namespace po_lab
{
    public class Money : IEquatable<Money>, IComparable<Money>
    {
        private readonly decimal _value;
        private readonly Currency _currency;

        public decimal Value { 
            get { return _value; }
        }

        private Money(decimal value, Currency currency)
        {
            _value = value;
            _currency = currency;
        }

        public bool Equals(Money? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _value == other._value && _currency == other._currency;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Money) obj);
        }

        public int CompareTo(Money? other)
        {
            if (ReferenceEquals(null, other)) return 1;
            if (ReferenceEquals(this, other)) return 0;
            var currencyComparison = _currency.CompareTo(other._currency);
            if (currencyComparison != 0) return currencyComparison;
            return _value.CompareTo(other._value);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode() ^ _currency.GetHashCode();
        }

        private static void ThrowOnDiffCurrencies(Money a, Money b)
        {
            if (a._currency != b._currency)
                throw new InvalidOperationException("Cannot add different currencies");
        }

        public static Money operator +(Money a, Money b)
        {
            ThrowOnDiffCurrencies(a, b);
            return new Money(a.Value + b.Value, a._currency);
        }

        public static Money operator -(Money a, Money b)
        {
            ThrowOnDiffCurrencies(a, b);
            return new Money(a.Value - b.Value, a._currency);
        }

        public static Money operator *(Money a, decimal b)
        {
            return new Money(a.Value * b, a._currency);
        }

        public static Money operator *(decimal a, Money b)
        {
            return new Money(a * b.Value, b._currency);
        }

        public static Money operator /(Money a, decimal b)
        {
            return new Money(a.Value / b, a._currency);
        }

        public static Money operator /(decimal a, Money b)
        {
            return new Money(a / b.Value, b._currency);
        }

        public static bool operator ==(Money? a, Money? b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(Money a, Money b)
        {
            return !Equals(a, b);
        }

        public static bool operator >(Money a, Money b)
        {
            ThrowOnDiffCurrencies(a, b);
            return a.Value > b.Value;
        }

        public static bool operator <(Money a, Money b)
        {
            ThrowOnDiffCurrencies(a, b);
            return a.Value < b.Value;
        }

        public static bool operator >=(Money a, Money b)
        {
            ThrowOnDiffCurrencies(a, b);
            return a.Value >= b.Value;
        }

        public static bool operator <=(Money a, Money b)
        {
            ThrowOnDiffCurrencies(a, b);
            return a.Value <= b.Value;
        }

        public static implicit operator Money(decimal value)
        {
            return new Money(value, Currency.PLN);
        }

        public static implicit operator decimal(Money value)
        {
            return value.Value;
        }

        public static explicit operator float(Money value)
        {
            return (float) value.Value;
        }

        public override string ToString()
        {
            return $"{_value} {_currency}";
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
