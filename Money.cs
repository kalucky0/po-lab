namespace po_lab
{
    public class Money : IEquatable<Money>, IComparable<Money>
    {
        private readonly decimal _value;
        private readonly Currency _currency;

        public decimal Value { 
            get { return _value; }
        }

        public Currency Currency {
            get { return _currency; }
        }

        /// <summary>
        /// Constructor of Money class
        /// </summary>
        /// <param name="value">Value of money</param>
        /// <param name="currency">Currency of money</param>
        private Money(decimal value, Currency currency)
        {
            _value = value;
            _currency = currency;
        }

        /// <summary>
        /// Method that checks if money object is equal to another
        /// </summary>
        /// <param name="other">Money to compare with</param>
        /// <returns>True if money is equal to another money</returns>
        public bool Equals(Money? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _value == other._value && _currency == other._currency;
        }

        /// <summary>
        /// Method that checks if money object is equal to generic object
        /// </summary>
        /// <param name="obj">Object to compare with</param>
        /// <returns>True if object is equal to money</returns>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Money) obj);
        }

        /// <summary>
        /// Method that compares two money objects
        /// </summary>
        /// <param name="other">Money to compare with</param>
        public int CompareTo(Money? other)
        {
            if (ReferenceEquals(null, other)) return 1;
            if (ReferenceEquals(this, other)) return 0;
            var currencyComparison = _currency.CompareTo(other._currency);
            if (currencyComparison != 0) return currencyComparison;
            return _value.CompareTo(other._value);
        }

        /// <summary>
        /// Method that returns hash code of money object
        /// </summary>
        /// <returns>Hash code of money object</returns>
        public override int GetHashCode()
        {
            return _value.GetHashCode() ^ _currency.GetHashCode();
        }

        private static void ThrowOnDiffCurrencies(Money a, Money b)
        {
            if (a._currency != b._currency)
                throw new InvalidOperationException("Cannot add different currencies");
        }

        /// <summary>
        /// Method that adds two money objects
        /// </summary>
        /// <param name="a">First money object</param>
        /// <param name="b">Second money object</param>
        /// <returns>Sum of money objects</returns>
        public static Money operator +(Money a, Money b)
        {
            ThrowOnDiffCurrencies(a, b);
            return new Money(a.Value + b.Value, a._currency);
        }

        /// <summary>
        /// Method that subtracts two money objects
        /// </summary>
        /// <param name="a">First money object</param>
        /// <param name="b">Second money object</param>
        /// <returns>Difference of money objects</returns>
        public static Money operator -(Money a, Money b)
        {
            ThrowOnDiffCurrencies(a, b);
            return new Money(a.Value - b.Value, a._currency);
        }

        /// <summary>
        /// Method that multiplies money object by a number
        /// </summary>
        /// <param name="a">Money object</param>
        /// <param name="b">Number</param>
        /// <returns>Product of money object and number</returns>
        public static Money operator *(Money a, decimal b)
        {
            return new Money(a.Value * b, a._currency);
        }

        /// <summary>
        /// Method that multiplies number by money object
        /// </summary>
        /// <param name="a">Number</param>
        /// <param name="b">Money object</param>
        /// <returns>Product of number and money object</returns>
        public static Money operator *(decimal a, Money b)
        {
            return new Money(a * b.Value, b._currency);
        }

        /// <summary>
        /// Method that divides money object by a number
        /// </summary>
        /// <param name="a">Money object</param>
        /// <param name="b">Number</param>
        /// <returns>Quotient of money object and number</returns>
        public static Money operator /(Money a, decimal b)
        {
            return new Money(a.Value / b, a._currency);
        }

        /// <summary>
        /// Method that divides number by money object
        /// </summary>
        /// <param name="a">Number</param>
        /// <param name="b">Money object</param>
        /// <returns>Quotient of number and money object</returns>
        public static Money operator /(decimal a, Money b)
        {
            return new Money(a / b.Value, b._currency);
        }

        /// <summary>
        /// Method that checks if two money objects are equal
        /// </summary>
        /// <param name="a">First money object</param>
        /// <param name="b">Second money object</param>
        /// <returns>True if money objects are equal</returns>
        public static bool operator ==(Money? a, Money? b)
        {
            return Equals(a, b);
        }

        /// <summary>
        /// Method that checks if two money objects are not equal
        /// </summary>
        /// <param name="a">First money object</param>
        /// <param name="b">Second money object</param>
        /// <returns>True if money objects are not equal</returns>
        public static bool operator !=(Money a, Money b)
        {
            return !Equals(a, b);
        }

        /// <summary>
        /// Method that checks if money object is greater than another
        /// </summary>
        /// <param name="a">First money object</param>
        /// <param name="b">Second money object</param>
        /// <returns>True if first money object is greater than second</returns>
        public static bool operator >(Money a, Money b)
        {
            ThrowOnDiffCurrencies(a, b);
            return a.Value > b.Value;
        }

        /// <summary>
        /// Method that checks if money object is less than another
        /// </summary>
        /// <param name="a">First money object</param>
        /// <param name="b">Second money object</param>
        /// <returns>True if first money object is less than second</returns>
        public static bool operator <(Money a, Money b)
        {
            ThrowOnDiffCurrencies(a, b);
            return a.Value < b.Value;
        }

        /// <summary>
        /// Method that checks if money object is greater than or equal to another
        /// </summary>
        /// <param name="a">First money object</param>
        /// <param name="b">Second money object</param>
        /// <returns>True if first money object is greater than or equal to second</returns>
        public static bool operator >=(Money a, Money b)
        {
            ThrowOnDiffCurrencies(a, b);
            return a.Value >= b.Value;
        }

        /// <summary>
        /// Method that checks if money object is less than or equal to another
        /// </summary>
        /// <param name="a">First money object</param>
        /// <param name="b">Second money object</param>
        /// <returns>True if first money object is less than or equal to second</returns>
        public static bool operator <=(Money a, Money b)
        {
            ThrowOnDiffCurrencies(a, b);
            return a.Value <= b.Value;
        }

        /// <summary>
        /// Method that converts money object to decimal
        /// </summary>
        /// <param name="a">Money object</param>
        /// <returns>Decimal value of money object</returns>
        public static implicit operator decimal(Money value)
        {
            return value.Value;
        }

        /// <summary>
        /// Method that converts money object to float
        /// </summary>
        /// <param name="a">Money object</param>
        /// <returns>Float value of money object</returns>
        public static explicit operator float(Money value)
        {
            return (float) value.Value;
        }

        /// <summary>
        /// Method that converts money object to string
        /// </summary>
        /// <param name="a">Money object</param>
        /// <returns>String value of money object</returns>
        public override string ToString()
        {
            return $"{_value} {_currency}";
        }

        /// <summary>
        /// Method that creates a new money object from given values
        /// </summary>
        /// <param name="value">Value of money object</param>
        /// <param name="currency">Currency of money object</param>
        /// <returns>New money object or null if value is negative</returns>
        public static Money? Of(decimal value, Currency currency)
        {
            return value < 0 ? null : new Money(value, currency);
        }

        /// <summary>
        /// Method that creates a new money object from given values
        /// </summary>
        /// <param name="value">Value of money object</param>
        /// <param name="currency">Currency of money object</param>
        /// <exception cref="ArgumentException">Thrown when value is negative</exception>
        /// <returns>New money object</returns>
        public static Money OfWithException(decimal value, Currency currency)
        {
            if (value < 0)
                throw new ArgumentException("Value cannot be below zero");

            return new Money(value, currency);
        }

        /// <summary>
        /// Method that creates a new money object from given values
        /// </summary>
        /// <param name="value">Value of money object</param>
        /// <param name="currency">Currency of money object</param>
        /// <returns>New money object or null if value is negative</returns>
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
