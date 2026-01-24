using Xunit;

using Lab3FoodDelivery.Menu;
using Lab3FoodDelivery.Orders;
using Lab3FoodDelivery.Builder;
using Lab3FoodDelivery.AbstractFactory;

namespace Lab3FoodDelivery.Tests.Orders
{
    public class OrderTests
    {
        [Fact]
        public void Builder_Build_ReturnsOrderWithStateAndPricingRules()
        {
            Dish dish = new Dish("d1", "Блины", 440);
            IOrderConfigFactory factory = new StandardOrderFactory();

            Order order = new OrderBuilder()
                .SetId("order-1")
                .SetType(OrderType.Standard)
                .SetFactory(factory)
                .AddDish(dish, 1)
                .Build();

            Assert.NotNull(order);
            Assert.NotNull(order.State);
            Assert.NotNull(order.PricingRules);
        }

        [Fact]
        public void Order_State_ProcessFromPreparing_MakesDelivering()
        {
            Dish dish = new Dish("d1", "Блины", 440);
            IOrderConfigFactory factory = new StandardOrderFactory();

            Order order = new OrderBuilder()
                .SetId("order-2")
                .SetType(OrderType.Standard)
                .SetFactory(factory)
                .AddDish(dish, 1)
                .Build();

            order.Process();

            Assert.Equal("В доставке", order.GetStatus());
        }

        [Fact]
        public void Order_State_MarkAsDeliveredFromDelivering_MakesCompleted()
        {

            Dish dish = new Dish("d1", "Блины", 440);
            IOrderConfigFactory factory = new StandardOrderFactory();

            Order order = new OrderBuilder()
                .SetId("order-3")
                .SetType(OrderType.Standard)
                .SetFactory(factory)
                .AddDish(dish, 1)
                .Build();

            order.Process(); 
            order.MarkAsDelivered();

            Assert.Equal("Выполнен", order.GetStatus());
        }

        [Fact]
        public void Order_TotalPrice_StandardFactory_CountsDeliveryFee()
        {
            Dish dish = new Dish("d1", "Салат", 500);
            IOrderConfigFactory factory = new StandardOrderFactory();

            Order order = new OrderBuilder()
                .SetId("order-4")
                .SetType(OrderType.Standard)
                .SetFactory(factory)
                .AddDish(dish, 1)
                .Build();

            int total = order.GetTotalPrice();

            // itemsTotal = 500
            // discount = 0
            // tax = 0
            // delivery = 200
            // total = 700
            Assert.Equal(700, total);
        }

        [Fact]
        public void Order_TotalPrice_SpecialFactory_UsesDiscountTaxAndExpressDelivery()
        {
            // SpecialOrderFactory(10, 5):
            // discount 10%, tax 5%, delivery express
            Dish dish = new Dish("d1", "Салат", 500);
            IOrderConfigFactory factory = new SpecialOrderFactory(10, 5);

            Order order = new OrderBuilder()
                .SetId("order-5")
                .SetType(OrderType.Special)
                .SetFactory(factory)
                .AddDish(dish, 1)
                .Build();
            int total = order.GetTotalPrice();

            // itemsTotal = 500
            // discount = 500 * 10 / 100 = 50
            // afterDiscount = 450
            // tax = 450 * 5 / 100 = 22 (int)
            // delivery (Express, сумма < 1000) = 400
            // total = 450 + 22 + 400 = 872
            Assert.Equal(872, total);
        }
    }
}
