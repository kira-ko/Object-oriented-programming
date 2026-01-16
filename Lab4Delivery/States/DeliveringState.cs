using Lab4Delivery.Domain;

namespace Lab4Delivery.States;

public class DeliveringState : IOrderState
{
    public OrderStatus Status => OrderStatus.Delivering;

    public void MoveNext(Order order)
    {
        order.SetState(new CompletedState());
    }
}
