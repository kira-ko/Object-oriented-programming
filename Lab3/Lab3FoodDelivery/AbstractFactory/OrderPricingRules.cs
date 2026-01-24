using Lab3FoodDelivery.Strategies;

namespace Lab3FoodDelivery.AbstractFactory
{
    public class OrderPricingRules
    {
        public IDiscountStrategy DiscountStrategy { get; set; }
        public ITaxStrategy TaxStrategy { get; set; }
        public IDeliveryFeeStrategy DeliveryFeeStrategy { get; set; }
    }
}
