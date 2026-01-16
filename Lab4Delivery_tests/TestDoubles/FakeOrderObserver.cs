using Lab4Delivery.Domain;
using Lab4Delivery.Observers;
using Lab4Delivery.States;

namespace Lab4Delivery.Tests.TestDoubles
{
    public class FakeOrderObserver : IOrderObserver
    {
        public int CallsCount { get; private set; }
        public OrderStatus? LastStatus { get; private set; }

        public void OnStatusChanged(Order order, OrderStatus newStatus)
        {
            CallsCount++;
            LastStatus = newStatus;
        }
    }
}
