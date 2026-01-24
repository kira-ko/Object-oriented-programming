using Lab3FoodDelivery.Orders;
using Lab3FoodDelivery.State;
using Lab3FoodDelivery.Strategies;

namespace Lab3FoodDelivery.AbstractFactory
{
    public class StandardOrderFactory : IOrderConfigFactory
    {
        public OrderPricingRules CreatePricingRules()
        {
            OrderPricingRules rules = new OrderPricingRules();
            rules.DiscountStrategy = new NoDiscountStrategy();
            rules.TaxStrategy = new NoTaxStrategy();
            rules.DeliveryFeeStrategy = new StandardDeliveryFeeStrategy();
            return rules;
        }
        public IOrderState CreateStartState(Order order)
        {
            if (order == null)
            {
                return null;
            }
            return new PreparingState(order);
        }
    }
}
