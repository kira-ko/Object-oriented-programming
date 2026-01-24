using Lab3FoodDelivery.AbstractFactory;
using Lab3FoodDelivery.Menu;
using Lab3FoodDelivery.Orders;

namespace Lab3FoodDelivery.Builder
{
    public class OrderBuilder
    {
        private string _id;
        private OrderType _type;
        private IOrderConfigFactory _factory;
        private Dish _dish1;
        private int _qty1;

        private Dish _dish2;
        private int _qty2;
        private Dish _dish3;
        private int _qty3;

        public OrderBuilder SetId(string id)
        {
            _id = id;
            return this;
        }
        public OrderBuilder SetType(OrderType type)
        {
            _type = type;
            return this;
        }
        public OrderBuilder SetFactory(IOrderConfigFactory factory)
        {
            _factory = factory;
            return this;
        }
        public OrderBuilder AddDish(Dish dish, int quantity)
        {
            if (dish == null)
            {
                return this;
            }
            if (quantity <= 0)
            {
                return this;
            }
            if (_dish1 == null)
            {
                _dish1 = dish;
                _qty1 = quantity;
                return this;
            }
            if (_dish2 == null)
            {
                _dish2 = dish;
                _qty2 = quantity;
                return this;
            }
            if (_dish3 == null)
            {
                _dish3 = dish;
                _qty3 = quantity;
                return this;
            }
            return this;
        }

        public Order Build()
        {
            if (_id == null)
            {
                return null;
            }
            if (_factory == null)
            {
                return null;
            }

            Order order = new Order(_id, _type);
            order.State = _factory.CreateStartState(order);
            order.PricingRules = _factory.CreatePricingRules();
            if (_dish1 != null)
            {
                order.AddItem(new OrderItem(_dish1, _qty1));
            }

            if (_dish2 != null)
            {
                order.AddItem(new OrderItem(_dish2, _qty2));
            }

            if (_dish3 != null)
            {
                order.AddItem(new OrderItem(_dish3, _qty3));
            }

            return order;
        }
    }
}
