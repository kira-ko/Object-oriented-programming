namespace Lab4Delivery.Pricing
{
    public class FixedRateTaxStrategy : ITaxStrategy
    {
        private readonly decimal _rate; // 0.12m = 12%

        public FixedRateTaxStrategy(decimal rate)
        {
            if (rate < 0m || rate > 1m) throw new ArgumentException("Rate must be between 0 and 1.");
            _rate = rate;
        }

        public decimal CalculateTax(decimal taxableAmount)
        {
            if (taxableAmount < 0m) taxableAmount = 0m;
            return taxableAmount * _rate;
        }
    }
}
