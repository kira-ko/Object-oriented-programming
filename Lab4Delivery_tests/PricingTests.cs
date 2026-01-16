using Lab4Delivery.Builders;
using Lab4Delivery.Domain;
using Lab4Delivery.Factories;
using Lab4Delivery.Services;
using Xunit;

namespace Lab4Delivery.Tests
{
    public class PricingTests
    {
        [Fact]
        public void StandardOrder_ShouldCalculateTotal_WithTaxAndDelivery()
        {
            var factory = new DefaultOrderPricingPolicyFactory();
            var pricing = new OrderPricingService(factory);

            var pizza = new Dish("Pizza", 400m);
            var cola = new Dish("Cola", 100m);

            var order = new OrderBuilder()
                .WithType(OrderType.Standard)
                .AddDish(pizza, 1) // 400
                .AddDish(cola, 1)  // 100
                .Build();

            // subtotal = 500
            // discount = 0
            // tax = 10% of 500 = 50
            // delivery = 150 (т.к. меньше 800)
            // total = 500 + 50 + 150 = 700
            var total = pricing.CalculateTotal(order);

            Assert.Equal(700m, total);
        }

        [Fact]
        public void ExpressOrder_ShouldHaveHigherDeliveryFee()
        {
            var factory = new DefaultOrderPricingPolicyFactory();
            var pricing = new OrderPricingService(factory);

            var dish = new Dish("Burger", 500m);

            var standard = new OrderBuilder()
                .WithType(OrderType.Standard)
                .AddDish(dish, 1)
                .Build();

            var express = new OrderBuilder()
                .WithType(OrderType.Express)
                .AddDish(dish, 1)
                .Build();

            var totalStandard = pricing.CalculateTotal(standard);
            var totalExpress = pricing.CalculateTotal(express);

            Assert.True(totalExpress > totalStandard);
        }

        [Fact]
        public void WithPreferencesOrder_ShouldApplyDiscount()
        {
            var factory = new DefaultOrderPricingPolicyFactory();
            var pricing = new OrderPricingService(factory);

            var dish = new Dish("Sushi", 1000m);

            var order = new OrderBuilder()
                .WithType(OrderType.WithPreferences)
                .WithPreferences("No onions")
                .AddDish(dish, 1)
                .Build();

            // subtotal = 1000
            // discount = 5% => 50, after = 950
            // tax = 10% of 950 = 95
            // delivery = 0 (т.к. >= 700)
            // total = 950 + 95 = 1045
            var total = pricing.CalculateTotal(order);

            Assert.Equal(1045m, total);
        }
    }
}
