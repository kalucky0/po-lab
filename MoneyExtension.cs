namespace po_lab {
    public static class MoneyExtension
    {
        private const decimal USD_RATE = 4.1m;
        private const decimal EUR_RATE = 4.5m;
        private const decimal PLN_RATE = 1m;

        public static Money Percent(this Money money, decimal percent)
        {
            return Money.Of(money.Value * percent / 100m, money.Currency) ?? throw new ArgumentException();
        }

        public static Money ToCurrency(this Money money, Currency currency)
        {
            if (money.Currency == currency)
                return money;

            decimal rate = GetRate(money.Currency, currency);
            return Money.Of(money.Value * rate, currency) ?? throw new ArgumentException();
        }

        private static decimal GetRate(Currency from, Currency to)
        {
            switch (from)
            {
                case Currency.PLN:
                    switch (to)
                    {
                        case Currency.USD:
                            return USD_RATE;
                        case Currency.EUR:
                            return EUR_RATE;
                        default:
                            throw new ArgumentException();
                    }
                case Currency.USD:
                    switch (to)
                    {
                        case Currency.PLN:
                            return 1 / USD_RATE;
                        case Currency.EUR:
                            return EUR_RATE / USD_RATE;
                        default:
                            throw new ArgumentException();
                    }
                case Currency.EUR:
                    switch (to)
                    {
                        case Currency.PLN:
                            return 1 / EUR_RATE;
                        case Currency.USD:
                            return USD_RATE / EUR_RATE;
                        default:
                            throw new ArgumentException();
                    }
                default:
                    throw new ArgumentException();
            }
        }
    }
}