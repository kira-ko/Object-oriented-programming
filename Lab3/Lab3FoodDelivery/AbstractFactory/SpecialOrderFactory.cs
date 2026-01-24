using Lab3FoodDelivery.Orders;
using Lab3FoodDelivery.State;
using Lab3FoodDelivery.Strategies;

namespace Lab3FoodDelivery.AbstractFactory
{
    public class SpecialOrderFactory : IOrderConfigFactory
    {
        private int _discountPercent;
        private int _taxPercent;

        public SpecialOrderFactory(int discountPercent, int taxPercent)
        {
            _discountPercent = discountPercent;
            _taxPercent = taxPercent;
        }
        public OrderPricingRules CreatePricingRules()
        {
            OrderPricingRules rules = new OrderPricingRules();
            rules.DiscountStrategy = new PercentDiscountStrategy(_discountPercent);
            rules.TaxStrategy = new SimpleTaxStrategy(_taxPercent);
            rules.DeliveryFeeStrategy = new ExpressDeliveryFeeStrategy();
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
