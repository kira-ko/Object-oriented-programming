using Lab4Delivery.Builders;
using Lab4Delivery.Domain;
using Lab4Delivery.Observers;

namespace Lab4Delivery.Services
{
    public class OrderService
    {
        private readonly OrderPricingService _pricingService;
        private readonly Dictionary<Guid, Order> _orders = new();

        public OrderService(OrderPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        public Order CreateOrder(OrderBuilder builder)
        {
            var order = builder.Build();
            _orders[order.Id] = order;
            return order;
        }

        public Order GetOrder(Guid id)
        {
            if (!_orders.TryGetValue(id, out var order))
                throw new KeyNotFoundException($"Order '{id}' not found.");

            return order;
        }

        public void AdvanceStatus(Guid id)
        {
            var order = GetOrder(id);
            order.MoveToNextStatus();
        }

        public decimal CalculateTotal(Guid id)
        {
            var order = GetOrder(id);
            return _pricingService.CalculateTotal(order);
        }

        public void Subscribe(Guid id, IOrderObserver observer)
        {
            var order = GetOrder(id);
            order.Subscribe(observer);
        }

        public void Unsubscribe(Guid id, IOrderObserver observer)
        {
            var order = GetOrder(id);
            order.Unsubscribe(observer);
        }
    }
}
