using Lab3FoodDelivery.Orders;
using Lab3FoodDelivery.State;

namespace Lab3FoodDelivery.AbstractFactory
{

    public interface IOrderConfigFactory
    {
        OrderPricingRules CreatePricingRules();
        IOrderState CreateStartState(Order order);
    }
}
