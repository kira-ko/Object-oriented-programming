using Lab4Delivery.Builders;
using Lab4Delivery.Domain;
using Lab4Delivery.Factories;
using Lab4Delivery.Services;
using Lab4Delivery.States;
using Lab4Delivery.Tests.TestDoubles;
using Xunit;

namespace Lab4Delivery.Tests
{
    public class OrderServiceTests
    {
        [Fact]
        public void CreateOrder_ShouldStoreAndReturnOrder()
        {
            var pricing = new OrderPricingService(new DefaultOrderPricingPolicyFactory());
            var service = new OrderService(pricing);

            var pizza = new Dish("Pizza", 400m);

            var builder = new OrderBuilder()
                .WithType(OrderType.Standard)
                .AddDish(pizza, 1);

            var order = service.CreateOrder(builder);

            var loaded = service.GetOrder(order.Id);

            Assert.Equal(order.Id, loaded.Id);
            Assert.Single(loaded.Items);

        }

        [Fact]
        public void AdvanceStatus_ShouldMoveToNextState()
        {
            var pricing = new OrderPricingService(new DefaultOrderPricingPolicyFactory());
            var service = new OrderService(pricing);

            var builder = new OrderBuilder()
                .WithType(OrderType.Standard)
                .AddDish(new Dish("Burger", 500m), 1);

            var order = service.CreateOrder(builder);

            Assert.Equal(OrderStatus.Preparing, order.Status);

            service.AdvanceStatus(order.Id);
            Assert.Equal(OrderStatus.Delivering, service.GetOrder(order.Id).Status);
        }

        [Fact]
        public void Subscribe_ShouldNotifyObserver_OnStatusChange()
        {
            var pricing = new OrderPricingService(new DefaultOrderPricingPolicyFactory());
            var service = new OrderService(pricing);

            var order = service.CreateOrder(
                new OrderBuilder()
                    .WithType(OrderType.Standard)
                    .AddDish(new Dish("Cola", 100m), 1)
            );

            var observer = new FakeOrderObserver();

            service.Subscribe(order.Id, observer);

            service.AdvanceStatus(order.Id);

            Assert.Equal(1, observer.CallsCount);
            Assert.Equal(OrderStatus.Delivering, observer.LastStatus);
        }

        [Fact]
        public void CalculateTotal_ShouldReturnPricingServiceResult()
        {
            var pricing = new OrderPricingService(new DefaultOrderPricingPolicyFactory());
            var service = new OrderService(pricing);

            var order = service.CreateOrder(
                new OrderBuilder()
                    .WithType(OrderType.Standard)
                    .AddDish(new Dish("Pizza", 400m), 1)
                    .AddDish(new Dish("Cola", 100m), 1)
            );

            // из прошлых тестов: total должен быть 700
            var total = service.CalculateTotal(order.Id);

            Assert.Equal(700m, total);
        }
    }
}
