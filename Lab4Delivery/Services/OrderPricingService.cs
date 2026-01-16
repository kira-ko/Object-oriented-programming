using Lab4Delivery.Domain;
using Lab4Delivery.Factories;

namespace Lab4Delivery.Services
{
    public class OrderPricingService
    {
        private readonly IOrderPricingPolicyFactory _factory;

        public OrderPricingService(IOrderPricingPolicyFactory factory)
        {
            _factory = factory;
        }

        public decimal CalculateTotal(Order order)
        {
            var policy = _factory.CreateFor(order.Type);

            var subtotal = order.ItemsSubtotal;

            var discount = policy.Discount.CalculateDiscount(subtotal);
            var afterDiscount = subtotal - discount;

            var tax = policy.Tax.CalculateTax(afterDiscount);
            var delivery = policy.Delivery.CalculateDeliveryFee(subtotal);

            var total = afterDiscount + tax + delivery;

            // Чтобы не было отрицательных итогов из-за странных правил
            if (total < 0m) total = 0m;

            return decimal.Round(total, 2);
        }
    }
}
