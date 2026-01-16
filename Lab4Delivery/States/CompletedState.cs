using Lab4Delivery.Domain;

namespace Lab4Delivery.States;

public class CompletedState : IOrderState
{
    public OrderStatus Status => OrderStatus.Completed;

    public void MoveNext(Order order)
    {
        throw new InvalidOperationException("Order is already completed.");
    }
}
