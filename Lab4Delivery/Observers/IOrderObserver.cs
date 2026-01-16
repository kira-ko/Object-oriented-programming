using Lab4Delivery.Domain;
using Lab4Delivery.States;

namespace Lab4Delivery.Observers;

public interface IOrderObserver
{
    void OnStatusChanged(Order order, OrderStatus newStatus);
}
