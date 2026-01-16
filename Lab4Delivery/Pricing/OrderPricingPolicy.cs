namespace Lab4Delivery.Pricing
{
    public class OrderPricingPolicy
    {
        public OrderPricingPolicy(
            IDiscountStrategy discount,
            ITaxStrategy tax,
            IDeliveryFeeStrategy delivery)
        {
            Discount = discount;
            Tax = tax;
            Delivery = delivery;
        }

        public IDiscountStrategy Discount { get; }
        public ITaxStrategy Tax { get; }
        public IDeliveryFeeStrategy Delivery { get; }
    }
}
