using Lab4Delivery.Domain;

namespace Lab4Delivery.States
{
    public interface IOrderState
    {
        OrderStatus Status { get; }
        void MoveNext(Order order);
    }
}
