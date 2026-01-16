using Lab4Delivery.Domain;

namespace Lab4Delivery.States;

public class PreparingState : IOrderState
{
    public OrderStatus Status => OrderStatus.Preparing;

    public void MoveNext(Order order)
    {
        order.SetState(new DeliveringState());
    }
}
