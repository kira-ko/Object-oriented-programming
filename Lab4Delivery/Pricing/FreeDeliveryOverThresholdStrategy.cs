namespace Lab4Delivery.Pricing
{
    public class FreeDeliveryOverThresholdStrategy : IDeliveryFeeStrategy
    {
        private readonly decimal _threshold;
        private readonly decimal _fee;

        public FreeDeliveryOverThresholdStrategy(decimal threshold, decimal fee)
        {
            if (threshold < 0m) throw new ArgumentException("Threshold must be >= 0.");
            if (fee < 0m) throw new ArgumentException("Fee must be >= 0.");
            _threshold = threshold;
            _fee = fee;
        }

        public decimal CalculateDeliveryFee(decimal itemsSubtotal)
        {
            return itemsSubtotal >= _threshold ? 0m : _fee;
        }
    }
}
