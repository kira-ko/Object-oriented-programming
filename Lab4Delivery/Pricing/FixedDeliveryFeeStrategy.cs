namespace Lab4Delivery.Pricing
{
    public class FixedDeliveryFeeStrategy : IDeliveryFeeStrategy
    {
        private readonly decimal _fee;

        public FixedDeliveryFeeStrategy(decimal fee)
        {
            if (fee < 0m) throw new ArgumentException("Fee must be >= 0.");
            _fee = fee;
        }

        public decimal CalculateDeliveryFee(decimal itemsSubtotal) => _fee;
    }
}
