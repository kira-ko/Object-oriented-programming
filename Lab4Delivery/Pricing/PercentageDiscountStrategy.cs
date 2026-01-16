namespace Lab4Delivery.Pricing
{
    public class PercentageDiscountStrategy : IDiscountStrategy
    {
        private readonly decimal _percent; // например 0.10m = 10%

        public PercentageDiscountStrategy(decimal percent)
        {
            if (percent < 0m || percent > 1m) throw new ArgumentException("Percent must be between 0 and 1.");
            _percent = percent;
        }

        public decimal CalculateDiscount(decimal itemsSubtotal)
        {
            if (itemsSubtotal < 0m) return 0m;
            return itemsSubtotal * _percent;
        }
    }
}
