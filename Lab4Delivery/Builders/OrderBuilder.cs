using Lab4Delivery.Domain;

namespace Lab4Delivery.Builders
{
    public class OrderBuilder
    {
        private OrderType _type = OrderType.Standard;
        private string? _preferences;
        private readonly List<(Dish dish, int qty)> _items = new();

        public OrderBuilder WithType(OrderType type)
        {
            _type = type;
            return this;
        }

        public OrderBuilder WithPreferences(string preferences)
        {
            _preferences = preferences;
            return this;
        }

        public OrderBuilder AddDish(Dish dish, int quantity)
        {
            _items.Add((dish, quantity));
            return this;
        }

        public Order Build()
        {
            var order = new Order(_type, _preferences);

            foreach (var (dish, qty) in _items)
                order.AddItem(dish, qty);

            return order;
        }
    }
}
