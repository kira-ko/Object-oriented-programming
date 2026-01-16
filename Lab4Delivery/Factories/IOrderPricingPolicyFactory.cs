using Lab4Delivery.Domain;
using Lab4Delivery.Pricing;

namespace Lab4Delivery.Factories
{
    public interface IOrderPricingPolicyFactory
    {
        OrderPricingPolicy CreateFor(OrderType orderType);
    }
}
