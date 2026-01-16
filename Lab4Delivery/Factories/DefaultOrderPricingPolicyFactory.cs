using Lab4Delivery.Domain;
using Lab4Delivery.Pricing;

namespace Lab4Delivery.Factories
{
    public class DefaultOrderPricingPolicyFactory : IOrderPricingPolicyFactory
    {
        public OrderPricingPolicy CreateFor(OrderType orderType)
        {
            switch (orderType)
            {
                case OrderType.Standard:
                    return new OrderPricingPolicy(
                        new NoDiscountStrategy(),
                        new FixedRateTaxStrategy(0.10m),                     // 10% налог
                        new FreeDeliveryOverThresholdStrategy(800m, 150m)    // доставка 150, бесплатно от 800
                    );

                case OrderType.Express:
                    return new OrderPricingPolicy(
                        new NoDiscountStrategy(),
                        new FixedRateTaxStrategy(0.10m),
                        new FixedDeliveryFeeStrategy(300m)                  // экспресс дороже
                    );

                case OrderType.WithPreferences:
                    return new OrderPricingPolicy(
                        new PercentageDiscountStrategy(0.05m),              // -5% “лояльность”
                        new FixedRateTaxStrategy(0.10m),
                        new FreeDeliveryOverThresholdStrategy(700m, 150m)
                    );

                default:
                    throw new ArgumentOutOfRangeException(nameof(orderType));
            }
        }
    }
}
