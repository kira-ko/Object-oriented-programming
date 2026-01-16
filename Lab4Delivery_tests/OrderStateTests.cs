using Lab4Delivery.Domain;
using Lab4Delivery.States;
using Xunit;

namespace Lab4Delivery.Tests;

public class OrderStateTests
{
    [Fact]
    public void NewOrder_ShouldStartInPreparing()
    {
        var order = new Order(OrderType.Standard);
        Assert.Equal(OrderStatus.Preparing, order.Status);
    }

    [Fact]
    public void Order_ShouldMovePreparing_ToDelivering_ToCompleted()
    {
        var order = new Order(OrderType.Standard);

        order.MoveToNextStatus();
        Assert.Equal(OrderStatus.Delivering, order.Status);

        order.MoveToNextStatus();
        Assert.Equal(OrderStatus.Completed, order.Status);
    }

    [Fact]
    public void CompletedOrder_MoveNext_ShouldThrow()
    {
        var order = new Order(OrderType.Standard);

        order.MoveToNextStatus(); // Delivering
        order.MoveToNextStatus(); // Completed

        Assert.Throws<InvalidOperationException>(() => order.MoveToNextStatus());
    }
}
